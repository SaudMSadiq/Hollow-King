using UnityEngine;

public class BossDialogueTrigger : MonoBehaviour
{
    public BossDialogue dialogue; // assign the BossDialogue script in inspector

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;

        if (collision.CompareTag("Player"))
        {
            triggered = true;
            dialogue.Play(); // start the boss dialogue
            //Destroy(gameObject); // optional: remove the trigger
        }
    }
}