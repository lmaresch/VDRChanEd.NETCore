using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDRChanEd.NETCore
{
    public class AudioField : Notifier
    {
        #region Private Members
        private ObservableCollection<AudioEntry> analogEntries;
        private ObservableCollection<AudioEntry> digitalEntries;
        #endregion Private Members

        #region Constructors
        public AudioField()
        {
            this.analogEntries = new ObservableCollection<AudioEntry>();
            this.digitalEntries = new ObservableCollection<AudioEntry>();
        }
        #endregion Constructors

        #region Public Properties
        public ObservableCollection<AudioEntry> AnalogEntries
        {
            get => this.analogEntries;
            set => this.SetField(ref this.analogEntries, value);
        }

        public ObservableCollection<AudioEntry> DigitalEntries
        {
            get => this.digitalEntries;
            set => this.SetField(ref this.digitalEntries, value);
        }
        #endregion Public Properties

        #region Public Methods
        public void FillAudioObject(string audioLine)
        {
            string analogPart = string.Empty;
            string digitalPart = string.Empty;
            this.SplitToAnalogAndDigitalParts(audioLine, ref analogPart, ref digitalPart);
            List<string> analogParts = new List<string>();
            List<string> digitalParts = new List<string>();
            if (!string.IsNullOrEmpty(analogPart))
            {
                this.SplitAudioPartIntoSinglePIDs(analogPart, ref analogParts);
                foreach(string entry in analogParts)
                {
                    AudioEntry ae = new AudioEntry();
                    ae.ParseAudioEntry(entry);
                    this.AnalogEntries.Add(ae);
                }
            }

            if (!string.IsNullOrEmpty(digitalPart))
            {
                this.SplitAudioPartIntoSinglePIDs(digitalPart, ref digitalParts);
                foreach(string entry in digitalParts)
                {
                    AudioEntry ae = new AudioEntry();
                    ae.ParseAudioEntry(entry);
                    this.DigitalEntries.Add(ae);
                }
            }
        }

        public void SplitToAnalogAndDigitalParts(string audioLine, ref string analogPart, ref string digitalPart)
        {
            string[] splittedLine = audioLine.Split(new char[] { ';' });
            analogPart = splittedLine[0];
            if (splittedLine.Length > 1)
                digitalPart = splittedLine[1];
        }

        public void SplitAudioPartIntoSinglePIDs(string audioPart, ref List<string> splittedPIDs)
        {
            splittedPIDs.Clear();
            splittedPIDs.AddRange(audioPart.Split(new char[] { ',' }));
        }
        #endregion Public Methods

        #region Public Override Methods
        public override string ToString()
        {
            string audioEntries = string.Join(",", this.AnalogEntries);
            string digitalEntries = string.Join(",", this.DigitalEntries);
            return audioEntries + (digitalEntries.Length > 0 ? ";" + digitalEntries : string.Empty);
        }
        #endregion Public Override Methods
    }
}
