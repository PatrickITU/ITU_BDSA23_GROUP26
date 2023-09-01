using System.Reflection;
using System;
using System.IO;

 class Program
{
    static void Main(string[] args)
{
    string cvsPath = "../Data/chirp_cli_db.csv";
    if (!File.Exists(cvsPath)){
        Console.WriteLine("CVS FILE NOT FOUND");
        Console.WriteLine(Directory.GetCurrentDirectory());
        return;
    }

    using (var reader = new StreamReader(cvsPath)){
        while(!reader.EndOfStream){
            var line = reader.ReadLine();
            Console.WriteLine(line);
        }
    }
}
}