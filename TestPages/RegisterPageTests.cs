using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.pages;
using EShop.pages.utils;
using OpenQA.Selenium.Interactions;

namespace EShop.tests
{
    [TestFixture]
    public class RegisterPageTests
    {
        private IWebDriver driver;
        private RegisterPage registerPage;
        private Actions actions;

        [SetUp]
        public void SetUp()
        {          
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            registerPage = new RegisterPage(driver, actions);
            registerPage.goToRegisterPage();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void successfulRegisterTest()
        {
            registerPage.enterFirstAndLastName("Test Test");
            registerPage.enterEmail(RandomStringGenerator.generateRandomAlphanumeric(8) + "@mail.com");
            registerPage.enterPassword("Password123");
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.isOnTheLoginPage(), Is.True);
        }

        [Test]
        public void errorMessagesEmptyFieldsTest()
        {
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.getEnterFirstNameAndLastNameErrorMessage(), Is.EqualTo("Please enter First and Last name"));
            Assert.That(registerPage.getEmailErrorMessage(), Is.EqualTo("Email is required"));
            Assert.That(registerPage.getPasswordErrorMessage(), Is.EqualTo("Please enter password"));
        }
       
        [Test]
        public void errorMessagesInvalidFieldsTest()
        {
            registerPage.enterFirstAndLastName("TestTest");
            registerPage.enterEmail("test123.mail.com");
            registerPage.enterPassword("test");
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.getEnterFirstNameAndLastNameErrorMessage(), Is.EqualTo("Please enter First and Last name separated by a space"));
            Assert.That(registerPage.getEmailErrorMessage(), Is.EqualTo("Email is not valid email"));
            Assert.That(registerPage.getPasswordErrorMessage(), Is.EqualTo("Your password must be at least 8 symbols and should include uppercase and lowercase letters and numbers."));
        }

        [Test]
        public void unsuccessfulRegisterUserAlreadyExistsTest()
        {
            registerPage.enterFirstAndLastName("Test Test");
            registerPage.enterEmail("test123@mail.com");
            registerPage.enterPassword("Password123");
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.getValidationErrorMessage(), Is.EqualTo("User already exists."));
        }

        [Test]
        public void fieldBorderColorTest()
        {
            registerPage.enterFirstAndLastName("TestTest");
            registerPage.clickEmailField();
            Assert.That(registerPage.getFirstNameAndLastNameFieldBorderColor(), Is.EqualTo("#a4262c"));
            registerPage.clearFistNameAndLastNameField();
            registerPage.enterFirstAndLastName("Test Test");
            registerPage.clickEmailField();
            Assert.That(registerPage.getFirstNameAndLastNameFieldBorderColor(), Is.EqualTo("#8a8886"));
        }
    }
}

