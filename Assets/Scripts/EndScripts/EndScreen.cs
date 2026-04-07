using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject endScreenUI;

    public void GameEnd()
    {
        endScreenUI.SetActive(true);
    }
}
