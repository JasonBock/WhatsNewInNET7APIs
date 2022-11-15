namespace WhatsNewInNET7APIs;

public interface IData
{
	string Name { get; }
}

public sealed class Data
	: IData
{
	public Data() => this.Name = "Jason";

	public string Name { get; }
}