using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerInputs inputs;

    private void Awake()
    {
        inputs = new PlayerInputs();

        inputs.Playing.Enable();
    }
}
