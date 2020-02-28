using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDRChanEd.NETCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VDRChanEd.NETCore.Tests
{
    [TestClass()]
    public class AudioEntryTests
    {
        public string CreateAudioString(short audioPid, string lang1, string lang2, Nullable<short> audioType)
        {
            StringBuilder expected = new StringBuilder();
            expected.Append(audioPid.ToString());
            if (!string.IsNullOrEmpty(lang1) || audioType.HasValue)
                expected.Append('=');
            if (!string.IsNullOrEmpty(lang1))
            {
                expected.Append(lang1);
                if (!string.IsNullOrEmpty(lang2))
                {
                    expected.Append('+');
                    expected.Append(lang2);
                }
            }
            if (audioType.HasValue)
            {
                expected.Append('@');
                expected.Append(audioType.Value);
            }

            return expected.ToString();
        }

        [TestMethod()]
        public void ParseAudioEntryTest1()
        {
            AudioEntry audioEntry = new AudioEntry();
            short audioPid = 256;
            string lang1 = string.Empty;
            string lang2 = string.Empty;
            Nullable<short> audioType = null;
            string expected = CreateAudioString(audioPid, lang1, lang2, audioType);
            audioEntry.ParseAudioEntry(expected);
            Assert.AreEqual(audioPid, audioEntry.AudioPID);
            Assert.AreEqual(lang1, audioEntry.Lang1);
            Assert.AreEqual(lang2, audioEntry.Lang2);
            Assert.AreEqual(audioType, audioEntry.AudioType);
            Assert.AreEqual(expected, audioEntry.ToString());
        }

        [TestMethod()]
        public void ParseAudioEntryTest2()
        {
            AudioEntry audioEntry = new AudioEntry();
            short audioPid = 256;
            string lang1 = "deu";
            string lang2 = string.Empty;
            Nullable<short> audioType = null;
            string expected = CreateAudioString(audioPid, lang1, lang2, audioType);
            audioEntry.ParseAudioEntry(expected);
            Assert.AreEqual(audioPid, audioEntry.AudioPID);
            Assert.AreEqual(lang1, audioEntry.Lang1);
            Assert.AreEqual(lang2, audioEntry.Lang2);
            Assert.AreEqual(audioType, audioEntry.AudioType);
            Assert.AreEqual(expected, audioEntry.ToString());
        }

        [TestMethod()]
        public void ParseAudioEntryTest3()
        {
            AudioEntry audioEntry = new AudioEntry();
            short audioPid = 256;
            string lang1 = "deu";
            string lang2 = "spa";
            Nullable<short> audioType = null;
            string expected = CreateAudioString(audioPid, lang1, lang2, audioType);
            audioEntry.ParseAudioEntry(expected);
            Assert.AreEqual(audioPid, audioEntry.AudioPID);
            Assert.AreEqual(lang1, audioEntry.Lang1);
            Assert.AreEqual(lang2, audioEntry.Lang2);
            Assert.AreEqual(audioType, audioEntry.AudioType);
            Assert.AreEqual(expected, audioEntry.ToString());
        }

        [TestMethod()]
        public void ParseAudioEntryTest4()
        {
            AudioEntry audioEntry = new AudioEntry();
            short audioPid = 256;
            string lang1 = "deu";
            string lang2 = "spa";
            Nullable<short> audioType = 4;
            string expected = CreateAudioString(audioPid, lang1, lang2, audioType);
            audioEntry.ParseAudioEntry(expected);
            Assert.AreEqual(audioPid, audioEntry.AudioPID);
            Assert.AreEqual(lang1, audioEntry.Lang1);
            Assert.AreEqual(lang2, audioEntry.Lang2);
            Assert.AreEqual(audioType, audioEntry.AudioType);
            Assert.AreEqual(expected, audioEntry.ToString());
        }

        [TestMethod()]
        public void ParseAudioEntryTest5()
        {
            AudioEntry audioEntry = new AudioEntry();
            short audioPid = 256;
            string lang1 = "deu";
            string lang2 = string.Empty;
            Nullable<short> audioType = 4;
            string expected = CreateAudioString(audioPid, lang1, lang2, audioType);
            audioEntry.ParseAudioEntry(expected);
            Assert.AreEqual(audioPid, audioEntry.AudioPID);
            Assert.AreEqual(lang1, audioEntry.Lang1);
            Assert.AreEqual(lang2, audioEntry.Lang2);
            Assert.AreEqual(audioType, audioEntry.AudioType);
            Assert.AreEqual(expected, audioEntry.ToString());
        }

        [TestMethod()]
        public void ParseAudioEntryTest6()
        {
            AudioEntry audioEntry = new AudioEntry();
            short audioPid = 256;
            string lang1 = string.Empty;
            string lang2 = string.Empty;
            Nullable<short> audioType = 4;
            string expected = CreateAudioString(audioPid, lang1, lang2, audioType);
            audioEntry.ParseAudioEntry(expected);
            Assert.AreEqual(audioPid, audioEntry.AudioPID);
            Assert.AreEqual(lang1, audioEntry.Lang1);
            Assert.AreEqual(lang2, audioEntry.Lang2);
            Assert.AreEqual(audioType, audioEntry.AudioType);
            Assert.AreEqual(expected, audioEntry.ToString());
        }
    }
}