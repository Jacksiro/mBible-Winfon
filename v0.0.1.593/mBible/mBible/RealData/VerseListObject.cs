﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace mBible.RealData
{
    public class VerseListObject : ObservableCollection<VerseObject>, INotifyPropertyChanged
    {
        public string Title { get; set; }

        public string ContentInfo { get; set; }

        private VerseObject _lastMessageReceived;

        public VerseObject LastMessageReceived
        {
            get
            {
                return _lastMessageReceived;
            }
            set
            {
                _lastMessageReceived = value;
                NotifyPropertyChanged("LastMessageReceived");
            }
        }

        private bool _hasMultipleMessages;

        public bool HasSingleMessage
        {
            get
            {
                return _hasMultipleMessages;
            }
            set
            {
                _hasMultipleMessages = value;
                NotifyPropertyChanged("HasSingleMessage");
            }
        }

        public VerseListObject(string ci)
            : base()
        {
            ContentInfo = ci;
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);

            LastMessageReceived = this.Items[0];

            HasSingleMessage = (this.Items.Count > 1) ? false : true;
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
