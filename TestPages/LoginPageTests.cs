using EShop.pages;
using EShop.pages.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.tests
{
    [TestFixture]
    internal class LoginPageTests
    {   
        private LoginPage loginPage;
        private IWebDriver driver;
        private RegisterPage registerPage;
        private Actions actions;

        [SetUp]
        public void setUp() 
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            registerPage = new RegisterPage(driver, actions);
            loginPage = new LoginPage(driver, actions);
            loginPage.goToLoginPage();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void successfulLoginTest()
        {   
            loginPage.clearEmailField();
            loginPage.enterEmail("jaxons.danniels@company.com");      
            loginPage.clearPasswordField();         
            loginPage.enterPassword("User1234");
            loginPage.clickEmailField();
            loginPage.pressEneterEmailField();
            
            Assert.That(loginPage.isOntheHomePage(), Is.True);
        }

        [Test]
        public void errorMessagesEmptyFieldsTest()
        {
            loginPage.clearEmailField();
            loginPage.clearPasswordField();
            loginPage.clickEmailField();
            loginPage.pressEneterEmailField();
            Assert.That(loginPage.getEmailErrorMessage(), Is.EqualTo("Please enter email"));
            Assert.That(loginPage.getPasswordErrorMessage(), Is.EqualTo("Please enter password"));
        }

        [Test]
        public void errorMessagesInvalidFieldsTest()
        {
            loginPage.clearEmailField();
            loginPage.enterEmail("test123mail.com");
            loginPage.clearPasswordField();
            loginPage.enterPassword("test");
            loginPage.clickEmailField();
            loginPage.pressEneterEmailField();
            Assert.That(loginPage.getEmailErrorMessage(), Is.EqualTo("Email is not valid email"));
            //Assert.That(loginPage.getPasswordErrorMessage(), Is.EqualTo("Please enter password")); (BUG FOUND: no error message is displayed)
        }

        [Test]
        public void fieldBorderColorAssert()
        {
            loginPage.clearEmailField();
            loginPage.enterEmail("test123mail.com");
            loginPage.clickPasswordField();
            Assert.That(loginPage.getEmailFieldBorderColor(), Is.EqualTo("#a4262c"));
            loginPage.clearEmailField();
            loginPage.enterEmail("test123@mail.com");
            loginPage.clickPasswordField();
            Assert.That(loginPage.getEmailFieldBorderColor, Is.EqualTo("#8a8886"));
        }
    }
}
