using System;
using System.IO;

class Program
{
    
    static void Main(string[] args) {
    
        Console.WriteLine("Paste your data (logins, password-patterns etc.) with SPACE as a separator:");
        string[] Phrases = Console.ReadLine().Split(' ');
        
        string Passwords = null;
        const string DictionaryPath = @"D:/ExampleFolder/ExampleDictinary.lst"; //! Full path to your dictionary
        
        try
        {
            using(StreamReader sr = new StreamReader(DictionaryPath, false))
            {
                string line;
                Console.WriteLine("Parsing...\n\n");
                while((line = sr.ReadLine()) != null)
                {
                    foreach(string Phrase in Phrases)
                    {
                        if(line.Contains(Phrase))
                        {
                            Console.WriteLine(line);
                            Passwords += (line + "\n");
                        }
                    }
                }
                Console.WriteLine("\n\nEnd of parsing.");                                   
            }
            using(StreamWriter sw = new StreamWriter(@"OUTPUT.txt"))
            {
                sw.Write(Passwords);
                Console.WriteLine("Output file created.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
