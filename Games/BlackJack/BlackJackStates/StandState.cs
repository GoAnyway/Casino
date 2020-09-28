using Games.GameStates;

namespace Games.BlackJack.BlackJackStates
{
    public class StandState : AbstractState
    {
        public override void EnterState(Game context)
        {
            ((BlackJackGame) context).DealerPlays();
        }

        public override void GoToNextState(Game context)
        {
            context.TransitionToState(new FinishState());
        }

        public override void GoToFinishState(Game context)
        {
            context.TransitionToState(new FinishState());
        }
    }
}