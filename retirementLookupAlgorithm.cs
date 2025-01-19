//retirementTableLookup

public class LookupCodeAssigner 
{
    private readonly Dictionary<string, int> _lookupTable;

    public LookupCodeAssigner(Dictionary<string, int> lookupTable)
    {
        _lookupTable = lookupTable ?? throw new ArgumentNullException(nameof(lookupTable));
    }

    public int GetCode(string dataValue)
    {
        if (!_lookupTable.TryGetValue(dataValue, out int code))
        {
            // Handle case where dataValue is not found in the lookup table
            // You can throw an exception, return a default value, etc.
            throw new ArgumentException($"Data value '{dataValue}' not found in lookup table");
        }
        return code;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create the lookup table (replace with your actual values)
        var lookupTable = new Dictionary<string, int>()
        {
            { "SYSM", 100 },
            { "ERS / TIER I", 100000000 },
            { "ERS / TIER II", 100000001 },
            { "N/A", 100000002 },
            { "TRS / TIER I", 100000003 },
            { "TRS / TIER II", 100000004 },
        };

        // Create an instance of the LookupCodeAssigner
        var codeAssigner = new LookupCodeAssigner(lookupTable);

        // Sample data value (replace with your data)
        string dataValue = "TRS / TIER II";

        try
        {
            int code = codeAssigner.GetCode(dataValue);
            Console.WriteLine($"Code for '{dataValue}': {code}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
