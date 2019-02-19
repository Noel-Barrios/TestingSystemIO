using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;


namespace testingSystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //         Opens the specified text file, reads all the text in the file, and then closes the file. 
            string path = @"jsonFiles/PatientMedicalProfileSearch.json";
            string path2 = @"jsonFiles/appNames.json";
            string path3 = @"jsonFiles/deleteThisFile";

            if (!File.Exists(path2))
            {
                Console.WriteLine("File does NOT Exist,");
                string createText = "This is new text for a new text file" + Environment.NewLine;
                File.WriteAllText(path2, createText, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("The file exists!" + Environment.NewLine);
                string stringifiedJSON = File.ReadAllText(path2);
                //Console.WriteLine(stringifiedJSON);

                var objects = JArray.Parse(stringifiedJSON);
                foreach (JObject root in objects)
                {
                    foreach(KeyValuePair<String, JToken> app in root)
                    {
                        var appName = app.Key;
                        var description = (String)app.Value["Description"];
                        var value = (String)app.Value["Value"];
                        Console.WriteLine(appName);
                        Console.WriteLine(description);
                        Console.WriteLine(value);
                        Console.WriteLine(Environment.NewLine);
                    }
                }

            }


        }
    }
}
