using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDRChanEd.NETCore
{
    public class NameField : Notifier
    {
        #region Private Members
        private string name;
        private string shortName;
        private string providerName;
        private string networkName;
        #endregion Private Members

        #region Constructors
        public NameField()
        {
            this.name = string.Empty;
            this.shortName = string.Empty;
            this.providerName = string.Empty;
            this.networkName = string.Empty;
        }
        #endregion Constructors

        #region Public Properties
        public string Name
        {
            get => this.name;
            set => this.SetField(ref this.name, value);
        }

        public string ShortName
        {
            get => this.shortName;
            set => this.SetField(ref this.shortName, value);
        }

        public string ProviderName
        {
            get => this.providerName;
            set => this.SetField(ref this.providerName, value);
        }

        public string NetworkName
        {
            get => this.networkName;
            set => this.SetField(ref this.networkName, value);
        }
        #endregion Public Properties

        #region Public Methods
        public void SplitNameField(string nameField)
        {
            string nameShortNamePart = string.Empty;
            string providerNetworkPart = string.Empty;
            this.SplitToNamesAndProviderNetwork(nameField, ref nameShortNamePart, ref providerNetworkPart);
            if (!string.IsNullOrEmpty(nameShortNamePart))
            {
                string name = string.Empty;
                string shortName = string.Empty;
                this.SplitToNameAndShortName(nameShortNamePart, ref name, ref shortName);
                if (!string.IsNullOrEmpty(name))
                    this.Name = Helper.ReplacePipeWithColon(name);
                if (!string.IsNullOrEmpty(shortName))
                    this.ShortName = Helper.ReplaceDotWithComma(shortName);
            }

            if (!string.IsNullOrEmpty(providerNetworkPart))
            {
                string provider = string.Empty;
                string network = string.Empty;
                this.SplitToProviderAndNetwork(providerNetworkPart, ref provider, ref network);
                if (!string.IsNullOrEmpty(provider))
                    this.ProviderName = provider;
                if (!string.IsNullOrEmpty(network))
                    this.NetworkName = network;
            }
        }

        public void SplitToNamesAndProviderNetwork(string completeString, ref string nameShortNamePart, ref string providerNetworkPart)
        {
            if (completeString.Contains(";"))
            {
                string[] parts = completeString.Split(new char[] { ';' });
                nameShortNamePart = parts[0];
                providerNetworkPart = parts[1];
            }
            else
            {
                nameShortNamePart = completeString;
            }
        }

        public void SplitToNameAndShortName(string nameShortNamePart, ref string name, ref string shortName)
        {
            if (nameShortNamePart.Contains(","))
            {
                int pos = nameShortNamePart.LastIndexOf(',');
                name = nameShortNamePart.Substring(0, pos);
                shortName = nameShortNamePart.Substring(pos + 1);
            }
            else
            {
                name = nameShortNamePart;
            }

        }

        public void SplitToProviderAndNetwork(string providerNetworkPart, ref string provider, ref string network)
        {
            string[] parts = providerNetworkPart.Split(new char[] { '=' });
            provider = parts[0];
            if (parts.Length > 1)
                network = parts[1];
        }
        #endregion Public Methods

        #region Public Override Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Helper.ReplaceColonWithPipe(this.Name));
            if (!string.IsNullOrEmpty(this.ShortName))
            {
                sb.Append(',');
                sb.Append(Helper.ReplaceCommaWithDot(this.ShortName));
            }

            if (!string.IsNullOrEmpty(this.ProviderName) || !string.IsNullOrEmpty(this.NetworkName))
            {
                sb.Append(';');
                if (!string.IsNullOrEmpty(this.ProviderName))
                    sb.Append(this.ProviderName);
                if (!string.IsNullOrEmpty(this.NetworkName))
                {
                    sb.Append('=');
                    sb.Append(this.NetworkName);
                }
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!obj.GetType().Equals(typeof(NameField)))
                return false;
            NameField nf = obj as NameField;
            if (nf == null)
                return false;
            if (!this.Name.Equals(nf.Name))
                return false;
            if (!this.ShortName.Equals(nf.ShortName))
                return false;
            if (!this.ProviderName.Equals(nf.ProviderName))
                return false;
            if (!this.NetworkName.Equals(nf.NetworkName))
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        #endregion Public Override Methods
    }
}
