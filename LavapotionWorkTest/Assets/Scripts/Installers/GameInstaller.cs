using UnityEngine;
using Zenject;
using LP.Saving;
using LP.Core;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallSceneDataSet();
        InstallCore();
    }

    void InstallSceneDataSet()
    {
    }

    void InstallCore()
    {
    }
}