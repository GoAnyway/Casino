using Games.GameStates;
using Utils;

namespace Games
{
    public abstract class Game : NotifyChanged
    {
        public delegate void ResultHandler(BaseGameResult result);

        public AbstractState CurrentState { get; protected set; }

        public BaseGameResult Result
        {
            set => GameIsFinished?.Invoke(value);
        }

        public abstract void StartGame();
        public abstract BaseGameResult GetResult();

        public void TransitionToState(AbstractState state)
        {
            CurrentState = state;

            CurrentState.EnterState(this);
        }

        internal abstract void GoToNextState();

        protected void GoToFinishState()
        {
            CurrentState.GoToFinishState(this);
        }

        public event ResultHandler GameIsFinished;
    }
}