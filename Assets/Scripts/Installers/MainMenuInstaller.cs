using StateMachines.MainMenuStates;
using StateMachines;
using Zenject;
using Views.MainMenuPages;
using Services;
using Data;

namespace Assets.Scripts.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelDataService>().AsSingle();
            Container.Bind<PrefabsStorageService>().AsSingle();
            Container.Bind<MainMenuPageService>().AsSingle();
            Container.Bind<MainMenuStartState>().AsSingle();
            Container.Bind<StateMachine>().AsSingle();
        }
    }
}