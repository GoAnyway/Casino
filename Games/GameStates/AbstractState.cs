namespace Games.GameStates
{
    public abstract class AbstractState
    {
        public abstract void EnterState(Game context);
        public abstract void GoToNextState(Game context);
        public abstract void GoToFinishState(Game context);
    }
}