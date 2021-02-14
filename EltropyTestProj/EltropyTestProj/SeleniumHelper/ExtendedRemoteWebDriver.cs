using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Structura.GuiTests.SeleniumHelpers
{
    public class ExtendedRemoteWebDriver : RemoteWebDriver, ITakesScreenshot
    {
        private readonly Uri _remoteHost;

        public ExtendedRemoteWebDriver(Uri remoteHost, ICapabilities capabilities, TimeSpan commandTimeout)
            : base(remoteHost, capabilities, commandTimeout)
        {
            _remoteHost = remoteHost;
        }

        //this will allow screenshots to be taken from the remote browser
        public Screenshot GetScreenshot()
        {
            return new Screenshot(Execute(DriverCommand.Screenshot, null).Value.ToString());
        }
    }
}