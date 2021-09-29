using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            // EvenLines();
            // LineNumbers();
            // WordCount();
            // CopyBinaryFile();
            // DirectoryTraversal();
            // ZipFile();
        }

        private static void ZipFile()
        {
            System.IO.Compression.ZipFile.CreateFromDirectory("../../../Resources", "../../../archived.zip");
            System.IO.Compression.ZipFile.ExtractToDirectory("../../../archived.zip", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }

        private static void DirectoryTraversal()
        {
            string[] files = Directory.GetFiles("../../../");
            Dictionary<string, Dictionary<string, double>>
                fileExtensions = new Dictionary<string, Dictionary<string, double>>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = new FileInfo(files[i]);
                string extension = Path.GetExtension(files[i]);
                string fileName = Path.GetFileName(files[i]);
                double sizeKB = file.Length / 1024.0;
                if (!fileExtensions.ContainsKey(extension))
                {
                    fileExtensions.Add(extension, new Dictionary<string, double>());
                }

                fileExtensions[extension].Add(fileName, sizeKB);
            }

            foreach (var fileExtension in fileExtensions.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
            {
                sb.AppendLine(fileExtension.Key);
                foreach (var file in fileExtension.Value.OrderBy(f => f.Value))
                {
                    sb.AppendLine($"--{file.Key} - {file.Value:f3}kb");
                }
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dest = Path.Combine(desktopPath, "report.txt");
            File.WriteAllText(dest, sb.ToString());
        }


        private static void CopyBinaryFile()
        {
            FileStream fs = new FileStream("../../../copyMe.png", FileMode.Open);
            FileStream fsCopyTo = new FileStream("../../../copied.png", FileMode.Create);
            fs.CopyTo(fsCopyTo);
        }



        private static void WordCount()
        {
            string[] words = File.ReadAllLines("../../../words.txt");
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string[] lines = File.ReadAllLines("../../../text.txt");
            List<string> toPrint = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("-", "");
                lines[i] = lines[i].Replace(",", "");
                lines[i] = lines[i].Replace(".", "");
                lines[i] = lines[i].Replace("!", "");
                lines[i] = lines[i].Replace("?", "");
            }

            foreach (var word in words)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] lineArr = lines[i].Split();
                    for (int j = 0; j < lineArr.Length; j++)
                    {
                        if (String.Compare(word, lineArr[j], StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            if (!wordsCount.ContainsKey(word))
                            {
                                wordsCount.Add(word, 0);
                            }

                            wordsCount[word]++;
                        }
                    }
                }
            }

            foreach (var i in wordsCount)
            {
                string result = $"{i.Key} - {i.Value}";
                toPrint.Add(result);
            }

            File.AppendAllLines("../../../actualResult.txt", toPrint);
            wordsCount = wordsCount.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);
            toPrint.Clear();
            foreach (var i in wordsCount)
            {
                toPrint.Add($"{i.Key} - {i.Value}");
            }

            File.AppendAllLines("../../../expectedResult.txt", toPrint);
        }



        private static void LineNumbers()
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            int puncCount = 0;
            int letterCount = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                letterCount = lines[i].Count(c => char.IsLetter(c));
                puncCount = lines[i].Count(c => char.IsPunctuation(c));
                lines[i] = lines[i].Insert(0, $"Line {i + 1} ");
                lines[i] = lines[i].Insert(lines[i].Length, $" ({letterCount})({puncCount})");
            }

            File.WriteAllLines("../../../output.txt", lines);
        }



        private static void EvenLines()
        {
            string[] specialSymbols = {"-", ",", ".", "!", "?"};
            StreamReader readText = new StreamReader("../../../text.txt");
            int counter = 0;
            while (!readText.EndOfStream)
            {
                string line = readText.ReadLine();
                if (counter++ % 2 == 0)
                {
                    foreach (var specialSymbol in specialSymbols)
                    {
                        line = line.Replace(specialSymbol, "@");
                    }

                    Console.WriteLine(string.Join(" ", line.Split().Reverse()));
                }
            }
        }
    }
}
