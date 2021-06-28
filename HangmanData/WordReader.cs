using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HangmanData
{
    public class WordReader
    {
        public static IEnumerable<Word> GetWords()
        {
           var lines = File.ReadAllLines("list.txt");

            var words = new List<Word>();

            foreach (var line in lines)
            {
                var parts = line.Split(";");

                words.Add(new Word()
                {
                    Country = parts[0],
                    Capital = parts[1]
                });
            }

            return words;
        }
    }
}
