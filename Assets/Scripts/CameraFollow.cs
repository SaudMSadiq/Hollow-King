using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    public float smoothSpeed = 4f;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private float fixedZ;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
        
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        float targetX = Mathf.Clamp(player.position.x, minX, maxX);
        float targetY = Mathf.Clamp(player.position.y, minY, maxY);

        Vector3 targetPosition = new Vector3(targetX, targetY, fixedZ);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);
    }
}