using System;

namespace WPFApp.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private int _balance;
        private Guid _id;
        private string _nickname;
        private string _password;
        private string _username;

        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string Nickname
        {
            get => _nickname;
            set
            {
                _nickname = value;
                OnPropertyChanged();
            }
        }

        public int Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged();
            }
        }
    }
}