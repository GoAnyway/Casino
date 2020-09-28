using System.Linq;
using WPFApp.UserData;

namespace WPFApp.Logic.Bet
{
    public class BetVerifier
    {
        public bool VerifyBet(string bet)
        {
            return bet != null &&
                   bet.All(char.IsDigit) &&
                   int.Parse(bet) >= 100 &&
                   int.Parse(bet) <= AuthorizedUserData.Instance.AuthorizedUser.Balance;
        }
    }
}