using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class TimerBar : MonoBehaviour
{
    public float maxTime = 10f;
    public float startX = 1f;
    public float endX = 51f;
    public Transform player;
    public Player p;
    private float currentTime;
    private RectTransform rectTransform;
    private Vector2 startSize;
    private bool timerRunning = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startSize = rectTransform.sizeDelta;
        currentTime = maxTime;
    }

    private void Update()
    {
        CheckTimerZone();

        if (!timerRunning)
        {
            return;
        }

        currentTime -= Time.deltaTime*0.11f;

        if (currentTime < 0f)
        {
            currentTime = 0f;
            timerRunning = false;
            p.Die();
            
        }

        float percent = currentTime / maxTime;

        rectTransform.sizeDelta = new Vector2(
            startSize.x * percent,
            startSize.y
        );
    }

    private void CheckTimerZone()
    {
        if (player.position.x >= startX && player.position.x < endX)
        {
            timerRunning = true;
    
        }
        else if (player.position.x >= endX)
        {
            timerRunning = false;
        }
    }
}