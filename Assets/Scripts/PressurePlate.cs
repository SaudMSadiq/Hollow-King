using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private bool isPressed = false;
    public Door door;
   
    private SpriteRenderer spriteRenderer;

    public bool IsPressed
    {
        get { return isPressed; }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            isPressed = true;
            Debug.Log("box1 awesrdn");
            spriteRenderer.color = Color.green;
            door.Open();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            isPressed = false;
            spriteRenderer.color = Color.red;
            door.Close();
        }

    }
}