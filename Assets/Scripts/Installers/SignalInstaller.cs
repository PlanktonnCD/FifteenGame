using GameBootstrap;
using Timer;
using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container
            .DeclareSignal<GameEndSignal>();
        Container
            .DeclareSignal<SendTimerInfoSignal>();
        Container
            .DeclareSignal<RestartGameSignal>();
    }
}