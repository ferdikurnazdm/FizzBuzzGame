using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzGame
{
    public class FizzBuzzGameBase
    {
        public delegate void FizzBuzzOutput(object sender, FizBuzzOutputEventArgs e);
        public event FizzBuzzOutput FizBuzzOutputEvent;
        private event EventHandler _gameStopEvent;
        FizBuzzOutputEventArgs fizEventArgs;
        string result;
        int counter;
        int startNumber;
        int endNumber;

        public FizzBuzzGameBase()
        {
            fizEventArgs = new FizBuzzOutputEventArgs();
            this._gameStopEvent += FizzBuzzTemplate_gameStopEvent;
        }




        public void Play(int startNumber, int endNumber)
        {
            bool range = CheckZero(startNumber, endNumber);
            if (range == false)
            {
                return;
            }
            this.startNumber = startNumber;
            this.endNumber = endNumber;
            for (int i = startNumber; i <= endNumber; i++)
            {
                fizEventArgs.FizzBuzzOutput = CheckFizzBuzzState(i);
                this.FizBuzzOutputEvent?.Invoke(this, fizEventArgs);
            }
        }
        private bool CheckZero(int StartNUmber, int EndNumber)
        {
            if (StartNUmber > 0 && EndNumber > 0)
            {
                return true;
            }
            return false;
        }
        private string CheckFizzBuzzState(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                result = "FizzBuzz";
                return result;
            }
            if (number % 5 == 0)
            {
                result = "Buzz";
                return result;
            }
            if (number % 3 == 0)
            {
                result = "Fizz";
                return result;
            }
            return number.ToString();
        }
        private void FizzBuzzTemplate_gameStopEvent(object sender, EventArgs e)
        {
            counter = endNumber + 1;
        }




        public bool GameStop
        {
            set
            {
                if (value == true)
                {
                    this._gameStopEvent?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
    public class FizBuzzOutputEventArgs : EventArgs
    {
        private string _output;
        public string FizzBuzzOutput
        {
            get
            {
                return _output;
            }
            set
            {
                _output = value;
            }
        }
    }
}
