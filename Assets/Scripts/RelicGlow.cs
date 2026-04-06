using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RelicGlow : MonoBehaviour
{
    public Light2D light2D;
    public float minIntensity = 1.5f;
    public float maxIntensity = 3f;
    public float speed = 2f;

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
    }
}