using DemoLibrary.Models;

namespace DemoLibrary;

public static class DataAccess
{
    private static string personTextFile = "PersonText.txt";

    public static void AddNewPerson(PersonModel person)
    {
        List<PersonModel> people = GetAllPeople();

        AddPersonToPeopleList(people, person);

        var lines = ConvertModelsToCSV(people);

        File.WriteAllLines(personTextFile, lines);
    }

    public static void AddPersonToPeopleList(List<PersonModel> people, PersonModel person)
    {
        people.Add(person);
    }

    public static List<string> ConvertModelsToCSV(List<PersonModel> people)
    {
        List<string> output = new List<string>();

        foreach (PersonModel user in people)
        {
            output.Add($"{user.FirstName},{user.LastName}");
        }

        return output;
    }

    public static List<PersonModel> GetAllPeople()
    {
        List<PersonModel> output = new List<PersonModel>();
        string[] content = File.ReadAllLines(personTextFile);

        foreach (string line in content)
        {
            string[] data = line.Split(",");
            output.Add(new PersonModel { FirstName = data[0], LastName = data[1] });
        }
        return output;
    }
}
