﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationFrameWork.Base.TestEventListener;
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

namespace AutomationTesting
{


    public class TestITestListener
    {
        [Category("Capture Element Image")]
        [Test]
        public void Event ()
        {
            ChromeOptions op = new ChromeOptions();
            op.EnableMobileEmulation("Apple iPhone 4");
            //DriverFactory.Instance.DriverOption = op;
            DriverFactory.Instance.StartDriver(DriverType.Chrome, true);
            IWebDriver driver = DriverFactory.Instance.GetWebDriver;
            driver.Url = "https://www.whatismybrowser.com/";
            IWebElement el = driver.FindElement(By.XPath("//*[@id='holder']//*[@class='detection-primary content-block']"));
            WebKeywords.Instance.GetScreenShot();
            Utilities.Instance.GetWebElementBaseImage(el, formatType: System.Drawing.Imaging.ImageFormat.Jpeg);
            driver.Dispose();
            DriverFactory.Instance.CloseDriver();
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
        [Category("Context")]
        public void TestContextFind ()
        {
           

            Func<int, int, bool, string> something =(a,b,c)=> string.Format("string = {0} and {1}", a+b, c);

            Console.WriteLine(something.Invoke(12,22,true));
            Console.WriteLine(something);IWebElement el = null;
            var wait = new OpenQA.Selenium.Support.UI.DefaultWait<IWebElement>(el);
            wait.Until(element =>
            {
                return element.Displayed;
            });
            IWebDriver driver=null;driver.FindElements(new ByChained(By.Id(""),By.XPath(""),By.ClassName("")));
        }
        #endregion
    }
}