namespace Tests.Sqlite.QueryBuilder
{
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NativeCode.Sqlite.QueryBuilder;

    using Tests.Entities;

    [TestClass]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class WhenUsingQueryTemplate : TestingWithResources
    {
        private const string ExpectShouldReplaceTokenIgnoringCase = "Tests.Expectations.ShouldReplaceTokenIgnoringCase.expect";

        [TestMethod]
        public void ShouldReplaceTokenIgnoringCase()
        {
            // Arrange
            var template = QueryBuilder.From<Person>().Select(p => p.GetAllColumns()).Where(p => p["FirstName"]).BuildTemplate();

            // Act
            var query = template.SetParameter("firstName", "Mike").Apply();

            // Assert
            Assert.AreEqual(Expect(ExpectShouldReplaceTokenIgnoringCase), query);
        }
    }
}