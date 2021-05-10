using System;
using System.IO;

namespace FileOperations
{
    class Program
    {
        private static string path1 = Directory.GetCurrentDirectory();
        static void Main(string[] args)
        {
            Directory.CreateDirectory(Path.Combine(path1, @"..\..\..\Lyrics"));
            //Set path
            var path2 = Path.GetFullPath(Path.Combine(path1, @"..\..\..\Lyrics"));
            File.WriteAllText($@"{path2}\Wonderwall.txt", "some wonderwall lyrics");

            //ReadAllText (path=string)
            string lyrics = File.ReadAllText($@"{path2}\Wonderwall.txt");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(lyrics);
            Console.Beep();

            //WriteAllText(path=string, content=string)
            File.WriteAllText(path2 + @"\ChampageNova.txt", "Some day you will find me");

            //WriteAllLines(path=string, content=string[])
            string[] lyrics2 = {"So", "Sally", "Can", "Wait" };
            File.WriteAllLines(path2 + @"\Don'tLookBackInAnger.txt", lyrics2);

            //Check if file exists
            if (!File.Exists(path2 + @"\MyLyrics.txt"))
            {
                string[] lyrics3 = { "Uzair", "was", "here", ":)" };
                File.WriteAllLines(path2 + @"\MyLyrics.txt", lyrics3);
            }

            //Read lines to return string array
            string[] readText = File.ReadAllLines(path2 + @"\MyLyrics.txt");
            foreach (var line in readText)
            {
                Console.WriteLine(line);
            }

            //Appending text
            string appendText = "And I'm Happy";
            File.AppendAllText(path2 + @"\MyLyrics.txt", appendText);

            //Copy
            File.WriteAllText(path2 + @"\OldLyrics.txt", "Hey Now, I'm an Allstar");
            var oldLyricsPath = path2 + @"\OldLyrics.txt";
            var newLyricsPath = path2 + @"\NewLyrics.txt";
            //Do not override using false.
            File.Copy(oldLyricsPath, newLyricsPath, false);

            //Delete a file
            File.Delete(oldLyricsPath);

            //Date of creation and modifcation
            DateTime lastWriteTime = File.GetLastWriteTime(newLyricsPath);
            DateTime creationTime = File.GetCreationTime(newLyricsPath);

            //File info
            var fileInfo = new FileInfo(newLyricsPath);
            var directory = fileInfo.Directory;
            var extension = fileInfo.Extension;

            //////////////FOLDER//////////////////////

            //Get files recursively in a folder
            var fileArray = Directory.GetFiles(path2);
            foreach (var item in fileArray)
            {
                Console.WriteLine(item);
            }

            //Delete folder
            Directory.Delete(path2,true);
        }
    }
}
