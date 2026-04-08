using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public double startY;
    private bool isOpen = false;
    private float moveSpeed = 1f;


    public bool IsOpen
    {
        get { return isOpen; }
    }

    public void Open()
    {
        
        isOpen = true;
        Debug.Log("door open");
       
       
    }

    public void Close()
    {
        isOpen = false;
        Debug.Log("door close");
    }

    private void Update()
{
    if (isOpen && transform.position.y < startY + 10)
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + moveSpeed * Time.deltaTime,
            transform.position.z
        );
    }

    if (!isOpen && transform.position.y > startY)
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - moveSpeed * Time.deltaTime * 4f,
            transform.position.z
        );
    }
}
}