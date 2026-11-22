using System;
using _Project.Develop.Runtime;
using _Project.Develop.Runtime.Infrastructure.ConfigsService;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;
using Random = UnityEngine.Random;

public class MoleGameService : IStartable, ITickable
{
    private MoleHoleRepository _repository;
    private ConfigsProviderService  _configsProvider;
    private MapDataConfig _mapDataConfig;
    private MoleData _moleData;
    private InputService _inputService;
    
    private bool _isHavePopUpMole;
    private float _popUpDuration;
    private float _popUpInterval;

    private float _elapsedTime;

    public event Action OnMoleHitted;
    public event Action OnMoleMissed;

    public MoleGameService(ConfigsProviderService configsProvider, MoleHoleRepository moleHoleRepository, InputService inputService)
    {
        _configsProvider = configsProvider;
        _repository = moleHoleRepository;
        _inputService = inputService;
    }

    public void Start()
    {
        _mapDataConfig = _configsProvider.GetConfig<MapDataConfig>();
        _popUpDuration = _mapDataConfig.PopUpDuration;
        _popUpInterval = _mapDataConfig.PopUpInterval;
    }

    public void Tick()
    {
        if (_isHavePopUpMole)
            LowerMole();
        else
            LiftMole();
        
        HandleInput();
    }

    private void LiftMole()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _popUpInterval)
        {
            int index = Random.Range(0, _repository.MoleHoleData.Count);

            if (TryGetMole(index, out MoleData mole))
                _moleData = mole;
            else
                return;
                
            ChangeHoleState(true);
        }
    }

    private void LowerMole()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _popUpDuration)
        {
            ChangeHoleState(false);
            
            OnMoleMissed?.Invoke();
        }
    }

    private void ChangeHoleState(bool state)
    {
        _moleData.ChangeState(state);
        _isHavePopUpMole = state;
        _elapsedTime = 0f;
    }

    private void HandleInput()
    {
        for (int i = 0; i < _inputService.NumberKeys.Length; i++)
        {
            if (Keyboard.current[_inputService.NumberKeys[i]].wasPressedThisFrame)
                TryHit(i);
        }
    }

    private void TryHit(int index)
    {
        if (TryGetMole(index, out MoleData mole))
        {
            if (mole.IsActive)
            {
                ChangeHoleState(false);
                
                OnMoleHitted?.Invoke();
            }
        }
            
    }

    private bool TryGetMole(int index,  out MoleData mole)
    { 
        mole = _repository.GetMole(_mapDataConfig.Field.Holes[index].name);
        
        if (mole == null)
        {
            Debug.LogError($"Mole  not found");
            return false;
        }

        return true;
    }
}
