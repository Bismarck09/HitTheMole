using System;

internal sealed class LevelData : IDisposable
{
    private readonly MoleGameService _moleGameService;

    private LevelConditions _conditions;
    private int _points;

    public int AccumulatedGold { get; private set; }
    public int Health { get; private set; }
    public bool IsFinished { get; private set; }
    public bool IsWon { get; private set; }

    public event Action OnFinished;

    public LevelData(MoleGameService moleGameService)
    {
        _moleGameService = moleGameService;
    }

    public void Initialize(LevelConditions conditions)
    {
        _conditions = conditions;
        Health = conditions.Health;

        _moleGameService.OnMoleHitted += HitMole;
        _moleGameService.OnMoleMissed += MissMole;
    }

    public void Dispose()
    {
        _moleGameService.OnMoleHitted -= HitMole;
        _moleGameService.OnMoleMissed -= MissMole;
    }

    private void HitMole()
    {
        _points++;
        AccumulatedGold += _conditions.GoldPerClick;

        DebugProgress();

        if (_points >= _conditions.CountPointsRequiredToWin)
            Finish(true);
    }

    private void MissMole()
    {
        Health--;

        DebugProgress();

        if (Health == 0)
        {
            AccumulatedGold = 0;
            Finish(false);
        }
    }

    private void Finish(bool isWon)
    {
        IsWon = isWon;
        IsFinished = true;

        OnFinished?.Invoke();
    }

    private void DebugProgress()
    {
        UnityEngine.Debug.Log($"Попадания: {_points}/{_conditions.CountPointsRequiredToWin}, жизни: {Health}, золото за забег: {AccumulatedGold}");
    }
}
