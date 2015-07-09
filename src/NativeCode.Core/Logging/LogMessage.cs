namespace NativeCode.Core.Logging
{
    using System;
    using System.Text.RegularExpressions;

    public class LogMessage
    {
        private static readonly Regex FileNameRegex = new Regex("\\w+(\\w+\\.cs)");

        internal LogMessage()
        {
            this.Identifier = Guid.NewGuid();
            this.GarbageCollectorMemory = GC.GetTotalMemory(false);
        }

        public string CallerFilePath { get; internal set; }

        public int CallerLineNumber { get; internal set; }

        public string CallerMemberName { get; internal set; }

        public long GarbageCollectorMemory { get; private set; }

        public Guid Identifier { get; private set; }

        public string Message { get; internal set; }

        public DateTime MessageDateTime { get; internal set; }

        public LogSeverity Severity { get; internal set; }

        public override string ToString()
        {
            return this.Stringify(false);
        }

        public string Stringify(bool includeDateTime)
        {
            var datetime = this.MessageDateTime;
            var severity = this.Severity;
            var type = this.GetClassName();
            var member = this.CallerMemberName;
            var message = this.Message;

            if (includeDateTime)
            {
                return string.Format("[{0:u}-{1}] ({2}.{3}): {4}", datetime, severity, type, member, message);
            }

            return string.Format("{0} {1}.{2}: {3}", severity, type, member, message);
        }

        public string GetClassName()
        {
            var match = FileNameRegex.Match(this.CallerFilePath);
            var type = match.Captures[0].Value.Replace(".cs", string.Empty);

            return type + "." + this.CallerMemberName;
        }
    }
}