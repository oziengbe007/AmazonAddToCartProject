using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAddToCartProject.Pages
{
    internal class ProductPage
    {
        private IWebDriver driver;
        string price;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CartSummaryPage ClickAddToCartButton()
        {
            // Wait for the "Add to Cart" button to be clickable
            var addToCartButton = driver.FindElement(By.Id("add-to-cart-button"));
            addToCartButton.Click();
            return new CartSummaryPage(driver);
        }

    }
}
