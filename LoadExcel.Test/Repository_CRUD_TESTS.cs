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
            var repository = new PeopleRepository(ConfigurationManager.ConnectionStrings[name].ConnectionString);
            //act
            var people = repository.GetAll();
            //assert
            Assert.True(people.Count == 18);
        }
    }
}
