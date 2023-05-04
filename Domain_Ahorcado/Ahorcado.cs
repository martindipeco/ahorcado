using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media; //to add SoundPlayer class *.WAV files in Windows only
//using System.Windows.Extensions; 

namespace Domain_Ahorcado
{
    public class Ahorcado
    {
        private static string[] words = { "nave", "alien", "planeta", "estrella", "galaxia", 
            "satelite", "astronauta", "exploracion", "orbita", "telescopio", "cometa", "meteorito", 
            "eclipse", "cosmos", "espacio", "gravedad", "luna", "marte", "nebulosa", "sistema", 
            "nuclear", "tierra", "cohete", "mision" };

        private static Random random = new Random();

        private static int randomNumber = random.Next(words.Length);
        private static String randomWord = words[randomNumber];

        private int numberOfGuesses = 6;
        private int bodyParts = 0;

        private String[] guessedLetters = new String[randomWord.Length];

        List<string> usedLetters = new List<string>();

        SoundPlayer soundYouLose = new SoundPlayer(@"Sonidos\evilLaugh.wav");
        SoundPlayer soundYouWin = new SoundPlayer(@"Sonidos\win.wav");
        SoundPlayer soundLetterOK = new SoundPlayer(@"Sonidos\right.wav");
        SoundPlayer soundLetterWrong = new SoundPlayer(@"Sonidos\wrong.wav");
        SoundPlayer soundStart = new SoundPlayer(@"Sonidos\start.wav");

        

        public Ahorcado()
        {
            int randomNumber = random.Next(words.Length);
            String randomWord = words[randomNumber];
            String[] guessedLetters = new String[randomWord.Length];
            int numberOfGuesses = 6;
            int bodyParts = 0;
        }

        public void CallStartSound()
        {
            soundStart.Play();
        }

        public int BodyParts() { return bodyParts; }

        public String RandomWord()
        {
            return randomWord;
        }

        public int GetNumberOfGuesses()
        {
            return numberOfGuesses;
        }

        public void DecreaseNumberOfGuesses()
        {
            numberOfGuesses--;
        }

        public void IncreaseBodyParts()
        {
            bodyParts++;
        }

        public bool CheckLetter(String letter)
        {
            if (letter.Length == 1 && char.IsLetter(letter[0]))
            {
                if (randomWord.Contains(letter))
                {
                    soundLetterOK.Play();
                    return true;
                }
            }
            soundLetterWrong.Play();
            return false;
        }

        public String[] GetLettersGuessed()
        {
            return guessedLetters;
        }

        public void AddUsed(String letra)
        {
            usedLetters.Add(letra);
        }

        public List<String> UsedLetters()
        {
            return usedLetters;
        }

        public void LetterOK(String letra)
        {
            guessedLetters[randomWord.IndexOf(letra)] = letra;
        }

        public string DisplayWord()
        {
            string word = "";

            for (int i = 0; i < randomWord.Length; i++)
            {
                if (Array.IndexOf(guessedLetters, randomWord[i].ToString()) != -1)
                {
                    word += randomWord[i];
                }
                else
                {
                    word += "_";
                }
            }
            return word;
        }

        public bool YouWin()
        {
            if (DisplayWord() == randomWord)
            {
                // set all attributes to default
                randomNumber = random.Next(words.Length);
                randomWord = words[randomNumber];
                numberOfGuesses = 6;
                bodyParts = 0;
                guessedLetters = new String[randomWord.Length];
                usedLetters = new List<string>();

                soundYouWin.Play();

                return true;
            }
            return false;
        }

        public void YouLose()
        {
            // set all attributes to default
            randomNumber = random.Next(words.Length);
            randomWord = words[randomNumber];
            numberOfGuesses = 6;
            bodyParts = 0;
            guessedLetters = new String[randomWord.Length];
            usedLetters = new List<string>();

            soundYouLose.Play();
        }
    }
}
