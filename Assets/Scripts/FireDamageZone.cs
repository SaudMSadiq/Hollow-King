using UnityEngine;
using UnityEngine.SceneManagement;

public class FireDamageZone : MonoBehaviour
{
    public GameObject fireGroup;
    public float damageInterval = 0.5f;
    public int damageAmount = 1;

    private float timer = 0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (fireGroup == null || !fireGroup.activeSelf) return;
        if (!other.CompareTag("Player")) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);

                if (health.health <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }

            timer = damageInterval;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0f;
        }
    }
}