using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AnswerDigitalAdvancedAutomationTest
{
    class Program
    {
        IWebDriver driver = new ChromeDriver();

        static void Main(string[] args)
        {
        }

        [Test]
        public void TestCase1()
        {
            // User story: As a user if there is an item already inside my basket, I want to be able to delete the item from the basket page so that I can see the basket is empty.
            var clickTshirts = "/html/body/div/div[1]/header/div[3]/div/div/div[6]/ul/li[3]/a";
            var addToCart = "/html/body/div/div[2]/div/div[3]/div[2]/ul/li/div/div[2]/div[2]/a[1]";
            var closeAlert = "/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[1]/span";
            var goToCart = "/html/body/div/div[1]/header/div[3]/div/div/div[3]/div/a";
            var noProduct = "ajax_cart_no_product";
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.XPath(clickTshirts)).Click();
            ScrollDown();
            driver.FindElement(By.XPath(addToCart)).Click();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.XPath(closeAlert)).Click();
            ScrollUp();
            driver.FindElement(By.XPath(goToCart)).Click();
            var cartItem = driver.FindElement(By.ClassName("cart_product")).Displayed;
            var deleteButton = driver.FindElement(By.ClassName("icon-trash"));
            
            //Prove item is in cart
            Assert.IsTrue(cartItem);

            //Delete Button Present
            Assert.IsNotNull(deleteButton);
            deleteButton.Click();

            //Item has been deleted
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(noProduct)));
            var emptyCart = driver.FindElement(By.ClassName(noProduct)).Text;
            Assert.AreEqual("(empty)", emptyCart);

            //Banner displays "Your shopping cart is empty."
            var emptyCartMessage = driver.FindElement(By.ClassName("alert-warning")).Text;
            Assert.AreEqual("Your shopping cart is empty.", emptyCartMessage);
                
        }

        [Test]
        public void TestCase2()
        {
            // User Story: As a user I want to select The 'Summer Dresses' option from the navigation menu, so that i can view an item from the summer collection
            GoToSummerDresses();

            //Summer items only display inside the search results
            var summerDressTitle = "/html/body/div/div[2]/div/div[3]/div[2]/h1/span[1]";
            var correctPage = driver.FindElement(By.XPath(summerDressTitle)).Text;
            Assert.AreEqual("SUMMER DRESSES ", correctPage);
        }

        [Test]
        public void TestCase3()
        {
            // User Story: As a user when searching for a summer dress, I want to change the proce range to $16-$20 so that I can see the search results change
            var sliderTab = "/html/body/div/div[2]/div/div[3]/div[1]/div[1]/div[1]/form/div/div[9]/ul/div/div/a[2]";

            GoToSummerDresses();
            IWebElement slider = driver.FindElement(By.XPath(sliderTab));
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            ScrollDown();
            //Slider changes the price
            action.ClickAndHold(slider).MoveByOffset(-142, 0).Release(slider).Build().Perform();
            // Search results are updated
            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id());
            // Items returned are within the price range
            
        }

        [Test]
        public void TestCase4HappyPath()
        {
            // User Story: As a user I want to create a new account so that I can start buying items using my personal account.

            string loginButtonID = "login";
            string correctEmail = "Ga4rcia@hotmail.co.uk";
            string incorrectEmail = "Garciahotmail.co.uk";
            string createEmailTabID = "email_create";
            string invalidEmailAlertID = "create_account_error";
            string accountCreationForm = "account-creation_form";
            string genderButtonID = "id_gender1";
            string firstName = "Makyra";
            string firstNameID = "customer_firstname";
            string lastName = "Malcolkm";
            string lastNameID = "customer_lastname";
            string password = "garcia";
            string passwordTabID = "passwd";
            string dayOfBirthID = "days";
            string monthOfBirthID = "months";
            string yearOfBirthID = "years";
            string firstNameAddressID = "firstname";
            string lastNameAddressID = "lastname";
            string addressID = "address1";
            string address = "7434 Wall Triana Hwy";
            string cityID = "city";
            string city = "Madison";
            string stateID = "id_state";
            string postcodeID = "postcode";
            string postcode = "35757";
            string mobilePhoneID = "phone_mobile";
            string mobilePhoneNumber = "256-617-3804";
            string registerButtonID = "submitAccount";
            string navigationPageID = "navigation_page";
            string accountNameXpath = "/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a/span";

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            Actions action = new Actions(driver);

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.ClassName(loginButtonID)).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(createEmailTabID)));
            driver.FindElement(By.Id(createEmailTabID)).SendKeys(incorrectEmail + Keys.Return);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(invalidEmailAlertID)));
            driver.FindElement(By.Id(createEmailTabID)).Clear();

            // Invalid Information will give an error message
            Assert.IsTrue(driver.FindElement(By.Id(invalidEmailAlertID)).Displayed);

            driver.FindElement(By.Id(createEmailTabID)).SendKeys(correctEmail + Keys.Return);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(accountCreationForm)));
            driver.FindElement(By.Id(genderButtonID)).Click();
            driver.FindElement(By.Id(firstNameID)).SendKeys(firstName);
            driver.FindElement(By.Id(lastNameID)).SendKeys(lastName);
            driver.FindElement(By.Id(passwordTabID)).SendKeys(password);
            driver.FindElement(By.Id(dayOfBirthID)).SendKeys("12");
            driver.FindElement(By.Id(monthOfBirthID)).SendKeys("April");
            driver.FindElement(By.Id(yearOfBirthID)).SendKeys("1990");
            driver.FindElement(By.Id(firstNameAddressID)).SendKeys(firstName);
            driver.FindElement(By.Id(lastNameAddressID)).SendKeys(lastName);
            driver.FindElement(By.Id(addressID)).SendKeys(address);
            driver.FindElement(By.Id(cityID)).SendKeys(city);
            IWebElement stateDropDown = driver.FindElement(By.Id(stateID));
            action.ClickAndHold(stateDropDown).SendKeys(Keys.ArrowDown + Keys.Enter).Release(stateDropDown).Build().Perform();
            driver.FindElement(By.Id(postcodeID)).SendKeys(postcode);
            driver.FindElement(By.Id(mobilePhoneID)).SendKeys(mobilePhoneNumber);
            driver.FindElement(By.Id(registerButtonID)).Click();

            // Completing registration will take user to 'MY ACCOUNT' page
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(navigationPageID)));
            string pageHeader = driver.FindElement(By.ClassName(navigationPageID)).Text;
            Assert.AreEqual("My account", pageHeader);

            // User can see account name on top right
            var expectedAccountName = driver.FindElement(By.XPath(accountNameXpath)).Text;
            Assert.AreEqual(expectedAccountName, firstName + " " + lastName);
        }

        [Test]
        public void TestCase4UnhappyPath()
        {
            // User Story: As a user I want to create a new account so that I can start buying items using my personal account.

            string loginButtonID = "login";
            string correctEmail = "Ga6rcia@hotmail.co.uk";
            string incorrectEmail = "Garciahotmail.co.uk";
            string createEmailTabID = "email_create";
            string invalidEmailAlertID = "create_account_error";
            string registerButtonID = "submitAccount";
            string accountCreationForm = "account-creation_form";
            string alertMessageXpath = "/html/body/div/div[2]/div/div[3]/div/div/p";
            string expectedAlertMessageText = "There are 8 errors";

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            Actions action = new Actions(driver);

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.ClassName(loginButtonID)).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(createEmailTabID)));
            driver.FindElement(By.Id(createEmailTabID)).SendKeys(incorrectEmail + Keys.Return);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(invalidEmailAlertID)));

            // Invalid Information will give an error message
            Assert.IsTrue(driver.FindElement(By.Id(invalidEmailAlertID)).Displayed);
            driver.FindElement(By.Id(createEmailTabID)).SendKeys(correctEmail + Keys.Return);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(accountCreationForm)));
            driver.FindElement(By.Id(registerButtonID)).Click();

            // Form can only accept valid information
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(alertMessageXpath)));
            var actualAlertMeassage = driver.FindElement(By.XPath(alertMessageXpath)).Text;
            Assert.AreEqual(expectedAlertMessageText, actualAlertMeassage);
        }

        public void GoToSummerDresses()
        {
            var womenTab = " / html / body / div / div[1] / header / div[3] / div / div / div[6] / ul / li[1] / a";
            var summerDressTab = "/html/body/div/div[1]/header/div[3]/div/div/div[6]/ul/li[1]/ul/li[2]/ul/li[3]/a";

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            //On mouse-hover button 'WOMAN', sub navigation options will appear
            var women = driver.FindElement(By.XPath(womenTab));
            Actions action = new Actions(driver);
            action.MoveToElement(women).Perform();
            driver.FindElement(By.XPath(summerDressTab)).Click();
        }

        public void ScrollDown()
        {
            IJavaScriptExecutor scriptExecutor = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(1000);
            scriptExecutor.ExecuteScript("window.scrollBy(0,1000);");
        }

        public void ScrollUp()
        {
            IJavaScriptExecutor scriptExecutor = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(1000);
            scriptExecutor.ExecuteScript("window.scroll(900,0);");
        }
    }
}
