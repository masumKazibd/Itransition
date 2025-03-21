using System;
using System.IO;

class Program
{
    static void Main()
    {
        string outputPath = "./solution.js";
        using (var writer = new StreamWriter(outputPath))
        {
            TextWriter originalConsole = Console.Out;
            Console.SetOut(writer);


            string[] csharpLines = {
                "using System;",
                "using System.IO;",
                "",
                "class Solution",
                "{",
                "    static void Main()",
                "    {",
                "        string outputPath = \"./solution.js\";",
                "        using (var writer = new StreamWriter(outputPath))",
                "        {",
                "            TextWriter originalConsole = Console.Out;",
                "            Console.SetOut(writer);",
                "        string[] csharpLines = {",
            };
            // Print JavaScript code header",
            Console.WriteLine("const fs = require(\'fs\');");
            Console.WriteLine("const file = fs.createWriteStream('Solution.cs');");
            Console.WriteLine("const lines = [");

            foreach (string line in csharpLines)
            {
                string escaped = line.Replace("\\", "\\\\").Replace("\"", "\\\"");
                Console.WriteLine($"  \"{escaped}\",");
            }
            Console.WriteLine("];");

            string[] additionalCSharpLines = {
                "        };",
                "",
                "        // Print JavaScript code header",
                "            Console.WriteLine(\"const fs = require(\'fs\');\");",
                "            Console.WriteLine(\"const file = fs.createWriteStream('Solution.cs');\");",
                "            Console.WriteLine(\"const lines = [\");",
                "",
                "        foreach (string line in csharpLines)",
                "        {",
                "            string escaped = line.Replace(\"\\\\\", \"\\\\\\\\\").Replace(\"\\\"\", \"\\\\\\\"\");",
                "            Console.WriteLine($\"  \\\"{escaped}\\\",\");",
                "        }",
                "",
                "        Console.WriteLine(\"];\");",
                "            string[] additionalCSharpLines = {",
            };
            Console.WriteLine("const additionalJsLines = [");

            foreach (string line in additionalCSharpLines)
            {
                string escaped = line.Replace("\\", "\\\\").Replace("\"", "\\\"");
                Console.WriteLine($"  \"{escaped}\",");
            }

            Console.WriteLine("];");
            Console.WriteLine();

            //for header
            Console.WriteLine("for (const line of lines) {");
            Console.WriteLine("    file.write(line + \"\\n\");");
            Console.WriteLine("}");
            //for 1st arry
            Console.WriteLine("for (const line of lines) {");
            Console.WriteLine("  file.write(\"\\\"\"+line.replace(/\\\\/g, '\\\\\\\\').replace(/\"/g, '\\\\\"') +\"\\\"\" +\",\\n\")");
            Console.WriteLine("}");
           
            //for middle
            Console.WriteLine("for (const line of additionalJsLines) {");
            Console.WriteLine("    file.write(line + \"\\n\");");
            Console.WriteLine("}");
            
            //for 2nd  array
            Console.WriteLine("for (const line of additionalJsLines) {");
            Console.WriteLine("  file.write(\"\\\"\"+line.replace(/\\\\/g, '\\\\\\\\').replace(/\"/g, '\\\\\"') +\"\\\"\" +\",\\n\")");
            Console.WriteLine("}");

            //Last part
            Console.WriteLine("file.write(\'};\\n}\\n}\\n}\\n\')");
        }
    }
}