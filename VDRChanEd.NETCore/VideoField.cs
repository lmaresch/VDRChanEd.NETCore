using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDRChanEd.NETCore
{
    public class VideoField : Notifier
    {
        #region Private Members
        private int videoPID;
        private Nullable<int> pcrPID;
        private Nullable<int> videoType;
        #endregion Private Members

        #region Constructors
        public VideoField()
        {
            this.videoPID = 0;
        }
        #endregion Constructors

        #region Public Properties
        public int VideoPID
        {
            get => this.videoPID;
            set => this.SetField(ref this.videoPID, value);
        }

        public Nullable<int> PCRPID
        {
            get => this.pcrPID;
            set => this.SetField(ref this.pcrPID, value);
        }

        public Nullable<int> VideoType
        {
            get => this.videoType;
            set => this.SetField(ref this.videoType, value);
        }
        #endregion Public Properties

        #region Public Methods
        public void SplitVideoField(string vpidField)
        {
            int posPlus = vpidField.IndexOf('+');
            int posEquals = vpidField.IndexOf('=');
            int videoEnd = -1;
            int pcrStart = -1;
            int pcrEnd = -1;
            int typeStart = -1;

            if (posPlus > -1)
            {
                videoEnd = posPlus;
                pcrStart = posPlus + 1;
            }

            if (posEquals > -1)
            {
                if (videoEnd == -1)
                    videoEnd = posEquals;
                else
                    pcrEnd = posEquals;

                typeStart = posEquals + 1;
            }

            int tempInt = -1;
            this.VideoPID = (int.TryParse(vpidField.Substring(0, videoEnd == -1 ? vpidField.Length : videoEnd), out tempInt) ? tempInt : -1);
            if (pcrStart > -1)
                this.PCRPID = (int.TryParse(vpidField.Substring(pcrStart, pcrEnd == -1 ? vpidField.Length - pcrStart : pcrEnd - pcrStart), out tempInt) ? tempInt : (int?)null);
            if (typeStart > -1)
                this.VideoType = int.TryParse(vpidField.Substring(typeStart), out tempInt) ? tempInt : (int?)null;
        }
        #endregion Public Methods

        #region Public Override Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.VideoPID);
            if (this.PCRPID.HasValue && !this.VideoPID.Equals(this.PCRPID.Value))
            {
                sb.Append('+');
                sb.Append(this.PCRPID.Value);
            }

            if (this.VideoType.HasValue && !this.VideoPID.Equals(0))
            {
                sb.Append('=');
                sb.Append(this.VideoType.Value);
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!obj.GetType().Equals(typeof(VideoField)))
                return false;
            VideoField vf = obj as VideoField;
            if (obj == null)
                return false;
            if (!this.VideoPID.Equals(vf.VideoPID))
                return false;
            if (!this.PCRPID.Equals(vf.PCRPID))
                return false;
            if (!this.VideoType.Equals(vf.VideoType))
                return false;

            return true;
        }

        public override int GetHashCode() => this.ToString().GetHashCode();
        #endregion Public Override Methods
    }
}
