namespace StateMachines
{
    public class StateMachine 
    {
        private IGameState _currentState;

        public void SetState(IGameState newState)
        {
            _currentState?.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        public void UpdateState()
        {
            _currentState?.Update();
        }

    }
}