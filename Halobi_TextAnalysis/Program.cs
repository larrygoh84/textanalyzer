using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halobi_TextAnalysis
{
    public class Word
    {
        public string word;
        public int count;
    }

    class Program
    {
        static List<Word> Words = new List<Word>();

        static void Main(string[] args)
        {
            //ReadFile(args[0]);

            ReadFile(args[0]);

            if (File.Exists(args[1]))
            {
                File.Delete(args[1]);
            }

            foreach (Word w in Words.OrderByDescending(x => x.count).ThenByDescending(x => x.word))
            {
                if (w.word.Length > 0)
                {
                    //Console.WriteLine(w.word + " " + w.count.ToString());
                    using (StreamWriter file = new StreamWriter(args[1], true))
                    {
                        file.WriteLine(w.word + " " + w.count.ToString());
                    }
                }
            }

            Console.ReadKey();


        }

        public static void ReadFile(string path)
        {
            string[] readText = File.ReadAllLines(path);

            foreach (string s in readText)
            {
                string[] ws = s.Split(' ');

                foreach (string w in ws)
                {

                    Word word = Words.Where(x => x.word == w).FirstOrDefault();

                    if (word == null)
                    {
                        Words.Add(new Word() { word = w, count = 1 });
                    }
                    else
                    {
                        word.count++;
                    }
                }


            }
           
        }
    }
}
