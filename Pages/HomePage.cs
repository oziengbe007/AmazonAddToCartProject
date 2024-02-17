using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAddToCartProject.Pages
{
    internal class HomePage
    {
        private IWebDriver driver;

        public HomePage( IWebDriver driver)
        {
            this.driver = driver;
        }

        public SearchPage searchItem(string searchKey)
        {
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@name='field-keywords']")).SendKeys(searchKey);
            driver.FindElement(By.XPath("//*[@name='field-keywords']")).SendKeys(Keys.Enter);
            return new SearchPage(driver);
        }




    }
}
