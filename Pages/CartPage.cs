using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAddToCartProject.Pages
{
    internal class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetProductPrice()
        {
            var priceElement = driver.FindElement(By.XPath("//div[@class='a-section a-spacing-mini']//span[@class='a-size-medium a-color-base sc-price sc-white-space-nowrap sc-product-price a-text-bold']"));
            return priceElement.Text;
        }
    }
}
