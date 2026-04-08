using System;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float startX = 10f;
    public float resetX = -10f;
    public Player p;

    private Boolean hit = false;

    private void Update()
    {
        transform.position = new Vector3(
            transform.position.x - moveSpeed * Time.deltaTime,
            transform.position.y,
            transform.position.z
        );

        if (transform.position.x <= resetX || hit == true)
        {
            transform.position = new Vector3(
                startX,
                transform.position.y,
                transform.position.z
            );
            hit = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        hit = true;
          
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = p.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(3);
        }
    }
}