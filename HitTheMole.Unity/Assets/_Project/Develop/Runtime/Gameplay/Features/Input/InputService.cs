using UnityEngine;
using UnityEngine.InputSystem;

public class InputService
{
    private Key[] _numberKeys =
    {
        Key.Digit1, Key.Digit2, Key.Digit3,
        Key.Digit4, Key.Digit5, Key.Digit6,
        Key.Digit7, Key.Digit8, Key.Digit9
    };
    
    public Key[] NumberKeys => _numberKeys;
}
