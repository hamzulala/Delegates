using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{


    internal class Delegate_Exercise
    {
        public static void Main(string[] args)
        {
            
            FileHandler fh = new FileHandler();
            List<string> rawfile= fh.ReadFile("/Users/User/Desktop/WeeklyTaskDELEGATES-master/Files/data.csv");
            List<List<string>> parsedfile = fh.ParseCsv(rawfile);
            DataParser dp = new DataParser();
            dataHandler dhSpace = new dataHandler(dp.StripWhiteSpace);
            dataHandler dhQuotes = new dataHandler(dp.StripQuotes);
            dataHandler dhHash = new dataHandler(StripHash);
            List<List<string>> datahandledfile = dhHash(dhQuotes(dhSpace(parsedfile)));
            Console.WriteLine(datahandledfile[0][0]);
            Console.ReadKey();
            fh.WriteFile("/Users/User/Desktop/WeeklyTaskDELEGATES-master/Files/processed_data.csv", ',', datahandledfile);

        }

        public delegate List<List<string>> dataHandler(List<List<string>> input);

        public static List<List<string>> StripHash(List<List<string>> data)
        {
            List<List<string>> editedData = new List<List<string>>();
            foreach (List<string> l in data)
            {
                List<string> listString = new List<string>();
                foreach (string s in l)
                {
                    listString.Add(s.TrimStart('#'));
                }
                editedData.Add(listString);
            }
            data = editedData;
            return data;
        }





    }
}