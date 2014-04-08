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
            string path = "test.bin";
            Message msg = new Message(path);
            CollectionAssert.AllItemsAreNotNull(msg.bitMsg);
        }

        [TestMethod]
        public void initialPermutation()
        {
            Message msg = new Message("testowanie.bin");
            msg.initialPermutation();
            Message expected = new Message("expected.bin");

            CollectionAssert.AreEqual(expected.bitMsg, msg.bitMsg, "expected:" + expected.bitMsg.ToString() + "result:" + msg.bitMsg.ToString());
        }
    }
}
