using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace Shopping.UITests
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;
        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                .ApkFile ("../../../Shopping/Shopping.Droid/bin/Release/Shopping.Droid.apk")
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void FirsScreenButtonText()
        {
            Assert.AreEqual("Lista zakupów", app.Query("ShoppingListButton")[0].Text);
        }

        [Test]
        public void DisplayShoppingListButton()
        {
            app.Tap(app.Query("ShoppingListButton")[0].Text);
            app.WaitForElement(c => c.Marked("Dodaj"));
            Assert.AreEqual("Suma: ", app.Query("SumLabel")[0].Text);
            Assert.AreEqual("zł", app.Query("UnitLabel")[0].Text);
            Assert.AreEqual("Dodaj",app.Query("AddButton")[0].Text);
            Assert.AreEqual("Wyczyść liste", app.Query("ClearButton")[0].Text);
        }

        [Test]
        public void AddButtonClicked()
        {
            app.Tap(app.Query("ShoppingListButton")[0].Text);
            app.WaitForElement(c => c.Marked("Dodaj"));

            app.Tap(app.Query("AddButton")[0].Text);

            app.WaitForElement(c => c.Marked("NameLabel"), "Adding is taking too long", new TimeSpan(0, 0, 1, 0));
            Assert.AreEqual("Nazwa: ", app.Query("NameLabel")[0].Text);
            Assert.AreEqual("Rodzaj: ", app.Query("TypeLabel")[0].Text);
            Assert.AreEqual("Ilość: ", app.Query("CountLabel")[0].Text);
            Assert.AreEqual("Cena: ", app.Query("PriceLabel")[0].Text);
        }

        [Test]
        public void EditImageClicked()
        {
            app.Tap(app.Query("ShoppingListButton")[0].Text);
            app.WaitForElement(c => c.Marked("Dodaj"));

            var result = app.WaitForElement("EditImage");
            //if (result.Length > 0)
            {
                
                app.Tap(app.Query("EditImage")[0].Id);
                app.WaitForElement(c => c.Marked("SaveButton"));
            }
        }
    }
}

