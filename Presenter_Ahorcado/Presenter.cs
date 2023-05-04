using Domain_Ahorcado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter_Ahorcado
{
    public class Presenter
    {
        private readonly Ahorcado _ahorcado;
        private readonly IView _view;

        public Presenter(IView view)
        {
            _ahorcado = new Ahorcado();
            _view = view;
        }

        #region "Use Cases"

        public void CallStartSound()
        {
            _ahorcado.CallStartSound();
        }

        public int GetBodyParts()
        {
            return _ahorcado.BodyParts();
        }

        public String GetWord()
        {
            return _ahorcado.RandomWord();
        }

        public int GetNumberOfGuesses()
        {
            return _ahorcado.GetNumberOfGuesses();
        }

        public void CheckAddLetter(String letter)
        {
            if (!_ahorcado.CheckLetter(letter))
            {
                _ahorcado.IncreaseBodyParts();
                _ahorcado.DecreaseNumberOfGuesses();
                _view.Show_text("Esa letra no está");
            }
            else
            {
                _ahorcado.LetterOK(letter);
                _view.Show_text("Acertaste la letra");
            }
        }

        public void AddUsed(String letra)
        {
            _ahorcado.AddUsed(letra);
        }

        public List<string> GetUsedLetters()
        {
            return _ahorcado.UsedLetters();
        }

        public String[] GetLettersGuessed()
        {
            return _ahorcado.GetLettersGuessed();
        }

        public string DisplayWord()
        {
            return _ahorcado.DisplayWord();
        }

        public bool YouWin()
        {
            if (_ahorcado.YouWin())
            {
                return true;
            }
            return false;
        }

        public void YouLose()
        {
            _ahorcado.YouLose();
        }

        #endregion
    }
}
