﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumCheckBoxDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCheckBoxDemo.Tests
{
    public class SeleniumCheckBoxObjects
    {
        private static SeleniumChekboxPage _seleniumCheckDemoPuslapis;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _seleniumCheckDemoPuslapis = new SeleniumChekboxPage(driver);

        }
        [Test]
        public static void OneCheckPatikrinimas()
        {
            _seleniumCheckDemoPuslapis.FirstCheckBox().AssertShownMessage("Success - Check box is checked");
        }

        //check all
        [Test]
        public static void MultiChecksPatikrinimas()
        {
            _seleniumCheckDemoPuslapis.ElemntsCheckAll().AssertShownMessageCheckAll("Uncheck All");
            // _seleniumCheckDemoPuslapis.FindElemntsUncheckAll("Uncheck All");
        }
        //uncheck all 
        [Test]
        public static void MultiUnChecksPatikrinimas()
        {

            _seleniumCheckDemoPuslapis.ElementuPatikrinimasPoMygtukoPaspaudimo();
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _seleniumCheckDemoPuslapis.CloseBrowser();
        }

    }
}
