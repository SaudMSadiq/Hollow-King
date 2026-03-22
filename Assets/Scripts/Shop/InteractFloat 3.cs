using UnityEngine;

public class InteractFloat : MonoBehaviour
{
    public float floatSpeed = 2f;
    
    void FixedUpdate()
    {
        float y = Mathf.Sin(Time.time * floatSpeed) * 0.1f;
        transform.localPosition = new Vector2(0, 3.4f + y);
    }
}
