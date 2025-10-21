using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Follow Settings")]
    public float smoothSpeed = 5f;
    public Vector2 xLimits = new Vector2(-3f, 3f); // Horizontal offset before camera moves
    public Vector2 yLimits = new Vector2(-2f, 2f); // Vertical offset before camera moves

    [Header("Camera Boundaries")]
    public float minX = 0f; // Left edge of background
    public float maxX = 50f; // Right edge of background
    public float minY = 0f; // Bottom edge (optional)
    public float maxY = 10f; // Top edge (optional)

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = transform.position;

        // Horizontal follow
        float offsetX = player.position.x - transform.position.x;
        if (offsetX > xLimits.y)
            targetPos.x = player.position.x - xLimits.y;
        else if (offsetX < xLimits.x)
            targetPos.x = player.position.x - xLimits.x;

        // Vertical follow
        float offsetY = player.position.y - transform.position.y;
        if (offsetY > yLimits.y)
            targetPos.y = player.position.y - yLimits.y;
        else if (offsetY < yLimits.x)
            targetPos.y = player.position.y - yLimits.x;

        // Smoothly move the camera
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);

        // Clamp to background edges
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );
    }
}
