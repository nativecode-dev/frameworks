namespace NativeCode.Mobile.Core.Logging
{
    using System;
    using System.Text.RegularExpressions;

    public class LogMessage
    {
        private static readonly Regex FileNameRegex = new Regex("\\w+(\\w+\\.cs)");

        public LogMessage()
        {
            this.Identifier = Guid.NewGuid();
        }

        public string CallerFilePath { get; set; }

        public int CallerLineNumber { get; set; }

        public string CallerMemberName { get; set; }

        public long GarbageCollectorMemory { get; set; }

        public Guid Identifier { get; private set; }

        public string Message { get; set; }

        public DateTime MessageDateTime { get; set; }

        public LogMessageType MessageType { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}.{2}: {3}", this.MessageType, this.GetClassName(), this.CallerMemberName, this.Message);
        }

        public string GetClassName()
        {
            var match = FileNameRegex.Match(this.CallerFilePath);
            var type = match.Captures[0].Value.Replace(".cs", string.Empty);

            return type + "." + this.CallerMemberName;
        }
    }
}