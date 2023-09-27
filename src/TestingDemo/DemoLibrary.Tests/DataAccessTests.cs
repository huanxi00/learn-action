using DemoLibrary.Models;

namespace DemoLibrary.Tests;

public class DataAccessTests
{
    [Fact]
    public void AddPersonToPeopleList_ShouldWork()
    {
        PersonModel newPerson = new PersonModel
        {
            FirstName = "Fang",
            LastName = "Huang"
        };
        List<PersonModel> people = new List<PersonModel>();
        DataAccess.AddPersonToPeopleList(people, newPerson);

        Assert.True(people.Count == 1);
        Assert.Contains<PersonModel>(newPerson, people);
    }
}
