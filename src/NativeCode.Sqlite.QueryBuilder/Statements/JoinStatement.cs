namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    internal class JoinStatement : QueryStatement
    {
        internal JoinStatement(IQueryBuilder builder, EntityColumn left, EntityColumn right) : base(builder, "JOIN")
        {
            this.Left = left;
            this.Right = right;
        }

        protected EntityColumn Left { get; private set; }

        protected EntityColumn Right { get; private set; }

        public override bool CanBeginStatement(QueryStatement current)
        {
            return current == null || current is SelectStatement || current is JoinStatement;
        }

        protected internal override void Prepare(QueryBuilder builder, QueryStatement previous)
        {
        }

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected internal override void WriteTo(StringBuilder template, QueryStatement root)
        {
            template.AppendLine();
            template.Append(this.Keyword);
            template.Append(Space);
            template.Append(this.Right.Table.GetName());
            template.Append(Space);
            template.Append("ON");
            template.Append(Space);
            template.Append(this.Left.Table.Name.QualifyString());
            template.Append(Period);
            template.Append(this.Left.Name.QualifyString());
            template.Append(Space);
            template.Append("=");
            template.Append(Space);
            template.Append(this.Right.Table.Name.QualifyString());
            template.Append(Period);
            template.Append(this.Right.Name.QualifyString());
        }
    }
}