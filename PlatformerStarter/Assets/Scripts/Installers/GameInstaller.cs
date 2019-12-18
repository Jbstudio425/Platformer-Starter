using UnityEngine;
using Zenject;
using LP.Saving;
using LP.Core;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallCore();
        InstallSaving();
    }

    void InstallCore()
    {
        Container.Bind<IGame>().To<Game>().AsSingle();
    }

    void InstallSaving()
    {
        Container.Bind<ISceneDataSet>().To<SceneDataSet>().AsSingle();
    }
}