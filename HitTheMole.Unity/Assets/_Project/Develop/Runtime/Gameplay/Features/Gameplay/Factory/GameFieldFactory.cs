using UnityEngine;

public class GameFieldFactory 
{
    public T Create<T>(T obj, Transform transform) where T : Object
    {
        return Object.Instantiate(obj, transform.position, transform.rotation);
    }
}
