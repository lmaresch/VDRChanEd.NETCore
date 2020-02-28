using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDRChanEd.NETCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VDRChanEd.NETCore.Tests
{
    [TestClass()]
    public class HelperTests
    {
        [TestMethod()]
        public void SplitParametersTest1()
        {
            Dictionary<char, string> parts = Helper.SplitParameters("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length, parts.Count);
        }

        [TestMethod()]
        public void SplitParametersTest2()
        {
            string testString = "AB1C2D3E4F5G6H7I8J9K10L11M12N13O14P15Q16R17S18T19U20V21W22X23Y24Z25";
            Dictionary<char, string> parts = Helper.SplitParameters(testString);
            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length, parts.Count);
        }

        [TestMethod()]
        public void GetUniqueKeysTest1()
        {
            Dictionary<char, string> lhs = new Dictionary<char, string>();
            Dictionary<char, string> rhs = new Dictionary<char, string>();
            lhs.Add('A', "10");
            lhs.Add('B', "12");
            rhs.Add('B', "12");
            rhs.Add('C', "10");
            Dictionary<char, char> temp = new Dictionary<char, char>();
            Assert.IsFalse(Helper.AreOnlySameItemsinDicts(lhs, rhs, ref temp));
            Assert.IsTrue(temp.ContainsKey('A'));
            Assert.IsTrue(temp.ContainsKey('C'));
            Assert.AreEqual('r', temp['A']);
            Assert.AreEqual('l', temp['C']);
        }

        public void GetUniqueKeysTest2()
        {
            Dictionary<char, string> lhs = new Dictionary<char, string>();
            Dictionary<char, string> rhs = new Dictionary<char, string>();
            lhs.Add('B', "12");
            rhs.Add('B', "12");
            Dictionary<char, char> temp = new Dictionary<char, char>();
            Assert.IsTrue(Helper.AreOnlySameItemsinDicts(lhs, rhs, ref temp));
            Assert.AreEqual(0, temp.Count);
        }

        [TestMethod()]
        public void AreAllItemsEqualTest1()
        {
            Dictionary<char, string> lhs = new Dictionary<char, string>();
            Dictionary<char, string> rhs = new Dictionary<char, string>();
            lhs.Add('A', "10");
            lhs.Add('B', "12");
            rhs.Add('B', "12");
            rhs.Add('A', "11");
            Dictionary<char, KeyValuePair<string, string>> diffItems = new Dictionary<char, KeyValuePair<string, string>>();
            Assert.IsFalse(Helper.AreAllItemsEqual(lhs, rhs, ref diffItems));
            Assert.IsTrue(diffItems.ContainsKey('A'));
            Assert.IsFalse(diffItems.ContainsKey('B'));
            Assert.AreEqual(new KeyValuePair<string, string>("10", "11"), diffItems['A']);
        }

        [TestMethod()]
        public void AreAllItemsEqualTest2()
        {
            Dictionary<char, string> lhs = new Dictionary<char, string>();
            Dictionary<char, string> rhs = new Dictionary<char, string>();
            lhs.Add('A', "10");
            lhs.Add('B', "12");
            rhs.Add('B', "12");
            rhs.Add('A', "10");
            Dictionary<char, KeyValuePair<string, string>> diffItems = new Dictionary<char, KeyValuePair<string, string>>();
            Assert.IsTrue(Helper.AreAllItemsEqual(lhs, rhs, ref diffItems));
            Assert.AreEqual(0, diffItems.Count);
        }

        [TestMethod()]
        public void GetSourcesValueFromStringTest()
        {
            foreach (Sources expected in Enum.GetValues(typeof(Sources)))
            {
                Sources actual = Helper.GetSourcesValueFromString(expected.ToString().Replace('_', '.'));
                Assert.AreEqual(expected, actual, "Actual source <" + actual.ToString() + "> is not equal to expected source <" + expected.ToString() + ">.");
            }
        }
    }
}