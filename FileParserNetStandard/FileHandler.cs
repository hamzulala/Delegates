using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FileParserNetStandard {
    public class FileHandler {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public  List<string> ReadFile(string filePath) {
            List<string> lines = new List<string>();
            string[] temp = File.ReadAllLines(filePath);
            foreach(var line in temp)
            { lines.Add(line); }
            return lines;
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public  void WriteFile(string filePath, char delimeter, List<List<string>> rows) {
            foreach (List<string> list in rows)
            {
                string line = "";
                foreach (string data in list)
                {
                    line = line + data + delimeter;
                }
                line = line.TrimEnd(delimeter);
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filePath,true))
                {  
                    file.Write(line);
                    file.Write(file.NewLine);
                }

            }
            
            

        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimeter) {

            List<List<String>> result = new List<List<string>>();
            foreach(string text in data)
            {
               
                result.Add(text.Split(delimeter).ToList());
            }

            return result;//-- return result here
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public  List<List<string>> ParseCsv(List<string> data) {
            List<List<string>> result = new List<List<string>>();
            foreach(string s in data)
            {
                List<string> splitString = new List<string>();
                splitString = s.Split(',').ToList();
                result.Add(splitString);
            }

            return result;  //-- return result here
        }
    }
}