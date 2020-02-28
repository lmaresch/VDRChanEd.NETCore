using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDRChanEd.NETCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VDRChanEd.NETCore.Tests
{
    [TestClass()]
    public class NameFieldTests
    {
        [TestMethod()]
        public void SplitNameFieldTest1()
        {
            NameField nameField = new NameField();
            string text = "RTL Television";
            nameField.SplitNameField(text);
            Assert.AreEqual(text, nameField.Name);
            Assert.AreEqual(text, nameField.ToString());
        }

        [TestMethod()]
        public void SplitNameFieldTest2()
        {
            NameField nameField = new NameField();
            string name = "RTL Television";
            string shortName = "RTL";
            string text = name + "," + shortName;
            nameField.SplitNameField(text);
            Assert.AreEqual(name, nameField.Name);
            Assert.AreEqual(shortName, nameField.ShortName);
            Assert.AreEqual(text, nameField.ToString());
        }

        [TestMethod()]
        public void SplitNameFieldTest3()
        {
            NameField nameField = new NameField();
            string name = "RTL Television";
            string shortName = "RTL";
            string providerName = "RTL World";
            string text = name + "," + shortName + ";" + providerName;
            nameField.SplitNameField(text);
            Assert.AreEqual(name, nameField.Name);
            Assert.AreEqual(shortName, nameField.ShortName);
            Assert.AreEqual(providerName, nameField.ProviderName);
            Assert.AreEqual(text, nameField.ToString());
        }

        [TestMethod()]
        public void SplitNameFieldTest4()
        {
            NameField nameField = new NameField();
            string name = "RTL Television";
            string shortName = "RTL";
            string providerName = "RTL World";
            string networkName = "Premiere";
            string text = name + "," + shortName + ";" + providerName + "=" + networkName;
            nameField.SplitNameField(text);
            Assert.AreEqual(name, nameField.Name);
            Assert.AreEqual(shortName, nameField.ShortName);
            Assert.AreEqual(providerName, nameField.ProviderName);
            Assert.AreEqual(networkName, nameField.NetworkName);
            Assert.AreEqual(text, nameField.ToString());
        }

        [TestMethod()]
        public void SplitNameFieldTest5()
        {
            NameField nameField = new NameField();
            string name = "RTL Television";
            string providerName = "RTL World";
            string text = name + ";" + providerName;
            nameField.SplitNameField(text);
            Assert.AreEqual(name, nameField.Name);
            Assert.AreEqual(providerName, nameField.ProviderName);
            Assert.AreEqual(text, nameField.ToString());
        }

        [TestMethod()]
        public void SplitNameFieldTest6()
        {
            NameField nameField = new NameField();
            string name = "RTL Television";
            string shortName = "RTL";
            string providerName = "RTL World";
            string networkName = "Premiere";
            string text = name + "," + shortName + ";" + providerName + "=" + networkName;
            nameField.SplitNameField(text);
            Assert.AreEqual(name, nameField.Name);
            Assert.AreEqual(shortName, nameField.ShortName);
            Assert.AreEqual(providerName, nameField.ProviderName);
            Assert.AreEqual(networkName, nameField.NetworkName);
            Assert.AreEqual(text, nameField.ToString());
        }

        [TestMethod()]
        public void SplitNameFieldTest7()
        {
            NameField nameField = new NameField();
            string name = "RTL,|Television";
            string shortName = "RTL.";
            string text = name + "," + shortName;
            nameField.SplitNameField(text);
            Assert.AreEqual(Helper.ReplacePipeWithColon(name), nameField.Name);
            Assert.AreEqual(Helper.ReplaceDotWithComma(shortName), nameField.ShortName);
            Assert.AreEqual(text, nameField.ToString());
        }

        [TestMethod()]
        public void SplitToNamesAndProviderNetworkTest1()
        {
            NameField nameField = new NameField();
            string expectedNameShortName = "RTL Television";
            string expectedProviderNetworkName = string.Empty;
            string actualNameShortName = string.Empty;
            string actualProviderNetworkName = string.Empty;
            string completeString = expectedNameShortName + (string.IsNullOrEmpty(expectedProviderNetworkName) ? string.Empty : ";" + expectedProviderNetworkName);
            nameField.SplitToNamesAndProviderNetwork(completeString, ref actualNameShortName, ref actualProviderNetworkName);
            Assert.AreEqual(expectedNameShortName, actualNameShortName);
            Assert.AreEqual(expectedProviderNetworkName, actualProviderNetworkName);
        }

        [TestMethod()]
        public void SplitToNamesAndProviderNetworkTest2()
        {
            NameField nameField = new NameField();
            string expectedNameShortName = "RTL Television,RTL";
            string expectedProviderNetworkName = string.Empty;
            string actualNameShortName = string.Empty;
            string actualProviderNetworkName = string.Empty;
            string completeString = expectedNameShortName + (string.IsNullOrEmpty(expectedProviderNetworkName) ? string.Empty : ";" + expectedProviderNetworkName);
            nameField.SplitToNamesAndProviderNetwork(completeString, ref actualNameShortName, ref actualProviderNetworkName);
            Assert.AreEqual(expectedNameShortName, actualNameShortName);
            Assert.AreEqual(expectedProviderNetworkName, actualProviderNetworkName);
        }

        [TestMethod()]
        public void SplitToNamesAndProviderNetworkTest3()
        {
            NameField nameField = new NameField();
            string expectedNameShortName = "RTL Television";
            string expectedProviderNetworkName = "RTL World";
            string actualNameShortName = string.Empty;
            string actualProviderNetworkName = string.Empty;
            string completeString = expectedNameShortName + (string.IsNullOrEmpty(expectedProviderNetworkName) ? string.Empty : ";" + expectedProviderNetworkName);
            nameField.SplitToNamesAndProviderNetwork(completeString, ref actualNameShortName, ref actualProviderNetworkName);
            Assert.AreEqual(expectedNameShortName, actualNameShortName);
            Assert.AreEqual(expectedProviderNetworkName, actualProviderNetworkName);
        }

        [TestMethod()]
        public void SplitToNamesAndProviderNetworkTest4()
        {
            NameField nameField = new NameField();
            string expectedNameShortName = "RTL Television,RTL";
            string expectedProviderNetworkName = "RTL World";
            string actualNameShortName = string.Empty;
            string actualProviderNetworkName = string.Empty;
            string completeString = expectedNameShortName + (string.IsNullOrEmpty(expectedProviderNetworkName) ? string.Empty : ";" + expectedProviderNetworkName);
            nameField.SplitToNamesAndProviderNetwork(completeString, ref actualNameShortName, ref actualProviderNetworkName);
            Assert.AreEqual(expectedNameShortName, actualNameShortName);
            Assert.AreEqual(expectedProviderNetworkName, actualProviderNetworkName);
        }

        [TestMethod()]
        public void SplitToNamesAndProviderNetworkTest5()
        {
            NameField nameField = new NameField();
            string expectedNameShortName = "RTL Television,RTL";
            string expectedProviderNetworkName = "RTL World=Premiere";
            string actualNameShortName = string.Empty;
            string actualProviderNetworkName = string.Empty;
            string completeString = expectedNameShortName + (string.IsNullOrEmpty(expectedProviderNetworkName) ? string.Empty : ";" + expectedProviderNetworkName);
            nameField.SplitToNamesAndProviderNetwork(completeString, ref actualNameShortName, ref actualProviderNetworkName);
            Assert.AreEqual(expectedNameShortName, actualNameShortName);
            Assert.AreEqual(expectedProviderNetworkName, actualProviderNetworkName);
        }

        [TestMethod()]
        public void SplitToNamesAndProviderNetworkTest6()
        {
            NameField nameField = new NameField();
            string expectedNameShortName = string.Empty;
            string expectedProviderNetworkName = "RTL World";
            string actualNameShortName = string.Empty;
            string actualProviderNetworkName = string.Empty;
            string completeString = expectedNameShortName + (string.IsNullOrEmpty(expectedProviderNetworkName) ? string.Empty : ";" + expectedProviderNetworkName);
            nameField.SplitToNamesAndProviderNetwork(completeString, ref actualNameShortName, ref actualProviderNetworkName);
            Assert.AreEqual(expectedNameShortName, actualNameShortName);
            Assert.AreEqual(expectedProviderNetworkName, actualProviderNetworkName);
        }

        [TestMethod()]
        public void SplitToNamesAndProviderNetworkTest7()
        {
            NameField nameField = new NameField();
            string expectedNameShortName = string.Empty;
            string expectedProviderNetworkName = "RTL World=Premiere";
            string actualNameShortName = string.Empty;
            string actualProviderNetworkName = string.Empty;
            string completeString = expectedNameShortName + (string.IsNullOrEmpty(expectedProviderNetworkName) ? string.Empty : ";" + expectedProviderNetworkName);
            nameField.SplitToNamesAndProviderNetwork(completeString, ref actualNameShortName, ref actualProviderNetworkName);
            Assert.AreEqual(expectedNameShortName, actualNameShortName);
            Assert.AreEqual(expectedProviderNetworkName, actualProviderNetworkName);
        }

        [TestMethod()]
        public void SplitToNamesAndProviderNetworkTest8()
        {
            NameField nameField = new NameField();
            string expectedNameShortName = string.Empty;
            string expectedProviderNetworkName = string.Empty;
            string actualNameShortName = string.Empty;
            string actualProviderNetworkName = string.Empty;
            string completeString = expectedNameShortName + (string.IsNullOrEmpty(expectedProviderNetworkName) ? string.Empty : ";" + expectedProviderNetworkName);
            nameField.SplitToNamesAndProviderNetwork(completeString, ref actualNameShortName, ref actualProviderNetworkName);
            Assert.AreEqual(expectedNameShortName, actualNameShortName);
            Assert.AreEqual(expectedProviderNetworkName, actualProviderNetworkName);
        }

        [TestMethod()]
        public void SplitToNameAndShortNameTest1()
        {
            NameField nameField = new NameField();
            string expectedName = string.Empty;
            string expectedShortName = string.Empty;
            string actualName = string.Empty;
            string actualShortName = string.Empty;
            string nameShortNamePart = expectedName + (string.IsNullOrEmpty(expectedShortName) ? string.Empty : "," + expectedShortName);
            nameField.SplitToNameAndShortName(nameShortNamePart, ref actualName, ref actualShortName);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedShortName, actualShortName);
        }

        [TestMethod()]
        public void SplitToNameAndShortNameTest2()
        {
            NameField nameField = new NameField();
            string expectedName = "RTL Television";
            string expectedShortName = string.Empty;
            string actualName = string.Empty;
            string actualShortName = string.Empty;
            string nameShortNamePart = expectedName + (string.IsNullOrEmpty(expectedShortName) ? string.Empty : "," + expectedShortName);
            nameField.SplitToNameAndShortName(nameShortNamePart, ref actualName, ref actualShortName);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedShortName, actualShortName);
        }

        [TestMethod()]
        public void SplitToNameAndShortNameTest3()
        {
            NameField nameField = new NameField();
            string expectedName = "RTL Television";
            string expectedShortName = "RTL";
            string actualName = string.Empty;
            string actualShortName = string.Empty;
            string nameShortNamePart = expectedName + (string.IsNullOrEmpty(expectedShortName) ? string.Empty : "," + expectedShortName);
            nameField.SplitToNameAndShortName(nameShortNamePart, ref actualName, ref actualShortName);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedShortName, actualShortName);
        }

        [TestMethod()]
        public void SplitToNameAndShortNameTest4()
        {
            NameField nameField = new NameField();
            string expectedName = "RTL,Television";
            string expectedShortName = "RTL";
            string actualName = string.Empty;
            string actualShortName = string.Empty;
            string nameShortNamePart = expectedName + (string.IsNullOrEmpty(expectedShortName) ? string.Empty : "," + expectedShortName);
            nameField.SplitToNameAndShortName(nameShortNamePart, ref actualName, ref actualShortName);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedShortName, actualShortName);
        }

        [TestMethod()]
        public void SplitToNameAndShortNameTest5()
        {
            NameField nameField = new NameField();
            string expectedName = string.Empty;
            string expectedShortName = "RTL";
            string actualName = string.Empty;
            string actualShortName = string.Empty;
            string nameShortNamePart = expectedName + (string.IsNullOrEmpty(expectedShortName) ? string.Empty : "," + expectedShortName);
            nameField.SplitToNameAndShortName(nameShortNamePart, ref actualName, ref actualShortName);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedShortName, actualShortName);
        }

        [TestMethod()]
        public void SplitToNameAndShortNameTest6()
        {
            NameField nameField = new NameField();
            string expectedName = " ";
            string expectedShortName = "RTL";
            string actualName = string.Empty;
            string actualShortName = string.Empty;
            string nameShortNamePart = expectedName + (string.IsNullOrEmpty(expectedShortName) ? string.Empty : "," + expectedShortName);
            nameField.SplitToNameAndShortName(nameShortNamePart, ref actualName, ref actualShortName);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedShortName, actualShortName);
        }

        [TestMethod()]
        public void SplitToProviderAndNetworkTest1()
        {
            NameField nameField = new NameField();
            string expectedProvider = string.Empty;
            string expectedNetwork = string.Empty;
            string actualProvider = string.Empty;
            string actualNetwork = string.Empty;
            string providerNetworkPart = expectedProvider + (string.IsNullOrEmpty(expectedNetwork) ? string.Empty : "=" + expectedNetwork);
            nameField.SplitToProviderAndNetwork(providerNetworkPart, ref actualProvider, ref actualNetwork);
            Assert.AreEqual(expectedProvider, actualProvider);
            Assert.AreEqual(expectedNetwork, actualNetwork);
        }

        [TestMethod()]
        public void SplitToProviderAndNetworkTest2()
        {
            NameField nameField = new NameField();
            string expectedProvider = "RTL World";
            string expectedNetwork = string.Empty;
            string actualProvider = string.Empty;
            string actualNetwork = string.Empty;
            string providerNetworkPart = expectedProvider + (string.IsNullOrEmpty(expectedNetwork) ? string.Empty : "=" + expectedNetwork);
            nameField.SplitToProviderAndNetwork(providerNetworkPart, ref actualProvider, ref actualNetwork);
            Assert.AreEqual(expectedProvider, actualProvider);
            Assert.AreEqual(expectedNetwork, actualNetwork);
        }

        [TestMethod()]
        public void SplitToProviderAndNetworkTest3()
        {
            NameField nameField = new NameField();
            string expectedProvider = "RTL World";
            string expectedNetwork = "Premiere";
            string actualProvider = string.Empty;
            string actualNetwork = string.Empty;
            string providerNetworkPart = expectedProvider + (string.IsNullOrEmpty(expectedNetwork) ? string.Empty : "=" + expectedNetwork);
            nameField.SplitToProviderAndNetwork(providerNetworkPart, ref actualProvider, ref actualNetwork);
            Assert.AreEqual(expectedProvider, actualProvider);
            Assert.AreEqual(expectedNetwork, actualNetwork);
        }

        [TestMethod()]
        public void SplitToProviderAndNetworkTest4()
        {
            NameField nameField = new NameField();
            string expectedProvider = string.Empty;
            string expectedNetwork = "Premiere";
            string actualProvider = string.Empty;
            string actualNetwork = string.Empty;
            string providerNetworkPart = expectedProvider + (string.IsNullOrEmpty(expectedNetwork) ? string.Empty : "=" + expectedNetwork);
            nameField.SplitToProviderAndNetwork(providerNetworkPart, ref actualProvider, ref actualNetwork);
            Assert.AreEqual(expectedProvider, actualProvider);
            Assert.AreEqual(expectedNetwork, actualNetwork);
        }

        [TestMethod()]
        public void SplitToProviderAndNetworkTest5()
        {
            NameField nameField = new NameField();
            string expectedProvider = " ";
            string expectedNetwork = "Premiere";
            string actualProvider = string.Empty;
            string actualNetwork = string.Empty;
            string providerNetworkPart = expectedProvider + (string.IsNullOrEmpty(expectedNetwork) ? string.Empty : "=" + expectedNetwork);
            nameField.SplitToProviderAndNetwork(providerNetworkPart, ref actualProvider, ref actualNetwork);
            Assert.AreEqual(expectedProvider, actualProvider);
            Assert.AreEqual(expectedNetwork, actualNetwork);
        }

        [TestMethod()]
        public void SplitToProviderAndNetworkTest6()
        {
            NameField nameField = new NameField();
            string expectedProvider = " ";
            string expectedNetwork = " ";
            string actualProvider = string.Empty;
            string actualNetwork = string.Empty;
            string providerNetworkPart = expectedProvider + (string.IsNullOrEmpty(expectedNetwork) ? string.Empty : "=" + expectedNetwork);
            nameField.SplitToProviderAndNetwork(providerNetworkPart, ref actualProvider, ref actualNetwork);
            Assert.AreEqual(expectedProvider, actualProvider);
            Assert.AreEqual(expectedNetwork, actualNetwork);
        }
    }
}