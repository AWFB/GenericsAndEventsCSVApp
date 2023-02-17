using System;
using System.Collections.Generic;
using System.IO;

namespace GenericsAndEventsCSV
{
    public class DataAccess<T> where T : new()
    {

        public event EventHandler<T> BadEntryFound;

        // Extension method making use of generic types
        public void SaveToCSV(List<T> items, string filePath) // T has to have an empty constructor
        {
            List<string> rows = new List<string>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            string row = "";

            // Headers
            foreach (var col in cols)
            {
                row += $",{col.Name}";
            }

            row = row.Substring(1); // ignore first comma
            rows.Add(row);

            // Loop through each object 
            foreach (var item in items)
            {
                row = "";
                bool naughtyWordDetected = false;

                // get values in each object 
                foreach (var col in cols)
                {
                    // Check for bad data (naughty words)
                    string val = col.GetValue(item, null).ToString(); // Reflection used here
                    naughtyWordDetected = NaughtyWordDetector(val);

                    if (naughtyWordDetected == true)
                    {
                        BadEntryFound?.Invoke(this, item);
                        break;
                    }

                    row += $",{ val }";
                }

                if (naughtyWordDetected == false)
                {
                    row = row.Substring(1); // ignore first comma
                    rows.Add(row);
                }
            }

            File.WriteAllLines(filePath, rows);

        }

        private bool NaughtyWordDetector(string stringToTest)
        {
            bool output = false;
            string lowerCaseTest = stringToTest.ToLower();


            if (lowerCaseTest.Contains("bloody") || lowerCaseTest.Contains("blimey"))
            {
                output = true;
            }

            return output;
        }
    }
}
