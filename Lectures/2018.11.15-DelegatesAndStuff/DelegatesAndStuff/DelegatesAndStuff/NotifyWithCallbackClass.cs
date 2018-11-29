using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesAndStuff
{
    [TestClass]
    public class NotifyWithCallbackClass
    {

        [TestMethod]
        public void Callback_GivenCallackClass()
        {
            Callback callback = new Callback();
            ButtonWithDelegates button = new ButtonWithDelegates("Ok");
            button.Register(callback);
            button.Click();
            Assert.IsTrue(callback.Called);
        }
    }
}
