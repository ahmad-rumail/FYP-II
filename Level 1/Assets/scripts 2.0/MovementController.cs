using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    // Create a list to store the movements
    private List<string> movements = new List<string>();

    // Create a reference to the button prefab
    public GameObject buttonPrefab;

    // Create a reference to the panel to display the button images
    public Transform buttonPanel;

    // Create a reference to the character to move
    public Transform character;

    // Create a function to handle button presses
    public void ButtonPress(string buttonName)
    {
        // Add the button name to the movements list
        movements.Add(buttonName);
        // Instantiate a button prefab and display it in the panel
        GameObject buttonInstance = Instantiate(buttonPrefab, buttonPanel);
        buttonInstance.GetComponentInChildren<Text>().text = buttonName;
    }

    // Create a function to play back the movements
    public void PlayMovements()
    {
        // Start a Coroutine to animate the character movement
        StartCoroutine(PlayMovementsCoroutine());
    }

    // Create a Coroutine to play back the movements
    private IEnumerator PlayMovementsCoroutine()
    {
        // Loop through the movements list
        foreach (string movement in movements)
        {
            // Move the character based on the current movement
            if (movement == "left")
            {
                // Move left
                character.position += new Vector3(-1, 0, 0);
            }
            else if (movement == "right")
            {
                // Move right
                character.position += new Vector3(1, 0, 0);
            }
            else if (movement == "forward")
            {
                // Move forward
                character.position += new Vector3(0, 0, 1);
            }
            // Wait for a short period of time before moving to the next movement
            yield return new WaitForSeconds(0.5f);
        }
    }
}