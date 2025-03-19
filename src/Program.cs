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
