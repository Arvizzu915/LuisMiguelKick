using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed = 12f;

    private Vector3 moveDirection = Vector3.zero;

    private InputAction move;

    private void OnEnable()
    {
        move = InputManager.Instance.inputs.Playing.Move;
    }

    private void Update()
    {
        moveDirection.x = move.ReadValue<Vector2>().x;
        moveDirection.z = move.ReadValue<Vector2>().y;

        controller.Move(speed * Time.deltaTime * moveDirection);

        if (moveDirection.sqrMagnitude > 0.001f)
        {
            Vector3 targetDir = moveDirection.normalized;
            Quaternion targetRot = Quaternion.LookRotation(targetDir, Vector3.up);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
