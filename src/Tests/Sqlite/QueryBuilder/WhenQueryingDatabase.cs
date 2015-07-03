namespace Tests.Sqlite.QueryBuilder
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NativeCode.Sqlite.QueryBuilder;

    using SQLite.Net;

    using Tests.Entities;

    [TestClass]
    public class WhenQueryingDatabase : TestingWithDatabaseIsolation
    {
        [TestMethod]
        public void ShouldQueryPerson()
        {
            // Arrange
            using (var connection = this.CreateDatabase().CreateConnection())
            {
                var query = QueryBuilder.From<Person>().Select(p => p.GetAllColumns()).BuildTemplate();

                // Act
                var people = connection.Query<Person>(query.Apply());

                // Assert
                Assert.IsTrue(people.Any());
            }
        }

        [TestMethod]
        [Ignore]
        public void ShouldQueryPersonByLinkTable()
        {
            // Arrange
            using (var connection = this.CreateDatabase().CreateConnection())
            {
                var query =
                    QueryBuilder.From<Person>()
                        .Select(p => p.GetAllColumns())
                        .Join<PersonLocation>(p => p["Id"], pl => pl["PersonId"])
                        .Where<PersonLocation>(pl => pl["LocationId"])
                        .BuildTemplate();

                query.SetParameter("LocationId", "Home");

                // Act
                var people = connection.Query<Person>(query.Apply());

                // Assert
                Assert.IsTrue(people.Any());
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

                CreateTestUser1(connection);
            }

            return database;
        }

        private static void CreateTestUser1(SQLiteConnection connection)
        {
            var person1 = CreatePerson("Test", "User1");
            var person1Home = CreateLocation("Home", "123 Home Street", "Home City", "State", "12343");

            connection.Insert(person1);
            connection.Insert(person1Home);

            var person1Link = LinkLocation(person1, person1Home);
            connection.Insert(person1Link);
        }

        private static Person CreatePerson(string firstName, string lastName)
        {
            return new Person { FirstName = firstName, LastName = lastName };
        }

        private static Location CreateLocation(string name, string address, string city, string state, string zipcode)
        {
            return new Location { Address = address, City = city, Name = name, State = state, ZipCode = zipcode };
        }

        private static PersonLocation LinkLocation(Person person, Location location)
        {
            return new PersonLocation { LocationId = location.Name, PersonId = person.Id.GetValueOrDefault() };
        }
    }
}