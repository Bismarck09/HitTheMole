using UnityEngine.InputSystem;

internal sealed class InputService
{
    private static readonly Key[] NumberKeys =
    {
        Key.Digit1, Key.Digit2, Key.Digit3,
        Key.Digit4, Key.Digit5, Key.Digit6,
        Key.Digit7, Key.Digit8, Key.Digit9
    };

    public static int NumberKeyCount => NumberKeys.Length;

    public bool IsNumberPressed(int number) => IsPressed(NumberKeys[number - 1]);

    public bool IsPressed(Key key)
    {
        Keyboard keyboard = Keyboard.current;
        return keyboard != null && keyboard[key].wasPressedThisFrame;
    }
}
