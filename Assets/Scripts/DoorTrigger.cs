using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
    public Transform doorEnterPoint;
    public LevelLoader levelLoader;
    public float moveSpeed = 2f;

    private bool isEntering = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isEntering)
        {
            if (KeyPickup.hasKey)
            {
                StartCoroutine(EnterDoor(other.gameObject));
            }
            else
            {
                Debug.Log("You need the key first.");
            }
        }
    }

    IEnumerator EnterDoor(GameObject player)
    {
        isEntering = true;

        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            if (script.GetType().Name == "Player" || script.GetType().Name == "PlayerAttack")
            {
                script.enabled = false;
            }
        }

        while (Vector2.Distance(player.transform.position, doorEnterPoint.position) > 0.05f)
        {
            player.transform.position = Vector2.MoveTowards(
                player.transform.position,
                doorEnterPoint.position,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }

        player.transform.position = doorEnterPoint.position;

        if (levelLoader != null)
        {
            levelLoader.LoadNextLevel();
        }
    }
}