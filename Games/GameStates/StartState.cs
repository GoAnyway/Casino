namespace Games.GameStates
{
    public class StartState : AbstractState
    {
        public override void EnterState(Game context)
        {
            context.StartGame();
            context.GoToNextState();
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