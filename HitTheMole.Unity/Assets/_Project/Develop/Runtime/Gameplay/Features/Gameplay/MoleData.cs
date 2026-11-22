using UnityEngine;

public class MoleData : MonoBehaviour
{
    public bool IsActive => gameObject.activeSelf;
    internal float HideAt { get; private set; }

    internal void Show(float hideAt)
    {
        HideAt = hideAt;
        gameObject.SetActive(true);
    }

    internal void Hide() => gameObject.SetActive(false);
}
