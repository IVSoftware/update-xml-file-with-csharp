using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace update_xml_file_with_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string FILENAME = "testfile.xml";
            XElement xel = XElement.Load(FILENAME);
            // "What I want is set the value of ApplicationUri from 456 to 789"
            var xMatchesStatedCondition =
                xel
                .Descendants()
                .Where(
                    match=>
                        (match.Name.LocalName == "ApplicationUri") &&
                        (match.Value == "456")
                );
            foreach (var match in xMatchesStatedCondition)
            {
                match.Value = "789";
            }
            File.WriteAllText(FILENAME, xel.ToString());

            // Look at result
            Console.WriteLine(xel.ToString());
            // Pause
            Console.ReadKey();
        }
    }
}
