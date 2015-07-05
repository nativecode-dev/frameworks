namespace NativeCode.Mobile.Core.Droid.Platform.Storage
{
    using System;

    using Android.OS;

    using Java.IO;

    using NativeCode.Mobile.Core.Platform;

    using Environment = Android.OS.Environment;

    public class AndroidStorageDevice : StorageDevice
    {
        public AndroidStorageDevice(string path, string options) : base(path)
        {
            this.Options = options.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            this.PopulateSizes();
        }

        public override bool IsReadable
        {
            get { return this.State == StorageState.Mounted; }
        }

        public override bool IsRemovable
        {
            get { return this.Path.Contains("extSdCard"); }
        }

        public override bool IsWritable
        {
            get
            {
                if (this.State == StorageState.Mounted)
                {
                    return this.GetStorageStateString() != Environment.MediaMountedReadOnly;
                }

                return false;
            }
        }

        public override StorageState State
        {
            get { return this.GetStorageState(); }
        }

        protected string[] Options { get; private set; }

        private StorageState GetStorageState()
        {
            switch (this.GetStorageStateString())
            {
                case Environment.MediaMounted:
                    return StorageState.Mounted;

                case Environment.MediaRemoved:
                case Environment.MediaUnmounted:
                    return StorageState.Unmounted;

                default:
                    return StorageState.Unknown;
            }
        }

        private string GetStorageStateString()
        {
            using (var file = new File(this.Path))
            {
                if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
                {
#pragma warning disable 618
                    return Environment.GetStorageState(file);
#pragma warning restore 618
                }

                return Environment.GetExternalStorageState(file);
            }
        }

        private void PopulateSizes()
        {
            using (var stats = new StatFs(this.Path))
            {
                if (Build.VERSION.SdkInt < BuildVersionCodes.JellyBeanMr2)
                {
#pragma warning disable 618
                    this.TotalBytes = stats.BlockCount * (long)stats.BlockSize;
                    this.FreeBytes = stats.FreeBlocks * (long)stats.BlockSize;
                    this.AvailableBytes = stats.AvailableBlocks * (long)stats.BlockSize;
#pragma warning restore 618
                }
                else
                {
                    this.TotalBytes = stats.BlockCountLong * stats.BlockSizeLong;
                    this.AvailableBytes = stats.AvailableBlocksLong * stats.BlockSizeLong;
                    this.FreeBytes = stats.FreeBlocksLong * stats.BlockSizeLong;
                }
            }
        }
    }
}