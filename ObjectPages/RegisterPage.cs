using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V128.Page;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.pages
{
    public class RegisterPage : BasePage
    {
        private readonly By firstNameAndLastNameField = By.Id("FirstAndLastName");
        private readonly By emailField = By.Id("Email");
        private readonly By passwordField = By.Id("Password");
        private readonly By registerButton = By.XPath("//button[@class='k-button k-form-submit' and @type='submit']//span[text()='Register']");
        private readonly By firstNameAndLastNameErrorMessage = By.Id("FirstAndLastName-error");
        private readonly By emailErrorMessage = By.Id("Email-error");
        private readonly By passwordErrorMessage = By.Id("Password-error");
        private readonly By validationErrorMessage = By.XPath("/html/body/main/div/span");

        public RegisterPage(IWebDriver driver, Actions actions) : base(driver, actions) { }

        public void goToRegisterPage()
        {
            navigateTo("https://demos.telerik.com/kendo-ui/eshop/Account/Register");
        }

        public void enterFirstAndLastName(string FirstNameAndLastName)
        {
            sendTextToField(firstNameAndLastNameField, FirstNameAndLastName);
        }

        public void enterEmail(string email)
        {
            sendTextToField(emailField, email);
        }

        public void enterPassword(string password)
        {
            sendTextToField(passwordField, password);
        }

        public void clickOnRegisterButton()
        {
            clickOnElement(registerButton);
        }

        public bool isOnTheLoginPage()
        {
            return isOnThePage("https://demos.telerik.com/kendo-ui/eshop/Account/Login");
        }

        public string getEnterFirstNameAndLastNameErrorMessage()
        {
            return getElementText(firstNameAndLastNameErrorMessage);
        }

        public string getEmailErrorMessage()
        {
            return getElementText(emailErrorMessage);
        }

        public string getPasswordErrorMessage()
        {
            return getElementText(passwordErrorMessage);
        }

        public string getValidationErrorMessage()
        {
            return getElementText(validationErrorMessage);
        }

        public void clickEmailField()
        {
            clickOnElement(emailField);
        }

        public string getFirstNameAndLastNameFieldBorderColor()
        {
            return getPseudoElementStyle(firstNameAndLastNameField, "::after", "--INTERNAL--kendo-input-border");
        } 

        public void clearFistNameAndLastNameField()
        {
            clearField(firstNameAndLastNameField);
        }
    }
    }

