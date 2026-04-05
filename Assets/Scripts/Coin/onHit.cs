using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour
{
    private bool collected = false;

    public Player player;

    private void Start()
    {
        player = Player.Instance;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        if (other.GetComponent<Player>() != null)
        {
            collected = true;
            player.gold+=5;

            Collider2D col = GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;

            StartCoroutine(MoveUpAndDisappear());
        }
    }

    private IEnumerator MoveUpAndDisappear()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(0f, 1f, 0f);

        float duration = 0.25f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        Destroy(gameObject);
    }
}