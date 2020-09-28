using Games;
using Utils;
using WPFApp.UserData;

namespace WPFApp.GameCommunications
{
    public abstract class GameCommunication : NotifyChanged
    {
        protected int Bet;

        public abstract string GameResult { get; set; }

        public abstract void StartGame(int bet);

        protected abstract void GetGameResult(BaseGameResult result);

        protected void DecreaseBalance()
        {
            AuthorizedUserData.Instance.AuthorizedUser.Balance -= Bet;
        }

        protected void IncreaseBalance()
        {
            AuthorizedUserData.Instance.AuthorizedUser.Balance += Bet;
        }
    }
}