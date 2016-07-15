﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using NUnit.Engine;
using AutomationFrameWork.Driver;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using AutomationFrameWork.Utils;
using AutomationFrameWork.ActionsKeys;
using System.Web.UI;
using System.IO;
using AutomationFrameWork.Extensions;
using System.Collections.ObjectModel;
using Mono.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using AutomationFrameWork.Driver.Factory;

namespace AutomationTesting
{
    [TestFixture(Browser.ChromeDesktop,FactoryType.WebBrowserFactory)]
    [TestFixture(Browser.iPad,FactoryType.WebBrowserFactory)]
    [TestFixture(Browser.FirefoxDesktop, FactoryType.WebBrowserFactory)]
    [TestFixture(Browser.InternetExplorerDesktop, FactoryType.WebBrowserFactory)]
    [TestFixture(Browser.iPhone4, FactoryType.WebBrowserFactory)]
    [TestFixture(Browser.iPhone5, FactoryType.WebBrowserFactory)]
    [TestFixture(Browser.iPhone6, FactoryType.WebBrowserFactory)]
    [TestFixture(Browser.Nexus6, FactoryType.WebBrowserFactory)]
    [TestFixture(Browser.Nexus7, FactoryType.WebBrowserFactory)]
    [Parallelizable(ParallelScope.Self)]
    public class TestITestListener
    {
        public TestITestListener(Browser browserType,FactoryType factoryType)
        {
            _type = browserType;
            _factory = factoryType;
        }
        Browser _type;
        FactoryType _factory;
        object driverType;
        IWebDriver driver;       
        [Category("Capture Element Image")]
        [Test]
        public void Event ()
        {
            ChromeOptions op = new ChromeOptions();
            op.EnableMobileEmulation("Apple iPhone 4");
            //DriverFactory.Instance.DriverOption = op;          
            DriverManager<IWebDriver>.StartDriver(FactoryType.WebBrowserFactory, Browser.ChromeDesktop);
            IWebDriver driver = DriverManager<IWebDriver>.Driver;
            driver.Url = "https://www.whatismybrowser.com/";
            IWebElement el = driver.FindElement(By.XPath("//*[@id='holder']//*[@class='detection-primary content-block']"));
            WebKeywords.Instance.GetScreenShot();
            Utilities.Instance.GetWebElementBaseImage(el, formatType: System.Drawing.Imaging.ImageFormat.Jpeg);
            driver.Dispose();
            DriverManager<IWebDriver>.CloseDriver();
        }
        [Category("TestReportTemplate")]
        [Test]
        public void CreateHTML ()
        {
            string FullPage = string.Empty;
            var strWr = new StringWriter();
            using (var writer = new HtmlTextWriter(strWr))
            {
                writer.Write("<!DOCTYPE html>");
                writer.AddAttribute(HtmlTextWriterAttribute.Id,"Test");
                writer.RenderBeginTag(HtmlTextWriterTag.Head);
                writer.AddAttribute("http-equiv", "X-UA-Compatible");
                writer.AddAttribute("content", @"IE=edge");
                writer.AddAttribute("charset", "utf-8");
                writer.RenderBeginTag(HtmlTextWriterTag.Meta);
                writer.RenderEndTag();
                writer.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
                writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/css");
                writer.AddAttribute(HtmlTextWriterAttribute.Href, @"D:\WorkSpace\Git\AutomationFramework\AutomationFramework\Base\Reporter\EmbeddedResources\Primer\primer.css");
                writer.RenderBeginTag(HtmlTextWriterTag.Link);
                writer.RenderEndTag();
                writer.NewLine = "\r\n";
                writer.AddAttribute(HtmlTextWriterAttribute.Id, "Div 1");              
                writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.AddAttribute(HtmlTextWriterAttribute.Id, "testname");
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.RenderBeginTag(HtmlTextWriterTag.H1);
                writer.Write("Test this show in html page");                
                writer.NewLine = "\r\n";
                writer.RenderEndTag();        
                writer.RenderEndTag();
                writer.RenderEndTag();
                writer.RenderEndTag();               
                writer.Write("</html>");        
            }
            FullPage = strWr.ToString();
            File.WriteAllText(@"C:\Users\Minh\Desktop\New folder\TestReport.html", FullPage);
        }
        #region
        //Test FindContext
        [Test]
        [Parallelizable(ParallelScope.Self)]
        [Category("Context")]
        public void TestContextFind()
        {
            //IDriver<IWebDriver> test = new ChromeDesktop { Driver= new ChromeDesktop().StartDriver()};

            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.google.com";
            driver.Navigate().GoToUrl("http://vtc.vn");
            driver.Navigate().Back();
            driver.FindElement(OpenQA.Selenium.By.Id("lst-ib")).SendKeys("test this show with long string ");

            driver.FindElement(OpenQA.Selenium.By.Id("lst-ib")).Clear();

            driver.FindElement(OpenQA.Selenium.By.Id("lst-ib")).SendKeys("test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string  test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string test this show with long string ");

            driver.Quit();
        }

        #endregion
        [Test]        
        [Category("WebDriverListner")]
        public void TestFactory()
        {
            
            IWebDriver driver = new FirefoxDriver();           
            driver = new EventFiringWebDriver(driver);
            ((EventFiringWebDriver)driver).Navigated+= new EventHandler<WebDriverNavigationEventArgs>(EventFiringInstance_Navigated);
            ((EventFiringWebDriver)driver).FindingElement += new EventHandler<FindElementEventArgs>(ClickEvent);
            driver.Url = "http://www.google.com";
            driver.FindElement(OpenQA.Selenium.By.Id("lst-ib"));        
            driver.Quit();
        }
        private void EventFiringInstance_Navigated(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine(sender.ToString());
            Console.WriteLine("Test: "+e.Url);       
        }
        private void ClickEvent(object sender, FindElementEventArgs e)
        {
            Console.WriteLine(e.FindMethod.ToString());
        }
        [Test]
        [Category("TestListner")]
        public void TestAddIn()
        {
           
        }
    }
}
