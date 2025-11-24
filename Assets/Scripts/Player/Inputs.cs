using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public PlayerInputs inputs;

    private void Awake()
    {
        Instance = this;

        inputs = new PlayerInputs();

        inputs.Playing.Enable();
    }
}
