using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;

namespace FlipNLearn.Models
{
    public class Card : INotifyPropertyChanged
    {
        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public int Id { get; set; }
        
        // Color
        public Color _Color { get; set; }
        public Color Color
        {
            get { return this._Color; }
            set
            {
                if (value != this._Color)
                {
                    this._Color = value;
                    NotifyPropertyChanged("Color");
                }
            }
        }

        // FrontText
        public string _FrontText { get; set; }
        public string FrontText
        {
            get { return this._FrontText; }
            set
            {
                if (value != this._FrontText)
                {
                    this._FrontText = value;
                    NotifyPropertyChanged("FrontText");
                }
            }
        }

        // BackText
        public string _BackText { get; set; }
        public string BackText
        {
            get { return this._BackText; }
            set
            {
                if (value != this._BackText)
                {
                    this._BackText = value;
                    NotifyPropertyChanged("BackText");
                }
            }
        }

        public byte[] FrontPic { get; set; }
        public byte[] BackPic { get; set; }
    }
}
