using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Button retryButton;
    public Button mainMenuButton;
    public Button nextLevelButton;

    void Start()
    {
        // Add listeners to the buttons' onClick events
        retryButton.onClick.AddListener(Retry);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        nextLevelButton.onClick.AddListener(GoToNextLevel);
    }

    // Function to reload the current level
    void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Function to go back to the main menu
    void GoToMainMenu()
    {
        //SceneManager.LoadScene("MainMenu"); // Load the scene with the name "MainMenu"
    }

    // Function to move to the next level
    void GoToNextLevel()
    {
        // Assuming levels are numbered sequentially (e.g., Level1, Level2, Level3, ...)
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentLevelIndex + 1); // Load the next scene in the build settings
    }
}
