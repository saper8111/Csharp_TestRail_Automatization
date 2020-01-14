using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace google_search
{
    [TestFixture]
    public class GoogleSearchTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        public static String RESULT_ID = "880";
        public static String TEST_RUN_ID = "288";
        public static String TESTRAIL_USERNAME = "Vyacheslav.Kozhurov@dhl.ru";
        public static String TESTRAIL_PASSWORD = "1xVixA7Ug7q4Ys1di36M";
        public static String RAILS_ENGINE_URL = "https://dhlru.testrail.io/";
        public static int TEST_CASE_PASSED_STATUS = 1;
        public static int TEST_CASE_FAILED_STATUS = 5;
        public static string comment;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.ru/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void GoogleSearchTest()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("q")).Clear();
            driver.FindElement(By.Name("q")).SendKeys("test");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            Assert.AreEqual("test", driver.FindElement(By.Name("q")).GetAttribute("value"));
            String actualAttribute = driver.FindElement(By.Name("q")).GetAttribute("value");
            if (actualAttribute.Contains("test"))
            {
                GoogleSearchTestCase.addResultForTestCase("", comment, TEST_CASE_PASSED_STATUS, "");
            }

            else
            {
                GoogleSearchTestCase.addResultForTestCase("", comment, TEST_CASE_FAILED_STATUS, "");
            }

        }



        public static void addResultForTestCase(String TEST_CASE_ID, String comment, int status, String error)
        {


            TEST_CASE_ID = "2538";
            APIClient client = new APIClient(RAILS_ENGINE_URL);

            client.User = TESTRAIL_USERNAME;
            client.Password = TESTRAIL_PASSWORD;

            if (status != 1)
            {
                comment = "NET";
            }

            else
            {
                comment = "DA";
            }

            var data = new Dictionary<string, object>
            {
                { "status_id", status },
                { "comment", comment }
            };



            client.SendPost("add_result_for_case/" + TEST_RUN_ID + "/" + TEST_CASE_ID, data);

            client.SendPost("add_attachment_to_result/" + RESULT_ID, "C:\\Users\\vkozhuro\\Desktop\\SearchInGoogle.png");





        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
