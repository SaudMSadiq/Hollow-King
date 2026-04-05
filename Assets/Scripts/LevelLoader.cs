using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingCanvas;
    public string nextSceneName = "5";

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevelRoutine());
    }

    IEnumerator LoadLevelRoutine()
    {
        if (loadingCanvas != null)
        {
            loadingCanvas.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(nextSceneName);
    }
}