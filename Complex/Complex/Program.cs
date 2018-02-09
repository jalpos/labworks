using System;
using System.IO;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)

        {
            string s = Console.ReadLine();
            DirectoryInfo directory = new DirectoryInfo(s);
            FileSystemInfo[] ab = directory.GetFileSystemInfos();
            foreach (FileSystemInfo a in ab)
            {
                if (a.GetType() == typeof(DirectoryInfo))
                {
                    Console.BackgroundColor = ConsoleColor.Green;

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(a.Name);

                    
                
            }

  
             
        }
    }
}
















