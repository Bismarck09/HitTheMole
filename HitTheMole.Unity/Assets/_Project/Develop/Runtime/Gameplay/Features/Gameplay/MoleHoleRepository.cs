using System.Collections.Generic;
using UnityEngine;

public class MoleHoleRepository
{
    private Dictionary<string, MoleData> _moleHoleData = new();

    public Dictionary<string, MoleData> MoleHoleData => _moleHoleData;

    public void Add(string holeID, MoleData moleData)
    {
        _moleHoleData.Add(holeID, moleData);
    }

    public MoleData GetMole(string holeID)
    {
        if (_moleHoleData.TryGetValue(holeID, out MoleData mole))
            return mole;

        return null;
    }
}
