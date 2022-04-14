using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp5.Model
{
    public class Person:INotifyPropertyChanged
    {
        private string fname;

        public string FName
        {
            get { return fname; }
            set { fname = value; OnPropertyChanged(LName); }
        }


        private string lname;

        public string LName
        {
            get { return lname; }
            set { lname = value; OnPropertyChanged(LName); }
        }


        private string fullname;

        
        public string FullName
        {
            get { return fullname=FName+" "+LName; }
            set
            {
                if (fullname != value)
                {
                    fullname = value;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }

    }
}
