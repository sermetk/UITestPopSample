using NUnit.Framework;
using System;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinUITestPopSample.UITests.Base
{
    public static class ActExtension
    {
        public static void TapAndWait(this IApp app, Func<AppQuery, AppQuery> query, params Func<AppQuery, AppQuery>[] elementToWait)
        {
            app.Tap(query);
            foreach (var element in elementToWait)
            {
                var queryResult = app.WaitForElement(element);
                if (queryResult?.FirstOrDefault()?.Class == "UILabel" || queryResult?.FirstOrDefault()?.Class == "FormsTextView") //iOS: UILabel, Android: FormsTextView
                {
                    Assert.IsFalse(string.IsNullOrEmpty(queryResult?.FirstOrDefault()?.Text), $"{element.ToString()} textfield is null");
                }
                app.Screenshot(element + "SS");
            }
        }

        public static void TaskAndWait(this IApp app, Action action, Func<AppQuery, AppQuery> elementToWait)
        {
            action.Invoke();
            var queryResult = app.WaitForElement(elementToWait);
            if (queryResult?.FirstOrDefault()?.Class == "UILabel" || queryResult?.FirstOrDefault()?.Class == "FormsTextView")
            {
                Assert.IsFalse(string.IsNullOrEmpty(queryResult?.FirstOrDefault()?.Text), $"{elementToWait.ToString()} textfield is null");
            }
            app.Screenshot(elementToWait + "SS");
        }
        public static void EnterTextAndWait(this IApp app, Func<AppQuery, AppQuery> query, string input, Func<AppQuery, AppQuery> firingButton, Func<AppQuery, AppQuery> elementToWait, bool clearText = true)
        {
            app.EnterText(query, input);
            app.DismissKeyboard();
            app.Tap(firingButton);
            app.WaitForElement(elementToWait);
            app.Screenshot(elementToWait + "SS");
            if (clearText)
                app.ClearText(query);
            app.DismissKeyboard();
        }
    }
}