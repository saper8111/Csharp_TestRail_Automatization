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

namespace GoogleSearchTests
{
    [TestFixture]
    public class GoogleSearchTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        //public static String RESULT_ID = "880";
        //public static String TEST_RUN_ID = "288";
        //public static String TESTRAIL_USERNAME = "Vyacheslav.Kozhurov@dhl.ru";
        //public static String TESTRAIL_PASSWORD = "1xVixA7Ug7q4Ys1di36M";
        //public static String RAILS_ENGINE_URL = "https://dhlru.testrail.io/";
        //public static int TEST_CASE_PASSED_STATUS = 1;
        //public static int TEST_CASE_FAILED_STATUS = 5;
        //public static string comment;


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
            OpenHomePage();
            InitInputValue();
            SearchData data = new SearchData("test");
            FillSearchForm(data);
            SubmitSearchForm();
            Assert.AreEqual(data, driver.FindElement(By.Name("q")).GetAttribute("value"));
            //String actualAttribute = driver.FindElement(By.Name("q")).GetAttribute("value");
            AddResultInTestRail(new TestRailData("323", "232323"));



            //if (actualAttribute.Contains("test"))
            //{
            //    GoogleSearchTests.addResultForTestCase("", comment, TEST_CASE_PASSED_STATUS, "");
            //}

            //else
            //{
            //    GoogleSearchTests.addResultForTestCase("", comment, TEST_CASE_FAILED_STATUS, "");
            //}

        }

        private void AddResultInTestRail(TestRailData data)
        {
            AuthTestRail auth = new AuthTestRail("");
            auth.User = "";
            auth.Password = "";
           





        }

        private void SubmitSearchForm()
        {
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
        }

        private void FillSearchForm(SearchData data)
        {
            driver.FindElement(By.Name("q")).SendKeys(data.Value);
        }

        private void InitInputValue()
        {
            driver.FindElement(By.Name("q")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public static void addResultForTestCase(String TEST_CASE_ID, String comment, int status, String error)
        {


            //TEST_CASE_ID = "2538";
            //APIClient client = new APIClient();
            //client.Url = "";
            //client.User = "";
            //client.Password = "";

           

            

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



            //JObject c = (JObject)client.SendGet("get_case/" + TEST_CASE_ID);
            //Console.WriteLine(c);



            //client.SendPost("add_result_for_case/" + TEST_RUN_ID + "/" + TEST_CASE_ID, data);


            //client.SendPost("add_attachment_to_result/" + RESULT_ID, "C:\\Users\\vkozhuro\\Desktop\\SearchInGoogle.png");





        }
        

        

        
    }
}
