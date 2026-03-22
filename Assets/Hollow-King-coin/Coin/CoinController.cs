using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Sprite[] frames;
    public float frameTime = 0.4f;

    private SpriteRenderer sr;
    private int index = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(NextFrame), frameTime, frameTime);
    }

    void NextFrame()
    {
        if (frames == null || frames.Length == 0 || sr == null)
            return;

        sr.sprite = frames[index];
        index++;

        if (index >= frames.Length)
            index = 0;
    }
}