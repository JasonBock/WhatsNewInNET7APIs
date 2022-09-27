using System.Numerics;

//DemonstrateMath();

static void DemonstrateMath()
{
	Console.WriteLine(nameof(DemonstrateMath));
	Console.WriteLine();

	static T Add<T>(T left, T right)
		where T : INumber<T> => left + right;

	Console.WriteLine(Add(3, 4));
	Console.WriteLine(Add(3.4, 4.3));
	Console.WriteLine(Add(int.Parse("3"), 4));
	Console.WriteLine(Add(BigInteger.Parse("49043910940940104390"), BigInteger.Parse("59839583901984390184")));

	Console.WriteLine(int.Abs(-4));
}

//DemonstrateMoreOneLineThrows();

static void DemonstrateMoreOneLineThrows()
{
	Console.WriteLine(nameof(DemonstrateMoreOneLineThrows));
	Console.WriteLine();

	static int GetLength(string value)
	{
		ArgumentException.ThrowIfNullOrEmpty(value);
		return value.Length;
	}

	try
	{
		Console.WriteLine(GetLength("Jason"));
	}
	catch (ArgumentException e) 
	{
		Console.WriteLine(e.Message);
	}

	try
	{
		Console.WriteLine(GetLength(null!));
	}
	catch (ArgumentException e)
	{
		Console.WriteLine(e.Message);
	}
}

//DemonstrateLinqOrder();

// https://devblogs.microsoft.com/dotnet/performance_improvements_in_net_7/#linq
static void DemonstrateLinqOrder()
{
	Console.WriteLine(nameof(DemonstrateLinqOrder));
	Console.WriteLine();

	var items = new[] { 3, 9, 12, 4, -2, 6 };

	// Previously, you had to do this:
	Console.WriteLine("OrderBy");
	var oldOrder = items.OrderBy(static x => x);
	foreach(var oldItem in oldOrder)
	{
		Console.WriteLine(oldItem);
	}

	Console.WriteLine();

	// Now, it's a little simpler:
	Console.WriteLine("Order");
	var newOrder = items.Order();
	foreach (var newItem in newOrder)
	{
		Console.WriteLine(newItem);
	}
}