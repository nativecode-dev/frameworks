namespace Tests.Sqlite.QueryBuilder
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Tests.Entities;

    [TestClass]
    public class WhenExecutingQuery : TestingWithDatabaseIsolation
    {
        [TestMethod]
        public void ShouldInsertRecord()
        {
            // Arrange
            using (var connection = this.CreateDatabase().CreateConnection())
            {
                var person = new Person { FirstName = "Mike", LastName = "Pham" };

                var query =
                    TestQueries.InsertPerson.Reset()
                        .SetParameter(Name.Of(person.FirstName), person.FirstName)
                        .SetParameter(Name.Of(person.LastName), person.LastName)
                        .Apply();

                // Act
                var sut = connection.Execute(query);

                // Assert
                Assert.AreEqual(1, sut);
            }
        }

        [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument", Justification = "Reviewed. Suppression is OK here.")]
        protected override DatabaseInstance CreateDatabase([CallerMemberName] string testname = null)
        {
            var database = base.CreateDatabase(testname);

            using (var connection = database.CreateConnection())
            {
                connection.CreateTable<Location>();
                connection.CreateTable<Person>();
                connection.CreateTable<PersonLocation>();
            }

            return database;
        }
    }
}