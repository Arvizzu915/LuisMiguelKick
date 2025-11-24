using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 30, player.position.z - 20);
    }
}
