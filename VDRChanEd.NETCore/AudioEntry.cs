using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDRChanEd.NETCore
{
    public class AudioEntry : Notifier
    {
        #region Private Members
        private short audioPID;
        private string lang1;
        private string lang2;
        private Nullable<short> audioType;
        #endregion Private Members

        #region Constrcutors
        public AudioEntry()
        {
            this.audioPID = 0;
            this.lang1 = string.Empty;
            this.lang2 = string.Empty;
            this.audioType = null;
        }
        #endregion Constructors

        #region Public Properties
        public short AudioPID
        {
            get => this.audioPID;
            set => this.SetField(ref this.audioPID, value);
        }

        public string Lang1
        {
            get => this.lang1;
            set => this.SetField(ref this.lang1, value);
        }

        public string Lang2
        {
            get => this.lang2;
            set => this.SetField(ref this.lang2, value);
        }

        public Nullable<short> AudioType
        {
            get => this.audioType;
            set => this.SetField(ref this.audioType, value);
        }
        #endregion Public Properties

        #region Public Methods
        public void ParseAudioEntry(string audioEntry)
        {
            string textPid = string.Empty;
            if (audioEntry.Contains("="))
            {
                int eqPos = audioEntry.IndexOf('=');
                textPid = audioEntry.Substring(0, eqPos);
                string textLangType = audioEntry.Substring(eqPos + 1);
                string textLangs = string.Empty;
                if (textLangType.Contains("@"))
                {
                    int atPos = textLangType.IndexOf('@');
                    textLangs = textLangType.Substring(0, atPos);
                    string textType = textLangType.Substring(atPos + 1);
                    short type = 0;
                    if (short.TryParse(textType, out type))
                        this.AudioType = type;
                }
                else
                {
                    textLangs = textLangType;
                }

                if (!string.IsNullOrEmpty(textLangs))
                {
                    string[] splittedLangs = textLangs.Split(new char[] { '+' });
                    this.Lang1 = splittedLangs[0];
                    if (splittedLangs.Length > 1)
                        this.Lang2 = splittedLangs[1];
                }
            }
            else
            {
                textPid = audioEntry;
            }

            short pid = 0;
            if (short.TryParse(textPid, out pid))
                this.AudioPID = pid;
            else
                this.AudioPID = -1;
        }
        #endregion Public Methods

        #region Public Override Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.AudioPID.ToString());
            bool equalsAdded = false;
            if (!string.IsNullOrEmpty(this.Lang1))
            {
                sb.Append('=');
                equalsAdded = true;
                sb.Append(this.Lang1);
                if (!string.IsNullOrEmpty(this.Lang2))
                {
                    sb.Append('+');
                    sb.Append(this.Lang2);
                }
            }
            if (this.AudioType.HasValue)
            {
                if (!equalsAdded)
                    sb.Append('=');
                sb.Append('@');
                sb.Append(this.AudioType.Value.ToString());
            }

            return sb.ToString();
        }
        #endregion Public Override Methods
    }
}
