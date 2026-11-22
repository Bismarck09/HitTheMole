using UnityEngine;

public class MoleData : MonoBehaviour
{
    private bool _isActive;
    
    public bool IsActive => _isActive;
    
    public void ChangeState(bool isActive)
    {
        _isActive = isActive;
        gameObject.SetActive(_isActive);
    }
}
