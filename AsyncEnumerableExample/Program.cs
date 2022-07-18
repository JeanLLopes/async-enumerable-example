var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/person/{quantity=10}", (int quantity) => 
{
    IEnumerable<string> GetPersons()
    {
        foreach (var person in Person.Persons(quantity))
        {
            yield return person;
            Task.Delay(500).Wait();
        }
    }
    
    return GetPersons();
});


app.MapGet("/stream/person/{quantity=10}", (int quantity) => 
{
    async IAsyncEnumerable<string> GetPersons()
    {
        foreach (var person in Person.Persons(quantity))
        {
            yield return person;
            await Task.Delay(1000);
        }
    }
    
    return GetPersons();
});

app.Run();