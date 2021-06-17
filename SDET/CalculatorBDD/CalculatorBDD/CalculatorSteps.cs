using System;
using TechTalk.SpecFlow;
using CalculatorLib;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorBDD
{
    [Binding]
    public class CalculatorSteps
    {
        private Calculator _calculator;
        private int _result;
        private string _exceptionMessage;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _calculator = new Calculator();
        }
        
        [Given(@"I enter (.*) and (.*) into the calculator")]
        public void GivenIEnterAndIntoTheCalculator(int a, int b)
        {
            _calculator.Num1 = a;
            _calculator.Num2 = b;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }

        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            _result = _calculator.Subtract();
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            _result = _calculator.Multiply();
        }

        [When(@"I press divide")]
        public void WhenIPressDivide()
        {
            try
            {
                _result = _calculator.Divide();
            }
            catch (Exception ex)
            {
                _exceptionMessage = ex.Message;
            }
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            Assert.That(_result, Is.EqualTo(expected));
        }

        [Then(@"an exception message ""(.*)"" should be thrown")]
        public void ThenAnExceptionMessageShouldBeThrown(string exceptionMessage)
        {
            Assert.That(_exceptionMessage, Is.EqualTo(exceptionMessage));
        }

        [Given(@"I enter the numbers below to a list")]
        public void GivenIEnterTheNumbersBelowToAList(Table table)
        {
            var numList = new List<int>();
            foreach (var row in table.Rows)
            {
                numList.Add(int.Parse(row[0]));
            };
            _calculator.NumList = numList;
        }

        [When(@"I iterate through the list to add all the even numbers")]
        public void WhenIIterateThroughTheListToAddAllTheEvenNumbers()
        {
            _result = _calculator.SumOfEvenNumbersInList();
        }
    }
}
