using System;using _Project.Develop.Runtime;
using _Project.Develop.Runtime.Infrastructure.ConfigsService;
using UnityEngine;
using VContainer.Unity;

public class LevelData : IInitializable, IDisposable
{
    private ConfigsProviderService _configsProvider;
    private MapDataConfig _mapDataConfig;
    private MoleGameService _moleGameService;
    
    private int _accumulatedGold;
    private int _countPointsRequiredToWin;
    private int _currentCountPoints;
    private int _health;
    private int _goldPerClick;
    
    public bool IsLossed { get; private set; }
    public bool IsWinned { get; private set; }

    public LevelData(ConfigsProviderService configsProvider, MoleGameService moleGameService)
    {
        _configsProvider = configsProvider;
        _moleGameService = moleGameService;
    }
        
    public void Initialize()
    {
        _mapDataConfig = _configsProvider.GetConfig<MapDataConfig>();
        
        _goldPerClick = _mapDataConfig.GoldPerClick;
        _countPointsRequiredToWin = _mapDataConfig.CountPointsRequiredToWin;
        _health = _mapDataConfig.Health;
        
        _moleGameService.OnMoleHitted += HitMole;
        _moleGameService.OnMoleMissed += MissMole;
    }

    private void HitMole()
    {
        _accumulatedGold += _goldPerClick;
        _currentCountPoints += 1;
        
        if (_countPointsRequiredToWin <= _currentCountPoints)
            IsWinned = true;
    }

    private void MissMole()
    {
        _health -= 1;
        
        if (_health <= 0)
        {
            _accumulatedGold = 0;
            IsLossed = true;
        }
    }

    public void Dispose()
    {
        _moleGameService.OnMoleHitted -= HitMole;
        _moleGameService.OnMoleMissed -= MissMole;
    }
}
