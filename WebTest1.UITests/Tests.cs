using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace WebTest1.UITests
{
	[TestFixture]
	public class Tests
	{
		iOSApp app;
	
		const string API_KEY = "b43f68b08956789bba6788339c844ebc";
		const string DEVICE_WIFI_IP = "172.31.98.128";
		const string BUNDLE_IDENTIFIER = "com.xamarin.WebTest1";


		[SetUp]
		public void BeforeEachTest ()
		{
			//app = ConfigureApp.iOS.StartApp ();
			app = ConfigureApp.iOS.InstalledApp (BUNDLE_IDENTIFIER).ApiKey (API_KEY).DeviceIp (DEVICE_WIFI_IP).StartApp ();
		}

		[Test]
		public void EnteringTextAndClickingButtonShouldUpdateHeaderText ()
		{
			app.EnterText (c => c.Css ("#textbox"), "Test");
			app.Tap (c => c.Css ("input[type=button]"));

			AppWebResult[] results = app.WaitForElement (c => c.XPath ("//h1[text()=\"C# says: Test\"]"));
			app.Screenshot ("Header text updated.");

			Assert.IsTrue (results.Any ());
		}
	}
}