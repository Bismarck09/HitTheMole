using System.Collections.Generic;

internal sealed class MoleHoleRepository
{
    private readonly List<MoleData> _moles = new();

    public int Count => _moles.Count;

    public void Add(MoleData mole) => _moles.Add(mole);

    public MoleData GetMole(int index) => _moles[index];
}
