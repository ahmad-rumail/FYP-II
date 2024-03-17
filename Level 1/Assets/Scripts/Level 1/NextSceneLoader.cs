using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load

    private void Start()
    {
        // Ensure nextSceneName is set
        if (string.IsNullOrEmpty(nextSceneName))
        {
            Debug.LogWarning("Next scene name is not set in NextSceneLoader script.");
        }
    }

    public void LoadNextScene()
    {
        // Load the next scene
        SceneManager.LoadScene(1);
    }
    public void LoadNextScene2()
    {
        // Load the next scene
        SceneManager.LoadScene(2);
    }
    public void LoadNextScene3()
    {
        // Load the next scene
        SceneManager.LoadScene(0);
    }
}
