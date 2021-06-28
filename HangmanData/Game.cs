using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanData
{
    public class Game
    {
        private int MaxRetryCount = 5;
        public const string PlaceHolder = "-";

        private string _currentWord;

        private Word _word;

        public string CurrentWord { get; private set; }

        public int TryCount { get; private set; }

        public List<char> UsedLetters { get; private set; } = new List<char>();

        public string Country => _word.Country;

        public Game()
        {
            Restart();
        }

        public void Restart()
        {
            CurrentWord = "";
            TryCount = 0;
            UsedLetters.Clear();

            _word = GetRandomWord();

            //Console.WriteLine(_word.Capital);

            _currentWord = _word.Capital;

            foreach (var ch in _currentWord)
            {
                CurrentWord += PlaceHolder;
            }
        }

        public GuessResultEnum Guess(char letter)
        {
            var upperCaseLetter = letter.ToString().ToUpper()[0];

            if(UsedLetters.Contains(upperCaseLetter))
            {
                return GuessResultEnum.AlreadyUsed;
            }

            UsedLetters.Add(upperCaseLetter);

            if (!_currentWord.ToUpper().Contains(upperCaseLetter.ToString()))
            {
                if(TryCount >= MaxRetryCount)
                {
                    return GuessResultEnum.GameOver;
                }

                ++TryCount;

                return GuessResultEnum.Incorrect;
            }

            for (int i = 0; i < _currentWord.Length; i++)
            {
                if(_currentWord.ToUpper()[i] == upperCaseLetter)
                {
                    var array = CurrentWord.ToCharArray();
                    array[i] = upperCaseLetter;
                    CurrentWord = new string(array);
                }
            }

            return CurrentWord.Contains(PlaceHolder) ? GuessResultEnum.Guessed : GuessResultEnum.Won;
        } 

        private Word GetRandomWord()
        {
            var words = WordReader.GetWords();
            
            var rnd = new Random();
            var index = rnd.Next(0, words.Count());

            return words.ToArray()[index];
        }
    }
}
