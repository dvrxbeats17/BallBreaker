using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float minX = 1f;
    private float maxX = 15f;

    void Update()
    {
        Vector3 worldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldSpace.z = 0;
        worldSpace.y = transform.position.y;
        worldSpace.x = Mathf.Clamp(worldSpace.x, minX, maxX);
        transform.position = worldSpace;
    }
}
