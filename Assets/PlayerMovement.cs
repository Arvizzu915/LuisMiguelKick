using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] InputManager inputManager;

    [SerializeField] private float speed;

    private Vector3 moveDirection = Vector3.zero;

    private InputAction move;

    private void OnEnable()
    {
        move = inputManager.inputs.Playing.Move;
    }

    private void Update()
    {
        moveDirection.x = move.ReadValue<Vector2>().x;
        moveDirection.z = move.ReadValue<Vector2>().y;

        controller.Move(speed * Time.deltaTime * moveDirection);
    }
}
