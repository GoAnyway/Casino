namespace Games.GameStates
{
    public class FinishState : AbstractState
    {
        public override void EnterState(Game context)
        {
            context.Result = context.GetResult();
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