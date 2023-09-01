using System.Reflection;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

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
        var line = reader.ReadLine();
        while(!reader.EndOfStream){
            
            line = reader.ReadLine();
            var regexHandler = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            var cvsArray = regexHandler.Split(line);
            cvsArray[1] = cvsArray[1].Substring(1,cvsArray[1].Length - 2);
            var timeOfChirp = cvsArray[2];
            DateTimeOffset addedTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse((timeOfChirp)));
            var convertedTime = addedTime.LocalDateTime;
            Console.WriteLine(cvsArray[0] + " @ " + convertedTime + ": " + cvsArray[1]);
        }
    }
}
}