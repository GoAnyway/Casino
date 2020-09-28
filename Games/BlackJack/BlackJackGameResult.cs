using System;

namespace Games.BlackJack
{
    public class BlackJackGameResult : BaseGameResult
    {
        public enum BlackJackResult
        {
            Win,
            Loss,
            Draw
        }

        public BlackJackResult Result { get; internal set; }

        public override string Message =>
            Result switch
            {
                BlackJackResult.Draw => "Draw",
                BlackJackResult.Win => "Win",
                BlackJackResult.Loss => "Loss",
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}