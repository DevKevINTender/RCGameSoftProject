namespace StateMachines
{
    public interface IGameState
    {
        void Enter();
        void Update();
        void Exit();
    }

    public interface IBaseGameState : IGameState
    {
    
    }

    public interface IServiceState : IGameState
    {
    
    }

    public interface IViewState
    {
        void Enter();
        void UpdateView();
        void Exit();

    }
}