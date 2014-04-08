namespace Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BSK2;

    [TestClass]
    public class MsgTest
    {
        [TestMethod]
        public void loadMsg()
        {
            string path ="test.bin";
            Message msg = new Message(path);
            CollectionAssert.AllItemsAreNotNull(msg.bitMsg);

        }
    }
}
