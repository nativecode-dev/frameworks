namespace NativeCode.Sqlite.QueryBuilder.Attributes
{
    using System;

    public sealed class ForeignTypeAttribute : Attribute
    {
        public ForeignTypeAttribute(Type type)
        {
            this.ForeignType = type;
        }

        public Type ForeignType { get; private set; }
    }
}