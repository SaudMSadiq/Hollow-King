using System.Collections;
using UnityEngine;

public class BoxBounce : MonoBehaviour
{
    private bool isMoving = false;
    public float moveSpeed = 3f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            float direction = transform.position.x < other.transform.position.x ? -1f : 1f;
            StartCoroutine(MoveAway(direction));
        }
    }

    private IEnumerator MoveAway(float direction)
    {
        float timer = 0f;

        while (timer < 0.35f)
        {
            transform.position = new Vector3(
                transform.position.x + direction * moveSpeed * Time.deltaTime *0.5f,
                transform.position.y,
                transform.position.z
            );

            timer += Time.deltaTime;
            yield return null;
        }

        
    }
}