using UnityEngine;

public class InteractFloat : MonoBehaviour
{
    public float floatSpeed = 2f;
    
    void FixedUpdate()
    {
        float y = Mathf.Sin(Time.time * floatSpeed) * 0.1f;
        transform.position = new Vector2(transform.position.x, 3.4f + y);
    }
}
