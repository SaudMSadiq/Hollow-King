using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LevelCompleteUI : MonoBehaviour
{
    public GameObject xpBarObject;
    public Slider xpBar;
    public GameObject levelCompleteTextObject;

    public void ShowLevelComplete()
    {
        xpBarObject.SetActive(true);
        levelCompleteTextObject.SetActive(true);

        StartCoroutine(FillXPBar());
    }

    IEnumerator FillXPBar()
    {
        xpBar.value = 0;

        while (xpBar.value < xpBar.maxValue)
        {
            xpBar.value += 40f * Time.deltaTime;
            yield return null;
        }

        xpBar.value = xpBar.maxValue;
    }
}