namespace Tests.Sqlite.QueryBuilder
{
    using NUnit.Framework;

    using Tests.Entities;

    [TestFixture]
    public class WhenExecutingQuery : TestingWithDatabase
    {
        [Test]
        public void ShouldInsertRecord()
        {
            // Arrange
            using (var connection = this.Database.CreateConnection())
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

        protected override void DoTestSetUp()
        {
            base.DoTestSetUp();

            using (var connection = this.Database.CreateConnection())
            {
                connection.CreateTable<Location>();
                connection.CreateTable<Person>();
                connection.CreateTable<PersonLocation>();
            }
        }
    }
}