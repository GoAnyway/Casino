using WPFApp.ViewModels;

namespace WPFApp.UserData
{
    public sealed class AuthorizedUserData
    {
        private static AuthorizedUserData _instance;

        private AuthorizedUserData()
        {
        }

        public UserViewModel AuthorizedUser { get; set; }

        public static AuthorizedUserData Instance =>
            _instance ??= new AuthorizedUserData();
    }
}