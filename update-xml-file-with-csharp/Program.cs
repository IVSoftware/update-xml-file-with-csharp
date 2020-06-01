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
            // Given the filename and contents you specified
            const string FILENAME = "testfile.xml";
            // Load up an XElement from the file 
            XElement xel = XElement.Load(FILENAME);
            // You: "What I want is set the value of ApplicationUri from 456 to 789"
            var xMatchesStatedCondition =
                xel
                .Descendants() // Iterate all the Descendant nodes...
                .Where(
                    match =>
                        // Here, we make a sublist of elements named 'ApplicationUri'
                        (match.Name.LocalName == "ApplicationUri") &&
                        // ... and from that sublist, find 'any' (could be
                        //     more than one) whose current value is "456"
                        (match.Value == "456")
                );
            // ... and for any matches we find (in this case only one)
            foreach (var match in xMatchesStatedCondition)
            {
                // Set the new value to the one you specified.
                match.Value = "789";
            }
            // Now convert the XElement back to string
            // and overwrite the original file.
            File.WriteAllText(FILENAME, xel.ToString());

            // Verify that it worked
            Console.WriteLine(xel.ToString());
            // Pause
            Console.ReadKey();
        }
    }
}
