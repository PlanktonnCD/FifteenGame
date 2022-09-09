using PlayerData;
using UI;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UIManager _uiManager;
    public override void InstallBindings()
    {
        Container
            .Bind<DataManager>()
            .FromNew()
            .AsSingle();
        Container
            .Bind<UIManager>()
            .FromInstance(_uiManager)
            .AsSingle();
    }
}