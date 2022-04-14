using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WpfApp5.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp5.Command;

namespace WpfApp5.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        private WpfApp5.Model.Person _person;

        public WpfApp5.Model.Person Person
        {
            get { return _person; }
            set { _person = value; NotifyPropertyChanged("Person");  }
        }


        private ObservableCollection<WpfApp5.Model.Person> _Persons;

        public ObservableCollection<WpfApp5.Model.Person> Persons
        {
            get { return _Persons; }
            set { _Persons = value; NotifyPropertyChanged("Persons"); }
        }

        public ICommand _SubmitCommand { get; set; }

        public ICommand SubmitCommand
        {
            get
            {
                if(_SubmitCommand==null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute,false);
                }
                return _SubmitCommand;
            }
        }

        private void SubmitExecute(object parameter)
        {
            Persons.Add(Person);
        }
       
        private bool CanSubmitExecute(object parameter)
        {
            if(string.IsNullOrEmpty(Person.FName) || string.IsNullOrEmpty(Person.LName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged (string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler (this, new PropertyChangedEventArgs (p));
        }
    }
}
