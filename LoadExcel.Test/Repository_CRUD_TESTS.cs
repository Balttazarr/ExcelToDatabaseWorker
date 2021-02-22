using Xunit;
using WPFAutomation.DataRepository;
using System.Configuration;

namespace LoadExcel.Test
{

    public class Repository_CRUD_TESTS
    {

        private readonly string name = "ConnectionString";

        [Fact]
        public void GetAll_Should_return_people_from_database()
        {
            //arrange
            var repository = new PeopleRepository("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PeopleDB;Integrated Security=True");
            //act
            var people = repository.GetAll();
            //assert
            Assert.True(people.Count == 18);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(15)]
        public void GetThingsOwne_Should_ReturnListOfBelongings(int id)
        {
            var repository = new PeopleRepository("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PeopleDB;Integrated Security=True");

            var peopleBelongings = repository.GetThingsOwnedOfPerson(id);

            Assert.NotNull(peopleBelongings);
        }
    }
}
