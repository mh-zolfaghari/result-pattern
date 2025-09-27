using ResultPattern.Tools;

namespace ResultPattern.Sample.SampleServices
{
    public record Person(string Name, string Family)
    {
        public string Name { get; private init; } = Name;
        public string Family { get; private init; } = Family;
    }

    public class SampleService
    {
        IList<Person> persons =
        [
            new("John", "Doe"),
            new("Jane", "Smith"),
            new("Michael", "Johnson"),
            new("Emily", "Davis"),
            new("David", "Brown"),
            new("Sarah", "Miller"),
            new("Daniel", "Wilson"),
            new("Laura", "Moore"),
            new("James", "Taylor"),
            new("Olivia", "Anderson")
        ];

        public Result<IEnumerable<Person>> GetAllPersons()
        {
            return Result.Success<IEnumerable<Person>>(persons);
        }

        public Result<Person> GetPersonByName(string name)
        {
            var person = persons.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (person == null)
                return Result.Failure<Person>(Error.NotFound("PersonNotFound", $"No person found with the name '{name}'."));
            return Result.Success(person);
        }

        public Result AddPerson(Person newPerson)
        {
            if (persons.Any(p => p.Name.Equals(newPerson.Name, StringComparison.OrdinalIgnoreCase)))
                return Result.Failure(Error.Conflict("PersonAlreadyExists", $"A person with the name '{newPerson.Name}' already exists."));

            persons.Add(newPerson);
            return Result.Success();
        }
    }
}
