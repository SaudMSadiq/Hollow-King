using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public float smoothSpeed = 4f;

    private float fixedY;
    private float fixedZ;
    
    void Start()
    {
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, fixedY, fixedZ);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);
    }
}
