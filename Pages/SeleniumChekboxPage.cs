using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCheckBoxDemo.Pages
{
    class SeleniumChekboxPage : BasicPage
    {
        private IWebElement _singleCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _textAfterClick => Driver.FindElement(By.Id("txtAge"));
        //private IWebElement _CheckBox3 => Driver.FindElement(By.CssSelector(".checkbox:nth-child(3) .cb1-element"));
        //private IWebElement _CheckBox4 => Driver.FindElement(By.CssSelector(".checkbox:nth-child(4) .cb1-element"));
        //private IWebElement _CheckBox5 => Driver.FindElement(By.CssSelector(".checkbox:nth-child(5) .cb1-element"));
        //private IWebElement _CheckBox6 => Driver.FindElement(By.CssSelector(".checkbox:nth-child(6) .cb1-element"));

        private IReadOnlyCollection<IWebElement> _cheks => Driver.FindElements(By.ClassName("cb1-element"));
        private IWebElement _buttonCheck1 => Driver.FindElement(By.XPath("//*[@id='check1']"));

        public SeleniumChekboxPage(IWebDriver inputDriver) : base(inputDriver)
        {
            Driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        }

        public SeleniumChekboxPage FirstCheckBox()
        {
            _singleCheckBox.Click();
            return this;
        }

        public SeleniumChekboxPage AssertShownMessage(string expectedMessage)
        {
            string message = _textAfterClick.Text;
            Assert.AreEqual(expectedMessage, message, "Pranesimas nesutampa");
            return this;
        }

        //-----------------Multiple Checkbox Demo--------------------

        public SeleniumChekboxPage ElemntsCheckAll()
        {
            foreach (IWebElement check in _cheks)
            {
                check.Click();
            }
            return this;
            //string actualResult = _buttonCheck1.GetAttribute("value");

            //Assert.AreEqual(expectedResult, actualResult, $"Turejo buti mygtukas su tekstu {expectedResult} o gavome - {actualResult} ");
        }
        public SeleniumChekboxPage AssertShownMessageCheckAll(string expectedResult)
        {

            string actualResult = _buttonCheck1.GetAttribute("value");

            Assert.AreEqual(expectedResult, actualResult, $"Turejo buti mygtukas su tekstu {expectedResult} o gavome - {actualResult} ");
            return this;
        }
        public SeleniumChekboxPage ElementuPatikrinimasPoMygtukoPaspaudimo()
        {
            
            if (_buttonCheck1.GetAttribute("value") == "Check All")
                           ElemntsCheckAll();
                       
            {
                _buttonCheck1.Click();
                int i = 1;
                foreach (IWebElement element in _cheks)
                {
                    Assert.AreEqual(false, element.Selected, $"Tikejomes kad elementas {i} ne pažymėtas, o gavome - kad pažymėtas");
                    i++;
                }
            }
            return this;
        }
    }
}
