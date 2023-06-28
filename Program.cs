
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using static System.Collections.Specialized.BitVector32;

namespace FSW_new
{
    internal class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            WindowsDriver<WindowsElement> FSW;
            AppiumOptions desiredCapabilities = new AppiumOptions();

            desiredCapabilities.AddAdditionalCapability("app", @"C:\Program Files (x86)\ReSound\SmartFit\SmartFitSA.exe");
            desiredCapabilities.AddAdditionalCapability("appWorkingDir", @"C:\Program Files (x86)\ReSound\SmartFit");
            FSW = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/"), desiredCapabilities);
            Thread.Sleep(15000);

            FSW.SwitchTo().Window(FSW.WindowHandles[0]);
            WebDriverWait wait = new WebDriverWait(FSW, TimeSpan.FromSeconds(100));
            var div2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("Add New Patient")));
            div2.Click();

            FSW.SwitchTo().Window(FSW.WindowHandles[0]);
            var Fn = FSW.FindElementByAccessibilityId("StandAloneAutomationIds.ProfileAutomationIds.FirstNameField");
            Fn.SendKeys("Session");
            var Ln = FSW.FindElementByAccessibilityId("StandAloneAutomationIds.ProfileAutomationIds.LastNameField");
            Ln.SendKeys("A");
            FSW.FindElementByAccessibilityId("StandAloneAutomationIds.DetailsAutomationIds.AudiogramAction").Click();

            var parentId = FSW.FindElementByAccessibilityId("WindowAutomationIds.StandAloneShell");
            Actions qq = new Actions(FSW);
            ReadOnlyCollection<AppiumWebElement> listBox = (ReadOnlyCollection<AppiumWebElement>)parentId.FindElementsByClassName("TextBlock");
            for (int i = 115; i <= 123; i++)
            {
                qq.MoveToElement(listBox.ElementAt(listBox.Count - i)).Click().SendKeys("60").Perform();
            }
            FSW.FindElementByAccessibilityId("StandAloneAutomationIds.AudiogramAutomationIds.CopyRightAction").Click();
            FSW.FindElementByName("Save").Click();
            FSW.FindElementByAccessibilityId("StandAloneAutomationIds.DetailsAutomationIds.FitAction").Click();
            desiredCapabilities.AddAdditionalCapability("app", @"C:\Program Files (x86)\ReSound\SmartFit\SmartFit.exe");
            WindowsDriver<WindowsElement> FSWsmart = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/"), desiredCapabilities);
            Thread.Sleep(10000);
            WebDriverWait Continue = new WebDriverWait(FSWsmart, TimeSpan.FromSeconds(100));

            FSWsmart.SwitchTo().Window(FSWsmart.WindowHandles[0]);
            while (FSWsmart.FindElementByName("Smart Launcher").Displayed)
            {
                FSWsmart.SwitchTo().Window(FSWsmart.WindowHandles[0]);
                FSWsmart.FindElementByAccessibilityId("ConnectionAutomationIds.CommunicationInterfaceItems").Click();
                FSWsmart.FindElementByAccessibilityId("ConnectionAutomationIds.CommunicationInterfaceItemsAutomationIds.FittingDongle").Click();
                FSWsmart.FindElementByAccessibilityId("ConnectionAutomationIds.ConnectAction").Click();
                break;
            }
            string SN = " RT962-DRW s/n: 2000800267";


            var div3 = Continue.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("Search")));

            do
            {

                FSWsmart.SwitchTo().Window(FSWsmart.WindowHandles[0]);
                var parentID1 = FSWsmart.FindElementByAccessibilityId("WindowAutomationIds.Shell");
                var dk = parentID1.FindElementByClassName("ListBox");
                ReadOnlyCollection<AppiumWebElement> listBox1 = (ReadOnlyCollection<AppiumWebElement>)dk.FindElementsByClassName("ListBoxItem");

                foreach (var element in listBox1)
                {
                    Console.WriteLine(element.Text);

                    if (element.Text == SN)
                    {

                        element.FindElementByName("Assign Left").Click();
                        FSWsmart.SwitchTo().Window(FSWsmart.WindowHandles[0]);
                        //FSWsmart.FindElementByName("Continue").Click();
                        int j;
                        for (j = 1; j <= 3; j++)
                        {
                            FSWsmart.SwitchTo().Window(FSWsmart.WindowHandles[0]);
                            //Thread.Sleep((int)j);

                            var div4 = Continue.Until(ExpectedConditions.ElementToBeClickable(By.Name("Continue")));
                            FSWsmart.SwitchTo().Window(FSWsmart.WindowHandles[0]);
                            div4.Click();

                        }

                        FSWsmart.SwitchTo().Window(FSWsmart.WindowHandles[0]);
                        Thread.Sleep(5000);
                        FSWsmart.FindElementByAccessibilityId("ProgramStripAutomationIds.AddProgramAction").Click();
                        var mus = FSWsmart.FindElementByName("Music");
                        mus.Click();
                        //Thread.Sleep(3000);
                        FSWsmart.FindElementByAccessibilityId("ProgramStripAutomationIds.AddProgramAction").Click();
                        var Out = FSWsmart.FindElementByName("Outdoor");
                        Out.Click();
                        FSWsmart.FindElementByAccessibilityId("ProgramStripAutomationIds.AddPhoneNowAction").Click();
                        var Acoustic = FSWsmart.FindElementByName("Acoustic Phone");
                        Acoustic.Click();
                        FSWsmart.FindElementByAccessibilityId("FittingAutomationIds.GainAutomationIds.TargetMultiplierItems").Click();
                        var Percent = FSWsmart.FindElementByAccessibilityId("FittingAutomationIds.GainAutomationIds.TargetMultiplierItemsAutomationIds.80");
                        Percent.Click();
                        FSWsmart.FindElementByAccessibilityId("FittingAutomationIds.SaveAction").Click();

                        FSWsmart.FindElementByAccessibilityId("SkipButton").Click();
                        //Thread.Sleep(10000);
                        WebDriverWait wait2 = new WebDriverWait(FSWsmart, TimeSpan.FromSeconds(100));
                        var div6 = wait2.Until(ExpectedConditions.ElementToBeClickable(By.Name("Exit ReSound Smart Fit")));
                        div6.Click();

                        FSWsmart.FindElementByName("Exit ReSound Smart Fit").Click();

                        break;


                    }


                }





                //} while (!FSWsmart.FindElementByName("The current fitting session has been saved.").Displayed);
            } while (FSWsmart.FindElementByName("Search").Displayed == true);
        }
    }
}
