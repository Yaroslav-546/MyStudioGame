using Player;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifeTimeScope : LifetimeScope
{
    [SerializeField] private Config _playerConfig;
    [SerializeField] private View _player;
    [SerializeField] private Transform _playerSpawn;


    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance<Config>(_playerConfig);
        builder.Register<Data>(Lifetime.Singleton);
        builder.Register<IDataSaver, JsonSaver>(Lifetime.Singleton);
        builder.Register<IMovable, MoveObject>(Lifetime.Singleton);
        builder.Register<Health>(Lifetime.Singleton);
        builder.RegisterInstance<View>(_player);

        //View playerView = Instantiate<View>(_player, _playerSpawn.position, Quaternion.identity, null);
        //playerView.name = "Player";
        //builder.RegisterInstance<View>(playerView);
    }
}
