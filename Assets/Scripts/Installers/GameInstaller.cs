using System;
using Main;
using UnityEngine;
using Zenject;

// документация https://github.com/modesttree/Zenject
public class GameInstaller : MonoInstaller {

    [Inject]
    Settings _settings = null;
    
    public override void InstallBindings() {
        SignalBusInstaller.Install(Container);
        
        Container.Bind<ScreenService>().AsSingle();
        Container.BindInterfacesAndSelfTo<MoneyService>().AsSingle();
        
        Container.BindFactory<LineElementController, LineElementController.Factory>()
            // This means that any time Asteroid.Factory.Create is called, it will instantiate
            // this prefab and then search it for the Asteroid component
            .FromComponentInNewPrefab(_settings.LineElementPrefab)
            // We can also tell Zenject what to name the new gameobject here
            .WithGameObjectName("Lines")
            // GameObjectGroup's are just game objects used for organization
            // This is nice so that it doesn't clutter up our scene hierarchy
            .UnderTransformGroup("Line");
        
        Container.BindFactory<TrainController, TrainController.Factory>()
            .FromComponentInNewPrefab(_settings.TrainPrefab)
            .WithGameObjectName("Trains")
            .UnderTransformGroup("Train");
        
        Container.BindFactory<DrowLineComponent, DrowLineComponent.Factory>()
            .FromComponentInNewPrefab(_settings.LinePrefab)
            .WithGameObjectName("newLines")
            .UnderTransformGroup("newLine");
        
        Container.BindInterfacesAndSelfTo<GameController>().AsSingle();

    }
    
    [Serializable]
    public class Settings
    {
        public GameObject LineElementPrefab;
        public GameObject LinePrefab;
        public GameObject TrainPrefab;
    }
}
