namespace WPFApp.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private int balance;
        private int id;

        private string nickname;

        private string password;
        private string username;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string Nickname
        {
            get => nickname;
            set
            {
                nickname = value;
                OnPropertyChanged();
            }
        }

        public int Balance
        {
            get => balance;
            set
            {
                balance = value;
                OnPropertyChanged();
            }
        }
    }
}