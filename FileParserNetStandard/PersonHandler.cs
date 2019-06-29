using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;

namespace FileParserNetStandard {
    ///
   // public class Person { }  // temporary class delet this when Person is referenced from dll
   // 






        //Must use linq/lambda 











    public class PersonHandler {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            //People = people.ForEach(i => {
            //    People.Add(
            //        new Person(int.Parse(i[0]), i[1], i[2], new DateTime(long.Parse(i[3])))
            //        )    
            //        });
            people.RemoveAt(0);
            People = people.Select(p => new Person(int.Parse(p[0]), p[1], p[2], new DateTime(long.Parse(p[3])))).ToList();
         }
        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest() {

            return People.Where(p => p.Dob == People.Select(d => d.Dob).Min()).ToList(); //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {
            Person selectedperson = People.Where(p => p.Id == id).ToList().FirstOrDefault();
            return selectedperson.FirstName + " " + selectedperson.Surname + " " + selectedperson.Dob.ToString("d/MM/yyyy hh:mm:ss tt/M/yyyy");//-- return result here
        }

        public List<Person> GetOrderBySurname() {
            return People.OrderBy(p=>p.Surname).ToList();  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {

            return People.Where(p=>p.Surname.StartsWith(searchTerm,!caseSensitive,null)).Count();  //-- return result here
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> result = new List<string>();
            //result = People.OrderBy(p=>p.Dob).Select(p => p.Dob.ToString()+"\t"+People.Where(p2=>p2.Dob==p.Dob).Count().ToString()).ToList();
            result = People.GroupBy(p=>p.Dob).OrderBy(p=>p.Key).Select(p=>p.Key.ToString("d/MM/yyyy hh:mm:ss tt")+"\t"+ People.Where(p2 => p2.Dob == p.Key).Count().ToString()).ToList();
            foreach (string s in result)
            { Console.WriteLine(s); }
            return result;  //-- return result here
        }
    }
}