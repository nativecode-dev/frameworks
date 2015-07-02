namespace NativeCode.Sqlite.QueryBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    public class QueryTemplate
    {
        protected readonly Dictionary<string, object> QueryParameters = new Dictionary<string, object>();

        protected readonly List<string> QueryTokens = new List<string>();

        private const string KeyToken = "token";

        private const string KeyTokenName = "name";

        private static readonly Regex ParameterRegex = new Regex(@"(?<token>{(?<name>[a-zA-z,_,\-,\.]+)})", RegexOptions.IgnoreCase);

        protected QueryTemplate(string query)
        {
            this.Query = query;

            this.ParseParameters();
        }

        public IReadOnlyDictionary<string, object> Parameters
        {
            get { return this.QueryParameters; }
        }

        public IReadOnlyList<string> Tokens
        {
            get { return this.QueryTokens; }
        }

        public string Query { get; private set; }

        public object this[string key]
        {
            get { return this.SafeGetValue(key); }
            set { this.SafeSetValue(key, value); }
        }

        public static QueryTemplate Parse(string query)
        {
            return new QueryTemplate(query);
        }

        public string Apply()
        {
            var output = this.Query;

            return this.QueryParameters.Aggregate(output, (current, kvp) => current.Replace("{" + kvp.Key + "}", GetStringValue(kvp.Value)));
        }

        public QueryTemplate Reset()
        {
            // We have to create a new list of the query parameters since we'll be
            // modifying inside the loop.
            foreach (var kvp in this.QueryParameters.ToList())
            {
                this.QueryParameters[kvp.Key] = null;
            }

            return this;
        }

        public QueryTemplate SetParameter(string key, object value)
        {
            this.SafeSetValue(key, value);

            return this;
        }

        public override string ToString()
        {
            return this.Apply();
        }

        private static string GetStringValue(object value)
        {
            if (value is DateTime)
            {
                return ((DateTime)value).ToTicksString();
            }

            if (value is Enum)
            {
                return Convert.ToInt32(value).ToString();
            }

            if (value == null)
            {
                return "NULL";
            }

            return value.ToString();
        }

        private object SafeGetValue(string key)
        {
            if (this.QueryParameters.ContainsKey(key))
            {
                return this.QueryParameters[key];
            }

            return null;
        }

        private void SafeSetValue(string key, object value)
        {
            if (this.QueryParameters.ContainsKey(key))
            {
                this.QueryParameters[key] = value;
            }
            else
            {
                this.QueryParameters.Add(key, value);
            }
        }

        private void ParseParameters()
        {
            var matches = ParameterRegex.Matches(this.Query);

            foreach (Match match in matches)
            {
                var token = match.Groups[KeyToken].Value;
                var name = match.Groups[KeyTokenName].Value;

                this.QueryTokens.Add(token);
                this.QueryParameters.Add(name, null);
            }
        }
    }
}