using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisplay : MonoBehaviour
{
    // Create a reference to the panel to display the button images
    public Transform buttonPanel;

    // Create a reference to the button prefab
    public GameObject buttonPrefab;

    // Create a function to handle button presses
    public void ButtonPress()
    {
        // Instantiate a button prefab and display it in the panel
        GameObject buttonInstance = Instantiate(buttonPrefab, buttonPanel);
        buttonInstance.GetComponentInChildren<Image>().sprite = GetComponent<Image>().sprite;
    }
}