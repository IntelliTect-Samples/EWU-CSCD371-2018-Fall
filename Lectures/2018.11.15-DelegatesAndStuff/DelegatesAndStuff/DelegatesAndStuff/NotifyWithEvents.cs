using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DelegatesAndStuff
{
    [TestClass]
    public class NotifyWithEvents
    {
        public bool Called { get; set; }
        public void Notify(object sender, EventArgs args)
        {
            Called = true;
        }

        [TestMethod]
        public void Callback_GivenTwoDelegate()
        {
            Callback callback = new Callback();
            Button button = new Button("Ok");
            button.CallbackAction += callback.Notify;
            button.CallbackAction += Notify;
            button.Click();
            Assert.IsTrue(callback.Called);
            Assert.IsTrue(Called);
        }

        [TestMethod]
        public void Notify_GivenLambdaExpression_Success()
        {
            Button button = new Button("Ok");
            bool called = false;

            EventHandler notify = 
                (sender, args) => { called = true; };

            button.CallbackAction += notify;
            button.CallbackAction += 
                (sender, args) => { called = true; };

            button.Click();
            Assert.IsTrue(called);
        }
    }
}
