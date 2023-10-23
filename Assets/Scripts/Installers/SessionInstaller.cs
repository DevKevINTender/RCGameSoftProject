using Data;
using Services;
using StateMachines;
using UnityEngine;
using Views.Pages;
using Views.TutorialComplete;
using Views.TutorialFail;
using Views.TutorialPractice;
using Views.TutorialPractice.Curier;
using Views.TutorialPractice.Curier.Curier;
using Views.TutorialPractice.Instrument;
using Views.TutorialPractice.Instrument.InstrumentCard;
using Views.TutorialPractice.Page;
using Zenject;

public class SessionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallData();
        Container.Bind<PrefabsStorageService>().AsSingle();
        Container.Bind<InstrumentCardFactory>().AsSingle();
        Container.Bind<CourierCardFactory>().AsSingle();
        Container.Bind<TutorialPageService>().AsSingle();
        Container.Bind<PizzaService>().AsSingle();
        Container.Bind<InstrumentsPanelService>().AsSingle();
        Container.Bind<CouriersPanelService>().AsSingle();
        Container.Bind<TutorialCompleteService>().AsSingle();
        Container.Bind<TutorialFailService>().AsSingle();
        Container.Bind<TutorialInfoPagesService>().AsSingle();
        Container.Bind<TutorialNavPanelService>().AsSingle();

        Container.Bind<TutorialStartState>().AsSingle();
        Container.Bind<TutorialInfoState>().AsSingle();
        Container.Bind<TutorialPracticeGenerateState>().AsSingle();
        Container.Bind<TutorialPracticePizzaCutState>().AsSingle();
        Container.Bind<TutorialPracticeCheckState>().AsSingle();
        Container.Bind<TutorialPracticeCompleteState>().AsSingle();
        Container.Bind<TutorialPracticeFailState>().AsSingle();

        Container.Bind<StateMachine>().AsSingle();
    }

    public void InstallData()
    {
        /*LevelDataSo levelDataSo = new LevelDataSo() {correctAnswer = 2, answerVariants = {2,4}};
        Container.Bind<LevelDataSo>().FromInstance(levelDataSo).AsSingle();*/
        Container.Bind<LevelDataService>().AsSingle();
        
    }
    
}