namespace Tests.Sqlite.QueryBuilder
{
    using System.Diagnostics.CodeAnalysis;

    using NativeCode.Sqlite.QueryBuilder;

    using NUnit.Framework;

    using Tests.Entities;

    using QueryBuilder = NativeCode.Sqlite.QueryBuilder.QueryBuilder;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class WhenBuildingQuery : TestingWithResources
    {
        private const string ExpectedDeleteQuery = "Tests.Expectations.DeleteQuery.txt";

        private const string ExpectedDeleteQueryFiltered = "Tests.Expectations.DeleteQueryFiltered.txt";

        private const string ExpectedInsertQuery = "Tests.Expectations.InsertQuery.txt";

        private const string ExpectedSelectQuery = "Tests.Expectations.SelectQuery.txt";

        private const string ExpectedSelectQueryFiltered = "Tests.Expectations.SelectQueryFiltered.txt";

        private const string ExpectedUpdateQuery = "Tests.Expectations.UpdateQuery.txt";

        private const string ExpectedUpdateQueryFiltered = "Tests.Expectations.UpdateQueryFiltered.txt";

        [Test]
        public void ShouldBuildDeleteQuery()
        {
            // Arrange
            var builder = QueryBuilder.From<Person>().Delete();

            // Act
            var template = builder.BuildTemplate();

            // Assert
            Assert.AreEqual(Expect(ExpectedDeleteQuery), template.Query);
        }

        [Test]
        public void ShouldBuildDeleteQueryFiltered()
        {
            // Arrange
            var builder = QueryBuilder.From<Person>().Delete().Where(person => person.GetPrimaryKey());

            // Act
            var template = builder.BuildTemplate();

            // Assert
            Assert.AreEqual(Expect(ExpectedDeleteQueryFiltered), template.Query);
        }

        [Test]
        public void ShouldBuildInsertQuery()
        {
            // Arrange
            var builder = QueryBuilder.From<Person>().Insert(person => person.GetMutableColumns());

            // Act
            var template = builder.BuildTemplate();

            // Assert
            Assert.AreEqual(Expect(ExpectedInsertQuery), template.Query);
        }

        [Test]
        public void ShouldBuildJoinedQuery()
        {
            // Arrange
            var builder = QueryBuilder.From<Person>().Join<PersonLocation>(p => p["Id"], pl => pl["PersonId"]);
        }

        [Test]
        public void ShouldBuildSelectQuery()
        {
            // Arrange
            var builder = QueryBuilder.From<Person>().Select(person => person.Columns);

            // Act
            var template = builder.BuildTemplate();

            // Assert
            Assert.AreEqual(Expect(ExpectedSelectQuery), template.Query);
        }

        [Test]
        public void ShouldBuildSelectQueryFiltered()
        {
            // Arrange
            var builder = QueryBuilder.From<Person>()
                .Select(person => person.Columns)
                .Where(person => person.GetPrimaryKey())
                .And(person => person["FirstName"]);

            // Act
            var template = builder.BuildTemplate();

            // Assert
            Assert.AreEqual(Expect(ExpectedSelectQueryFiltered), template.Query);
        }

        [Test]
        public void ShouldBuildUpdateQuery()
        {
            // Arrange
            var builder = QueryBuilder.From<Person>().Update(person => person.GetMutableColumns());

            // Act
            var template = builder.BuildTemplate();

            // Assert
            Assert.AreEqual(Expect(ExpectedUpdateQuery), template.Query);
        }

        [Test]
        public void ShouldBuildUpdateQueryFiltered()
        {
            // Arrange
            var builder = QueryBuilder.From<Person>().Update(person => person.GetMutableColumns()).Where(person => person.GetPrimaryKey());

            // Act
            var template = builder.BuildTemplate();

            // Assert
            Assert.AreEqual(Expect(ExpectedUpdateQueryFiltered), template.Query);
        }

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var configuration = new QueryBuilderConfiguration
            {
                QualifyColumnNames = true,
                QualifyTableNames = true,
                StoreDateTimeAsTicks = true,
                UseColumnAlias = true,
                UseTableAlias = true
            };

            QueryBuilderConfiguration.Current = configuration;
        }
    }
}