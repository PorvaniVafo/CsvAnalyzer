using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the path to the CSV file:");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found. Please check the path and try again.");
            return;
        }
    }
}
Console.WriteLine("Enter the delimiter (default is ','):");
string separator = Console.ReadLine();
if (string.IsNullOrWhiteSpace(separator)) separator = ",";

static List<double[]> ReadCsv(string path, string separator)
{
    List<double[]> data = new List<double[]>();
    string[] lines = File.ReadAllLines(path);

    foreach (string line in lines.Skip(1)) // Skip header
    {
        try
        {
            double[] values = line.Split(separator)
                                  .Select(v => double.Parse(v.Trim()))
                                  .ToArray();
            data.Add(values);
        }
        catch
        {
            Console.WriteLine("Error processing line (possibly non-numeric values): " + line);
        }
    }
    return data;
}
