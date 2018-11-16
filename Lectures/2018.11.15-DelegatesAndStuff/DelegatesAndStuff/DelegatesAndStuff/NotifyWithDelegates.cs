using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DelegatesAndStuff
{
    [TestClass]
    public class NotifyWithDelegates
    {


        [TestMethod]
        public void Callback_GivenCallackDelegate()
        {
            Callback callback = new Callback();
            ButtonWithDelegates button = new ButtonWithDelegates("Ok");
            button.Register(callback.Notify);
            button.Click();
            Assert.IsTrue(callback.Called);
        }
        public bool Called { get; set; }
        public void Notify()
        {
            Called = true;
        }

        [TestInitialize]
        public void Initialize()
        {
            Called = false;
        }

        [TestMethod]
        public void Notify_GivenDelegate_Success()
        {
            ButtonWithDelegates button = new ButtonWithDelegates("Ok");
            button.Register(Notify);
            button.Click();
            Assert.IsTrue(Called);
        }

        [TestMethod]
        public void Callback_GivenTwoDelegate()
        {
            Callback callback = new Callback();
            ButtonWithDelegates button = new ButtonWithDelegates("Ok");
            button.Register(callback.Notify);
            button.Register(Notify);
            button.Click();
            Assert.IsTrue(callback.Called);
            Assert.IsTrue(Called);
        }

        [TestMethod]
        public void Notify_GivenLambdaExpression_Success()
        {
            ButtonWithDelegates button = new ButtonWithDelegates("Ok");
            bool called = false;

            void Notify() { called = true; }

            button.Register(Notify);
            button.Click();
            Assert.IsTrue(called);
        }

    }
}
