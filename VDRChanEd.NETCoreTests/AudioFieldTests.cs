using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDRChanEd.NETCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VDRChanEd.NETCore.Tests
{
    [TestClass()]
    public class AudioFieldTests
    {
        [TestMethod()]
        public void SplitToAnalogAndDigitalPartsTest1()
        {
            string analogPart = string.Empty;
            string digitalPart = string.Empty;
            string expectedAnalogPart = string.Empty;
            string expectedDigitalPart = string.Empty;
            string audioLine = expectedAnalogPart + (string.IsNullOrEmpty(expectedDigitalPart) ? string.Empty : ";" + expectedDigitalPart);
            AudioField af = new AudioField();
            af.SplitToAnalogAndDigitalParts(audioLine, ref analogPart, ref digitalPart);
            Assert.AreEqual(expectedAnalogPart, analogPart);
            Assert.AreEqual(expectedDigitalPart, digitalPart);
        }

        [TestMethod()]
        public void SplitToAnalogAndDigitalPartsTest2()
        {
            string analogPart = string.Empty;
            string digitalPart = string.Empty;
            string expectedAnalogPart = "101,102";
            string expectedDigitalPart = "103,104";
            string audioLine = expectedAnalogPart + (string.IsNullOrEmpty(expectedDigitalPart) ? string.Empty : ";" + expectedDigitalPart);
            AudioField af = new AudioField();
            af.SplitToAnalogAndDigitalParts(audioLine, ref analogPart, ref digitalPart);
            Assert.AreEqual(expectedAnalogPart, analogPart);
            Assert.AreEqual(expectedDigitalPart, digitalPart);
        }

        [TestMethod()]
        public void SplitToAnalogAndDigitalPartsTest3()
        {
            string analogPart = string.Empty;
            string digitalPart = string.Empty;
            string expectedAnalogPart = "101=deu,102=eng";
            string expectedDigitalPart = "103=deu,104=eng";
            string audioLine = expectedAnalogPart + (string.IsNullOrEmpty(expectedDigitalPart) ? string.Empty : ";" + expectedDigitalPart);
            AudioField af = new AudioField();
            af.SplitToAnalogAndDigitalParts(audioLine, ref analogPart, ref digitalPart);
            Assert.AreEqual(expectedAnalogPart, analogPart);
            Assert.AreEqual(expectedDigitalPart, digitalPart);
        }

        [TestMethod()]
        public void SplitToAnalogAndDigitalPartsTest4()
        {
            string analogPart = string.Empty;
            string digitalPart = string.Empty;
            string expectedAnalogPart = "101=deu,102=eng+spa";
            string expectedDigitalPart = "103=deu,104=eng";
            string audioLine = expectedAnalogPart + (string.IsNullOrEmpty(expectedDigitalPart) ? string.Empty : ";" + expectedDigitalPart);
            AudioField af = new AudioField();
            af.SplitToAnalogAndDigitalParts(audioLine, ref analogPart, ref digitalPart);
            Assert.AreEqual(expectedAnalogPart, analogPart);
            Assert.AreEqual(expectedDigitalPart, digitalPart);
        }

        [TestMethod()]
        public void SplitToAnalogAndDigitalPartsTest5()
        {
            string analogPart = string.Empty;
            string digitalPart = string.Empty;
            string expectedAnalogPart = "101=deu@4,102=eng+spa@4,105=@4";
            string expectedDigitalPart = string.Empty;
            string audioLine = expectedAnalogPart + (string.IsNullOrEmpty(expectedDigitalPart) ? string.Empty : ";" + expectedDigitalPart);
            AudioField af = new AudioField();
            af.SplitToAnalogAndDigitalParts(audioLine, ref analogPart, ref digitalPart);
            Assert.AreEqual(expectedAnalogPart, analogPart);
            Assert.AreEqual(expectedDigitalPart, digitalPart);
        }

        [TestMethod()]
        public void SplitToAnalogAndDigitalPartsTest6()
        {
            string analogPart = string.Empty;
            string digitalPart = string.Empty;
            string expectedAnalogPart = string.Empty;
            string expectedDigitalPart = "101=deu@4,102=eng+spa@4,105=@4";
            string audioLine = expectedAnalogPart + (string.IsNullOrEmpty(expectedDigitalPart) ? string.Empty : ";" + expectedDigitalPart);
            AudioField af = new AudioField();
            af.SplitToAnalogAndDigitalParts(audioLine, ref analogPart, ref digitalPart);
            Assert.AreEqual(expectedAnalogPart, analogPart);
            Assert.AreEqual(expectedDigitalPart, digitalPart);
        }

        [TestMethod()]
        public void SplitAudioPartIntoSinglePIDsTest1()
        {
            List<string> expected = new List<string>();
            expected.Add("101");
            List<string> actual = new List<string>();
            AudioField af = new AudioField();
            af.SplitAudioPartIntoSinglePIDs(string.Join(",", expected.ToArray()), ref actual);
            Assert.AreEqual(string.Join(",", expected.ToArray()), string.Join(",", actual.ToArray()));
        }

        [TestMethod()]
        public void SplitAudioPartIntoSinglePIDsTest2()
        {
            List<string> expected = new List<string>();
            expected.Add("101=deu");
            List<string> actual = new List<string>();
            AudioField af = new AudioField();
            af.SplitAudioPartIntoSinglePIDs(string.Join(",", expected.ToArray()), ref actual);
            Assert.AreEqual(string.Join(",", expected.ToArray()), string.Join(",", actual.ToArray()));
        }

        [TestMethod()]
        public void SplitAudioPartIntoSinglePIDsTest3()
        {
            List<string> expected = new List<string>();
            expected.Add("101=deu@4");
            List<string> actual = new List<string>();
            AudioField af = new AudioField();
            af.SplitAudioPartIntoSinglePIDs(string.Join(",", expected.ToArray()), ref actual);
            Assert.AreEqual(string.Join(",", expected.ToArray()), string.Join(",", actual.ToArray()));
        }

        [TestMethod()]
        public void SplitAudioPartIntoSinglePIDsTest4()
        {
            List<string> expected = new List<string>();
            expected.Add("101=deu");
            expected.Add("102");
            List<string> actual = new List<string>();
            AudioField af = new AudioField();
            af.SplitAudioPartIntoSinglePIDs(string.Join(",", expected.ToArray()), ref actual);
            Assert.AreEqual(string.Join(",", expected.ToArray()), string.Join(",", actual.ToArray()));
        }

        [TestMethod()]
        public void SplitAudioPartIntoSinglePIDsTest5()
        {
            List<string> expected = new List<string>();
            expected.Add("101=deu");
            expected.Add("102");
            expected.Add("103=spa@3");
            List<string> actual = new List<string>();
            AudioField af = new AudioField();
            af.SplitAudioPartIntoSinglePIDs(string.Join(",", expected.ToArray()), ref actual);
            Assert.AreEqual(string.Join(",", expected.ToArray()), string.Join(",", actual.ToArray()));
        }

        [TestMethod()]
        public void FillAudioObjectTest1()
        {
            string expected = string.Empty;
            string actual = string.Empty;
            AudioField ae = new AudioField();
            ae.FillAudioObject(expected);
            actual = ae.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FillAudioObjectTest2()
        {
            string expected = "101,102;103,104";
            string actual = string.Empty;
            AudioField ae = new AudioField();
            ae.FillAudioObject(expected);
            actual = ae.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FillAudioObjectTest3()
        {
            string expected = "101=deu,102=eng;103=deu,104=eng";
            string actual = string.Empty;
            AudioField ae = new AudioField();
            ae.FillAudioObject(expected);
            actual = ae.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FillAudioObjectTest4()
        {
            string expected = "101=deu,102=eng+spa;103=deu,104=eng";
            string actual = string.Empty;
            AudioField ae = new AudioField();
            ae.FillAudioObject(expected);
            actual = ae.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FillAudioObjectTest5()
        {
            string expected = "101=deu@4,102=eng+spa@4,105=@4";
            string actual = string.Empty;
            AudioField ae = new AudioField();
            ae.FillAudioObject(expected);
            actual = ae.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FillAudioObjectTest6()
        {
            string expected = ";101=deu@4,102=eng+spa@4,105=@4";
            string actual = string.Empty;
            AudioField ae = new AudioField();
            ae.FillAudioObject(expected);
            actual = ae.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}