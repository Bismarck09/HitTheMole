using _Project.Develop.Runtime;
using _Project.Develop.Runtime.Infrastructure.ConfigsService;
using UnityEngine;
using VContainer.Unity;

public class GameFieldInitializer : IStartable
{
    private GameFieldFactory _gameFieldFactory;
    private MapDataConfig _mapDataConfig;
    private MoleHoleRepository  _repository;

    public GameFieldInitializer(GameFieldFactory gameFieldFactory, ConfigsProviderService configsProviderService, MoleHoleRepository repository)
    {
        _gameFieldFactory = gameFieldFactory;
        _mapDataConfig = configsProviderService.GetConfig<MapDataConfig>();
        _repository = repository;
    }

    public void Start()
    {
        GameObject map = Object.Instantiate(_mapDataConfig.Field.gameObject, Vector3.zero, Quaternion.identity);
        
        foreach (Transform hole in _mapDataConfig.Field.Holes)
        {
            GameObject mole = Object.Instantiate(_mapDataConfig.MolePrefab, hole.position, hole.rotation);
            mole.gameObject.SetActive(false);
            
            if (mole.TryGetComponent(out MoleData moleData))
                _repository.Add(hole.name, moleData);
        }
    }
}
