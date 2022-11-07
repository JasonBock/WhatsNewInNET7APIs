using System.Text.RegularExpressions;

namespace WhatsNewInNET7APIs;

public static partial class GuidRegex
{
	// Lifted from: https://www.geeksforgeeks.org/how-to-validate-guid-globally-unique-identifier-using-regular-expression/
	[GeneratedRegex("^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", RegexOptions.IgnoreCase)]
	internal static partial Regex GetRegex();
}