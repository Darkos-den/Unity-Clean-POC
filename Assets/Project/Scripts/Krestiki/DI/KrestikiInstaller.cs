using UnityEngine;
using Zenject;

public class KrestikiInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IBoardDataSource>().To<BoardDataSource>().FromNew().AsSingle();
        Container.Bind<IBoardRepository>().To<BoardRepository>().FromNew().AsSingle();
        Container.Bind<ISessionUseCase>().To<SessionUseCase>().FromNew().AsSingle();

        Container.Bind<ISessionContextController>().To<SessionContextController>().FromNew().AsTransient();
        Container.Bind<ITurnHudController>().To<TurnHudController>().FromNew().AsTransient();
        Container.Bind<ICellController>().To<CellController>().FromNew().AsTransient();
    }
}