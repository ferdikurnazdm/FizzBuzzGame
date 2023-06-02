using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace FizzBuzzGame.Tester
{
    [TestClass]
    public class FizzBuzzGameTester
    {
        FizzBuzzTemplate fbtemp = new FizzBuzzTemplate();
        int[] buffer = new int[150];
        int StartNumber = 1;
        int EndNumber = 100;
        int res = 100;

        public FizzBuzzGameTester()
        {
            fbtemp.FizBuzzOutputEvent += Fbtemp_FizBuzzOutputEvent;
        }

        private void Fbtemp_FizBuzzOutputEvent(object sender, FizBuzzOutputEventArgs e)
        {
            buffer[int.Parse(e.FizzBuzzOutput)]=int.Parse(e.FizzBuzzOutput);
        }

        [TestMethod]
        public void FizzBuzz_play_test()
        {
            fbtemp.Play(StartNumber, EndNumber);
            for (int i = StartNumber; i <= EndNumber; i++)
            {
                if (i != buffer[i])
                {
                    Assert.Fail();
                    return;
                }
                Assert.AreEqual(true, true);
            }
        }

        [TestMethod]
        public void FizzBuzz_Check_zero_test()
        {
            bool result = fbtemp.CheckZero(StartNumber, EndNumber);
        }

        [TestMethod]
        public void FizzBuzz_check_fizz_state()
        {
            int number = 1;
            string result = fbtemp.CheckFizzBuzzState(number);
            if (result=="Fizz"||result=="Buzz"||result=="FizzBuzz")
            {
                Assert.Fail();
            }
            number= 3;
            result = fbtemp.CheckFizzBuzzState(number);
            if (result == "3" || result == "Buzz" || result == "FizzBuzz")
            {
                Assert.Fail();
            }
            number = 5;
            result = fbtemp.CheckFizzBuzzState(number);
            if (result == "Fizz" || result == "5" || result == "FizzBuzz")
            {
                Assert.Fail();
            }
            number = 15;
            result = fbtemp.CheckFizzBuzzState(number);
            if (result == "Fizz" || result == "Buzz" || result == "15")
            {
                Assert.Fail();
            }
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void FizzBuzz_game_stop()
        {
            int number = 54;
            fbtemp.Play(1,number);
            
            fbtemp.GameStop = true;
            Assert.AreEqual((number + 1), fbtemp.counter);
        }
    }






    public class FizzBuzzTemplate
    {
        public delegate void FizzBuzzOutput(object sender, FizBuzzOutputEventArgs e);
        public event FizzBuzzOutput FizBuzzOutputEvent;
        private event EventHandler _gameStopEvent;
        FizBuzzOutputEventArgs fizEventArgs;
        string result;
        public int counter;
        int startNumber;
        int endNumber;

        public FizzBuzzTemplate()
        {
            fizEventArgs = new FizBuzzOutputEventArgs();
            this._gameStopEvent += FizzBuzzTemplate_gameStopEvent;
        }



        public void Play(int startNumber, int endNumber)
        {
            this.startNumber= startNumber;
            this.endNumber= endNumber;
            for (counter = startNumber; counter <= endNumber; counter++)
            {
                fizEventArgs.FizzBuzzOutput = counter.ToString();
                this.FizBuzzOutputEvent?.Invoke(this, fizEventArgs);
            }
        }

        public bool CheckZero(int StartNUmber, int EndNumber)
        {
            if (StartNUmber > 0 && EndNumber > 0)
            {
                return true;
            }
            return false;
        }

        public string CheckFizzBuzzState(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                result = "FizzBuzz";
                return result;
            }
            if (number%5 == 0)
            {
                result = "Buzz";
                return result;
            }
            if (number%3 == 0)
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
                if (value==true)
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
