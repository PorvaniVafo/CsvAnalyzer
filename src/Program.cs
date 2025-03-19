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
static string AnalyzeData(List<double[]> data)
{
    Console.WriteLine("\nCSV File Analysis Results:");
    int columnCount = data[0].Length;
    string report = "";

    for (int i = 0; i < columnCount; i++)
    {
        var columnValues = data.Select(row => row[i]).ToArray();
        double mean = columnValues.Average();
        double min = columnValues.Min();
        double max = columnValues.Max();
        double median = GetMedian(columnValues);

        string result = $"Column {i + 1}: Mean = {mean}, Min = {min}, Max = {max}, Median = {median}";
        Console.WriteLine(result);
        report += result + "\n";
    }
    return report;
}
static double GetMedian(double[] numbers)
{
    Array.Sort(numbers);
    int size = numbers.Length;
    return size % 2 == 0 ? (numbers[size / 2 - 1] + numbers[size / 2]) / 2 : numbers[size / 2];
}
File.WriteAllText("analysis_report.txt", report);
Console.WriteLine("Analysis results have been saved in analysis_report.txt");

catch (Exception ex)
{
    Console.WriteLine("Error processing the file: " + ex.Message);
}
