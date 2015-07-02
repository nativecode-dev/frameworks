namespace Tests
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using SQLite.Net;
    using SQLite.Net.Interop;
    using SQLite.Net.Platform.Win32;

    public sealed class DatabaseInstance : IDisposable
    {
        private readonly string filename;

        private readonly ISQLitePlatform platform = new SQLitePlatformWin32();

        public DatabaseInstance() : this("database")
        {
        }

        public DatabaseInstance(string prefix)
        {
            this.filename = string.Format("{0}-{1}.db", prefix, Guid.NewGuid());
            this.platform.SQLiteApi.Config(ConfigOption.MultiThread);

            this.ConnectionString = new SQLiteConnectionString(this.GetDatabasePath(), true);
        }

        public SQLiteConnectionString ConnectionString { get; private set; }

        public SQLiteConnection CreateConnection()
        {
            return this.CreateConnection(this.ConnectionString);
        }

        public SQLiteConnection CreateConnection(SQLiteConnectionString connectionString)
        {
            Console.WriteLine("Connecting to database at {0}.", connectionString.DatabasePath);
            return new SQLiteConnection(this.platform, connectionString.DatabasePath, connectionString.StoreDateTimeAsTicks);
        }

        public string GetDatabasePath()
        {
            return Path.Combine(TestContext.CurrentContext.WorkDirectory, this.filename);
        }

        public void Dispose()
        {
            if (File.Exists(this.filename))
            {
                File.Delete(this.filename);
            }
        }
    }
}