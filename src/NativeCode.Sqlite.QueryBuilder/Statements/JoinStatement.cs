namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Text;

    public class JoinStatement : QueryStatement
    {
        public JoinStatement(EntityTable table, EntityTable join, EntityColumn left, EntityColumn right) : base("JOIN", table)
        {
            this.Left = left;
            this.Right = right;
            this.TableJoin = join;
        }

        protected EntityColumn Left { get; private set; }

        protected EntityColumn Right { get; private set; }

        protected EntityTable TableJoin { get; private set; }

        protected internal override void Prepare(QueryBuilder builder, QueryStatement previous)
        {
        }

        protected internal override void WriteTo(StringBuilder template, QueryStatement parent)
        {
        }
    }
}