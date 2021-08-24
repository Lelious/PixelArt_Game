using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private float offset = 0f;
    private void FixedUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + offset, -1);
    }
}
