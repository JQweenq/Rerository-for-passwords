using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Models
{
    class Model : INotifyPropertyChanged
    {
        private int _Num;
        private string _URL;
        private string _Description;
        private string _Password;
        private string _Login;

        public int Num
        {
            get { return _Num; }
            set 
            { 
                _Num = value;
            }
        }

        public string Url
        {
            get { return _URL; }
            set
            {
                if (_URL == value)
                    return;

                _URL = value;
                OnPropertyChanged("Url");
            }
        }

        public string Login
        {
            get { return _Login; }
            set
            {
                if (_Login == value)
                    return;

                _Login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password == value)
                    return;

                _Password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description == value)
                    return;

                _Description = value;
                OnPropertyChanged("Description");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
