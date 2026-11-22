using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;
using Random = UnityEngine.Random;

internal sealed class MoleGameService : ITickable
{
    private readonly MoleHoleRepository _repository;
    private readonly InputService _inputService;
    private readonly List<MoleData> _freeMoles = new();

    private LevelConditions _conditions;
    private bool _isRunning;
    private float _nextPopUp;

    public event Action OnMoleHitted;
    public event Action OnMoleMissed;

    public MoleGameService(MoleHoleRepository repository, InputService inputService)
    {
        _repository = repository;
        _inputService = inputService;
    }

    public void Start(LevelConditions conditions)
    {
        _conditions = conditions;
        _nextPopUp = Time.time + conditions.PopUpInterval;
        _isRunning = true;
    }

    public void Stop()
    {
        _isRunning = false;

        for (int i = 0; i < _repository.Count; i++)
            _repository.GetMole(i).Hide();
    }

    public void Tick()
    {
        if (_isRunning == false)
            return;

        float time = Time.time;

        for (int i = 0; i < _repository.Count && _isRunning; i++)
        {
            MoleData mole = _repository.GetMole(i);

            if (mole.IsActive == false)
                continue;

            if (time >= mole.HideAt)
            {
                mole.Hide();
                OnMoleMissed?.Invoke();
            }
            else if (_inputService.IsNumberPressed(i + 1))
            {
                mole.Hide();
                OnMoleHitted?.Invoke();
            }
        }

        if (_isRunning && time >= _nextPopUp)
        {
            _nextPopUp = time + _conditions.PopUpInterval;
            LiftMole(time);
        }
    }

    private void LiftMole(float time)
    {
        _freeMoles.Clear();

        for (int i = 0; i < _repository.Count; i++)
        {
            MoleData mole = _repository.GetMole(i);

            if (mole.IsActive == false)
                _freeMoles.Add(mole);
        }

        if (_freeMoles.Count > 0)
            _freeMoles[Random.Range(0, _freeMoles.Count)].Show(time + _conditions.PopUpDuration);
    }
}
