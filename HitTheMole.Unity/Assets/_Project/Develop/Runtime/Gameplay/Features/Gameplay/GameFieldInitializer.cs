using _Project.Develop.Runtime;
using _Project.Develop.Runtime.Infrastructure.ConfigsService;
using UnityEngine;

internal sealed class GameFieldInitializer
{
    private readonly GameFieldFactory _gameFieldFactory;
    private readonly MapDataConfig _mapDataConfig;
    private readonly MoleHoleRepository _repository;

    public GameFieldInitializer(GameFieldFactory gameFieldFactory, ConfigsProviderService configsProviderService,
        MoleHoleRepository repository)
    {
        _gameFieldFactory = gameFieldFactory;
        _mapDataConfig = configsProviderService.GetConfig<MapDataConfig>();
        _repository = repository;
    }

    public void Initialize()
    {
        HoleField field = _gameFieldFactory.Create(_mapDataConfig.Field, Vector3.zero, Quaternion.identity);

        foreach (Transform hole in field.Holes)
        {
            MoleData mole = _gameFieldFactory.Create(_mapDataConfig.MolePrefab, hole.position, hole.rotation);
            mole.Hide();
            _repository.Add(mole);
        }
    }
}
