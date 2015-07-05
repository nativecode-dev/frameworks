namespace NativeCode.Mobile.Core.Platform
{
    public abstract class StorageDevice
    {
        protected StorageDevice(string path)
        {
            this.Path = path;
        }

        public double AvailableBytes { get; protected set; }

        public double FreeBytes { get; protected set; }

        public abstract bool IsReadable { get; }

        public abstract bool IsRemovable { get; }

        public abstract bool IsWritable { get; }

        public abstract StorageState State { get; }

        public double TotalBytes { get; protected set; }

        public string Path { get; private set; }
    }
}