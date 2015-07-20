namespace NativeCode.Mobile.Core.Droid.Logging
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using NativeCode.Core.Collections;
    using NativeCode.Core.Logging;
    using NativeCode.Mobile.Core.Droid.Platform;

    public class FileLogWriter : LogWriter
    {
        private static int initialized;

        private static int flushing;

        private readonly IConcurrentQueue<LogMessage> queue;

        private readonly IContextProvider contextProvider;

        public FileLogWriter(IContextProvider contextProvider, ICollectionFactory collectionFactory)
        {
            this.contextProvider = contextProvider;
            this.queue = collectionFactory.CreateQueue<LogMessage>();
        }

        protected string FileName { get; private set; }

        public override void Write(LogMessage message)
        {
            if (Interlocked.CompareExchange(ref initialized, 1, 0) == 0)
            {
                this.SetupLogFile();
            }

            this.queue.Enqueue(message);
            this.CheckAutoFlush();
        }

        protected override void DoFlush(CancellationToken cancellationToken)
        {
            var count = this.queue.Count;
            var messages = new List<LogMessage>(count);

            while (count > 0)
            {
                LogMessage message;

                if (this.queue.TryDequeue(out message))
                {
                    messages.Add(message);
                    count--;
                }
            }

            try
            {
                File.AppendAllLines(this.FileName, messages.Select(m => m.Stringify(true)));
            }
            finally
            {
                Interlocked.Exchange(ref flushing, 0);
            }
        }

        private void CheckAutoFlush()
        {
            if (this.queue.Count > this.AutoFlushCount)
            {
                if (Interlocked.CompareExchange(ref flushing, 1, 0) == 0)
                {
                    this.FlushAsync(CancellationToken.None);
                }
            }
        }

        private void SetupLogFile()
        {
            var context = this.contextProvider.GetCurrentContext();
            var appLabelId = context.ApplicationInfo.LabelRes;
            var appname = appLabelId == 0 ? "Unknown" : context.GetString(appLabelId);

            var lines = new List<string>
            {
                string.Format("Logging started {0:U}.", DateTime.UtcNow),
                string.Format("App name: {0}.", appname),
                string.Format("App package: {0}.", context.ApplicationInfo.PackageName)
            };

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            this.FileName = Path.Combine(path, string.Format("logfile-{0:u}.log", DateTime.UtcNow).Replace(" ", "_"));
            File.AppendAllLines(this.FileName, lines, Encoding.UTF8);
        }
    }
}