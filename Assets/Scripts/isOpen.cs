using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int startY;
    private bool isOpen = false;
    private float moveSpeed = 1f;
    private double targetY;


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
    if (isOpen && transform.position.y < 10)
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + moveSpeed * Time.deltaTime,
            transform.position.z
        );
    }

    // if (!isOpen && transform.position.y > startY)
    // {
    //     transform.position = new Vector3(
    //         transform.position.x,
    //         transform.position.y - moveSpeed * Time.deltaTime,
    //         transform.position.z
    //     );
    // }
}
}