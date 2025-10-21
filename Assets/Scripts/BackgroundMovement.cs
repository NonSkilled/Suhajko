using UnityEngine;

public class MoveWithCamera : MonoBehaviour
{
    public Transform cameraTransform; // Assign your Main Camera here
    public float startFollowX = 40f;  // Camera X position where background starts moving
    public float moveSpeed = 1f;      // How fast the background moves with the camera

    private bool isFollowing = false;

    void Update()
    {
        if (cameraTransform == null) return;

        // Check if the camera reached the follow point
        if (!isFollowing && cameraTransform.position.x >= startFollowX)
            isFollowing = true;

        // Move background if following
        if (isFollowing)
        {
            transform.position = new Vector3(
                cameraTransform.position.x * moveSpeed,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
