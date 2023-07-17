namespace WhatsNewInNET7APIs;

public interface IPerson
{
	string Name { get; }
}

public sealed class Person
	: IPerson
{
	public Person() => this.Name = "Jason";

	public string Name { get; }
}