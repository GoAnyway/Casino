namespace Games.GameStates
{
    public class WaitingState : AbstractState
    {
        public override void EnterState(Game context)
        {
        }

        public override void GoToNextState(Game context)
        {
            context.TransitionToState(new WaitingState());
        }

        public override void GoToFinishState(Game context)
        {
            context.TransitionToState(new FinishState());
        }
    }
}