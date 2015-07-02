namespace NativeCode.Sqlite.QueryBuilder
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Freezable;

    using NativeCode.Sqlite.QueryBuilder.Converters;

    public class QueryBuilderConfiguration : IFreezable
    {
        public static readonly QueryBuilderConfiguration Default = new QueryBuilderConfiguration(true);

        private static QueryBuilderConfiguration current = Default;

        private bool isFrozen;

        public QueryBuilderConfiguration()
        {
            this.Converters = new List<IQueryValueConverter> { new DateTimeConverter() };

            this.IncludeSemiColon = true;
            this.QualifyColumnNames = true;
            this.QualifyTableNames = true;
        }

        private QueryBuilderConfiguration(bool frozen) : this()
        {
            this.isFrozen = frozen;
        }

        public static QueryBuilderConfiguration Current
        {
            get { return current; }
            set { current = value; }
        }

        public List<IQueryValueConverter> Converters { get; private set; }

        [SuppressMessage("ReSharper", "ConvertToAutoPropertyWithPrivateSetter", Justification = "Reviewed. Suppression is OK here. Freezable.")]
        public bool IsFrozen
        {
            get { return this.isFrozen; }
        }

        public bool IncludeSemiColon { get; set; }

        public bool QualifyColumnNames { get; set; }

        public bool QualifyTableNames { get; set; }

        public bool StoreDateTimeAsTicks { get; set; }

        public bool UseColumnAlias { get; set; }

        public bool UseDoubleQuotes { get; set; }

        public bool UseTableAlias { get; set; }

        public void Freeze()
        {
            this.isFrozen = true;
        }
    }
}