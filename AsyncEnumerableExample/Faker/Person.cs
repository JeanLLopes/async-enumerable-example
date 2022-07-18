using Bogus;

public static class Person
{
    public static IEnumerable<string> Persons(int quantity = 100)
    {
        var persons = new List<string>();
        
        for (int interation = 0; interation < quantity; interation++)
        {
            var faker = new Faker();
            persons.Add(faker.Person.FullName);
        }

        return persons.AsReadOnly();
    }
}