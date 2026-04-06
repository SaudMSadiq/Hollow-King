using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingCanvas;
    public string nextSceneName = "5";

    public void LoadNextLevel()
    {
        Debug.Log("LoadNextLevel called");
        StartCoroutine(LoadLevelRoutine());
    }

    IEnumerator LoadLevelRoutine()
    {
        if (loadingCanvas != null)
        {
            Debug.Log("Showing loading canvas");
            loadingCanvas.SetActive(true);
        }
        else
        {
            Debug.Log("Loading canvas is NULL");
        }

        yield return new WaitForSeconds(2f);

        Debug.Log("Loading scene: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}