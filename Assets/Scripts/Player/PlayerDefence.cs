using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public bool isBlocking = false;

    void Update()
    {
        if (Input.GetMouseButton(1)) // Right mouse button held
        {
            isBlocking = true;
        }
        else
        {
            isBlocking = false;
        }
    }
}