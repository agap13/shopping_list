using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace Shopping.UITests
{
    [TestFixture]
    public class UITests
    {
        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                .ApkFile("../../../Shopping/Shopping.Droid/bin/Release/Shopping.Droid.apk")
                .StartApp();
        }

        private AndroidApp app;

        [Test]
        public void AddButtonClicked()
        {
            app.Tap(app.Query("ShoppingListButton")[0].Text);
            app.WaitForElement(c => c.Marked("Dodaj"));

            app.Tap(app.Query("AddButton")[0].Text);

            app.WaitForElement(c => c.Marked("NameLabel"), "Timeout", new TimeSpan(0, 0, 1, 0));
            Assert.AreEqual("Nazwa: ", app.Query("NameLabel")[0].Text);
            Assert.AreEqual("Rodzaj: ", app.Query("TypeLabel")[0].Text);
            Assert.AreEqual("Ilość: ", app.Query("CountLabel")[0].Text);
            Assert.AreEqual("Cena: ", app.Query("PriceLabel")[0].Text);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void DisplayShoppingListButton()
        {
            app.Tap(app.Query("ShoppingListButton")[0].Text);
            app.WaitForElement(c => c.Marked("Dodaj"));
            Assert.AreEqual("Suma: ", app.Query("SumLabel")[0].Text);
            Assert.AreEqual("zł", app.Query("UnitLabel")[0].Text);
            Assert.AreEqual("Dodaj", app.Query("AddButton")[0].Text);
            Assert.AreEqual("Wyczyść liste", app.Query("ClearButton")[0].Text);
        }

        [Test]
        public void FirstScreenButtonText()
        {
            Assert.AreEqual("Lista zakupów", app.Query("ShoppingListButton")[0].Text);
        }
    }
}