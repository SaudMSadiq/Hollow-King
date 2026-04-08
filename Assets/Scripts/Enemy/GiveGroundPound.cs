using UnityEngine;

public class GiveGroundPound : MonoBehaviour
{
    public void GiveReward()
    {
        if (Player.Instance != null)
        {
            Player.Instance.groundPoundUnlocked = true;
            Debug.Log("Ground pound unlocked!");
        }
    }
}