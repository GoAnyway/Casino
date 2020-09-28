using Games.GameStates;

namespace Games.BlackJack.BlackJackStates
{
    public class HitState : AbstractState
    {
        public override void EnterState(Game context)
        {
            ((BlackJackGame) context).PlayerTakesCard();

            context.TransitionToState(((BlackJackGame) context).HasAnyoneFinished()
                ? (AbstractState) new FinishState()
                : new WaitingState());
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