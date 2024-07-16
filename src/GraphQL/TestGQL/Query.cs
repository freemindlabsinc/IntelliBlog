namespace TestGQL;

public class Person(string name, int age)
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
}

[QueryType]
public class Query
{
    static Person[] _persons = new Person[]
    {
        new Person("Alice", 30),
        new Person("Bob", 40),
        new Person("Charlie", 50),
    };
    
    public IQueryable<Person> GetPeople()
        => _persons.AsQueryable();
}
