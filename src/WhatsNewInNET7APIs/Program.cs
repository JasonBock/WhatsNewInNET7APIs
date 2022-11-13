using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json;
using WhatsNewInNET7APIs;

//DemonstrateMath();

// Go through IBinaryInteger to IBinaryNumber to find INumber
static void DemonstrateMath()
{
	Console.WriteLine(nameof(DemonstrateMath));
	Console.WriteLine();

	static T Add<T>(T left, T right)
		where T : INumber<T> => left + right;

	Console.WriteLine(Add(3, 4));
	Console.WriteLine(Add(3.4, 4.3));
	Console.WriteLine(Add(BigInteger.Parse("49043910940940104390"), BigInteger.Parse("59839583901984390184")));

	Console.WriteLine();

	Console.WriteLine(Math.Abs(-4));
	Console.WriteLine(int.Abs(-4));
}

//DemonstrateParseable();

// Go through ISignedNumber to find IParseable
static void DemonstrateParseable()
{
	Console.WriteLine(nameof(DemonstrateParseable));
	Console.WriteLine();

	var value = "3";
	Console.WriteLine(int.Parse(value));

   if (int.TryParse(value, out var result))
   {
	  Console.WriteLine(result);
   }
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

//DemonstrateObjectDisposeException();

static void DemonstrateObjectDisposeException()
{
	Console.WriteLine(nameof(DemonstrateObjectDisposeException));
	Console.WriteLine();

	var resource = new DisposableResource();
	Console.WriteLine(resource.GetStreamSize());
	resource.Dispose();

	try
	{
		resource.GetStreamSize();
	}
	catch(ObjectDisposedException e)
	{
		Console.WriteLine(e.Message);
	}

	try
	{
		resource.GetStreamSizeNew();
	}
	catch (ObjectDisposedException e)
	{
		Console.WriteLine(e.Message);
	}
}

//DemonstrateUnreachableException();

static void DemonstrateUnreachableException()
{
	Console.WriteLine(nameof(DemonstrateUnreachableException));
	Console.WriteLine();

	// In Celsius
	static string EvaluateTemperature(double value) =>
		value switch
		{
			// Absolute zero is -273.15,
			// and the theoretical highest temperature is 
			// https://futurism.com/science-explained-hottest-possible-temperature
			> -273.15d and < -80d => "Unbelievably Cold",
			>= -80d and < -30d => "Antartica",
			>= -30d and < 5d => "Winter",
			>= 5d and < 10d => "Fall",
			>= 10d and < 20d => "Spring",
			>= 20d and < 30d => "Summer",
			>= 30d and < 50d => "Hot",
			>= 50d and < 100d => "Danger",
			>= 100d and < 1_420_000_000_000_000_000_000_000_000_000_000d => "Scorching",
			_ => throw new UnreachableException("oh no")
		};

	Console.WriteLine(EvaluateTemperature(10d));
	Console.WriteLine(EvaluateTemperature(45d));
	Console.WriteLine(EvaluateTemperature(-273.15d));
}

//DemonstrateRegularExpressions();

static void DemonstrateRegularExpressions()
{
	Console.WriteLine(nameof(DemonstrateRegularExpressions));
	Console.WriteLine();

	var id = Guid.NewGuid();
	Console.WriteLine(GuidRegex.GetRegex().IsMatch(id.ToString()));
	Console.WriteLine(GuidRegex.GetRegex().IsMatch(id.ToString("N")));
}

//DemonstrateStringSyntax();

static void DemonstrateStringSyntax()
{
	static int SumJson([StringSyntax(StringSyntaxAttribute.Json)] string json)
	{
		var content = JsonDocument.Parse(json);
		var sum = 0;

		foreach(var value in content.RootElement.GetProperty("values").EnumerateArray())
		{
			sum += value.GetInt32();
		}

		return sum;
	}

	Console.WriteLine(nameof(DemonstrateStringSyntax));
	Console.WriteLine();

	Console.WriteLine(SumJson(
		"""
		{
			"values": [1, 3, 7, 22]
		}
		"""));
}

//DemonstrateImmutableCollections();

static void DemonstrateImmutableCollections()
{
	Console.WriteLine(nameof(DemonstrateImmutableCollections));
	Console.WriteLine();

	var itemsBuilder = ImmutableArray.CreateBuilder<string>();
	itemsBuilder.Add("a");
	itemsBuilder.Add("b");
	itemsBuilder.Add("c");

	var items = itemsBuilder.ToImmutable();

	// Now you can "add" a range to an immutable array,
	// as well as insert and remove.
	var newItems = items.AddRange("d", "e", "f");

	Console.WriteLine(string.Join(", ", items));
	Console.WriteLine(string.Join(", ", newItems));
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
	foreach (var oldItem in oldOrder)
	{
		Console.WriteLine(oldItem);
	}

	Console.WriteLine();

	var names = new[] { "Jason", "Jane", "Don" };

	foreach (var name in names.Order())
	{
		Console.WriteLine(name);
	}

	// Now, it's a little simpler:
	Console.WriteLine("Order");
	var newOrder = items.Order();
	foreach (var newItem in newOrder)
	{
		Console.WriteLine(newItem);
	}
}