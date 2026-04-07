using UnityEngine;
using System.Collections;

public class EndScreenManager : MonoBehaviour
{
    public GameObject endScreen;
    public float fadeDuration = 2f;

    public void GameEnd()
    {
        endScreen.SetActive(true);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        SpriteRenderer[] sprites = endScreen.GetComponentsInChildren<SpriteRenderer>();

        // Set all to invisible first
        foreach (var sr in sprites)
        {
            Color c = sr.color;
            c.a = 0f;
            sr.color = c;
        }

        float time = 0f;
        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            foreach (var sr in sprites)
            {
                Color c = sr.color;
                c.a = alpha;
                sr.color = c;
            }
            time += Time.deltaTime;
            yield return null;
        }

        // Ensure fully visible at the end
        foreach (var sr in sprites)
        {
            Color c = sr.color;
            c.a = 1f;
            sr.color = c;
        }
    }
}