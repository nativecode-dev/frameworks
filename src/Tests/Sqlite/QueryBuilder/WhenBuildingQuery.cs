namespace Tests.Sqlite.QueryBuilder
{
    using System.Diagnostics.CodeAnalysis;

    using NativeCode.Sqlite.QueryBuilder;

    using NUnit.Framework;

    using Tests.Entities;

    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class WhenBuildingQuery : TestingWithResources
    {
        private const string ExpectedDeleteQuery = "Tests.Expectations.DeleteQuery.expect";

        private const string ExpectedDeleteQueryFiltered = "Tests.Expectations.DeleteQueryFiltered.expect";

        private const string ExpectedInsertQuery = "Tests.Expectations.InsertQuery.expect";

        private const string ExpectedJoinQuery = "Tests.Expectations.JoinQuery.expect";

        private const string ExpectedJoinQueryFiltered = "Tests.Expectations.JoinQueryFiltered.expect";

        private const string ExpectedSelectQuery = "Tests.Expectations.SelectQuery.expect";

        private const string ExpectedSelectQueryFiltered = "Tests.Expectations.SelectQueryFiltered.expect";

        private const string ExpectedUpdateQuery = "Tests.Expectations.UpdateQuery.expect";

        private const string ExpectedUpdateQueryFiltered = "Tests.Expectations.UpdateQueryFiltered.expect";

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
            var builder = QueryBuilder.From<Person>().Select(person => person.GetAllColumns()).Join<PersonLocation>(p => p["Id"], pl => pl["PersonId"]);

            // Act
            var template = builder.BuildTemplate();

            // Assert
            Assert.AreEqual(Expect(ExpectedJoinQuery), template.Query);
        }

        [Test]
        public void ShouldBuildJoinedQueryFiltered()
        {
            // Arrange
            var builder =
                QueryBuilder.From<Person>()
                    .Select(person => person.GetAllColumns())
                    .JoinSelect<PersonLocation>(p => p["Id"], pl => pl["PersonId"], pl => pl.GetAllColumns())
                    .Where<PersonLocation>(pl => pl["PersonId"]);

            // Act
            var template = builder.BuildTemplate();

            // Assert
            Assert.AreEqual(Expect(ExpectedJoinQueryFiltered), template.Query);
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

        protected override void DoFixtureSetUp()
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