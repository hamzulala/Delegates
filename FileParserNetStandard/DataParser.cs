using System.Collections.Generic;
using System.Linq;

namespace FileParserNetStandard {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public  List<List<string>> StripWhiteSpace(List<List<string>> data) {
            List<List<string>> editedData = new List<List<string>>();
            foreach (List<string> l in data)
            {
                List<string> listString = new List<string>();
                foreach(string s in l)
                {
                    listString.Add(s.Trim(' '));
                }
                editedData.Add(listString);
            }
            data = editedData;
            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
            List<List<string>> editedData = new List<List<string>>();
            foreach (List<string> l in data)
            {
                List<string> listString = new List<string>();
                foreach (string s in l)
                {
                    listString.Add(s.Trim('"'));
                }
                editedData.Add(listString);
            }
            data = editedData;
            return data;
        }

    }
}