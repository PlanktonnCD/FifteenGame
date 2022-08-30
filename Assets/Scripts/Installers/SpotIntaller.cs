using Spots;
using UnityEngine;
using Zenject;

public class SpotIntaller : MonoInstaller
{
    [SerializeField] private Spot _spotPrefab;
    public override void InstallBindings()
    {
        Container
            .Bind<SpotFactory>()
            .FromNew()
            .AsSingle()
            .WithArguments(_spotPrefab);
    }
}