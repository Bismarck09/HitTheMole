using System;
using UnityEngine;

[Serializable]
internal sealed class LevelConditions
{
    [SerializeField, Min(1)] private int _countPointsRequiredToWin = 10;
    [SerializeField, Min(1)] private int _health = 10;
    [SerializeField, Min(0.01f)] private float _popUpInterval = 1f;
    [SerializeField, Min(0.01f)] private float _popUpDuration = 1.5f;
    [SerializeField, Min(0)] private int _goldPerClick = 1;

    public int CountPointsRequiredToWin => _countPointsRequiredToWin;
    public int Health => _health;
    public float PopUpInterval => _popUpInterval;
    public float PopUpDuration => _popUpDuration;
    public int GoldPerClick => _goldPerClick;
}
