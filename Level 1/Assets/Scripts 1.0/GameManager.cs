using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Button checkButton; // Reference to the button
    public TextMeshProUGUI consoleText; // Text component to display messages
    public Transform dropZone; // Reference to the drop zone

    public List<Draggable> draggables = new List<Draggable>();
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject missingPanel;
private void Start()
{
    checkButton.onClick.AddListener(OnCheckButtonClicked); // Add listener to the button
    // Set button text to empty string
    checkButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
}

    private void OnCheckButtonClicked()
    {
        // Get the sequence of the draggable objects in the drop zone
        List<string> sequence = dropZone.GetComponentsInChildren<Draggable>()
            .Select(d => d.gameObject.tag) // Use tags instead of names
            .ToList();

        // Debug log to check the sequence of tags
        Debug.Log("Sequence of Tags: " + string.Join(", ", sequence));

        bool correctSequence = CheckSequence(sequence);

        if (correctSequence)
        {
            //consoleText.text = "Pass";
            winPanel.SetActive(true);
            losePanel.SetActive(false);
            missingPanel.SetActive(false);
        }
        else
        {
            //consoleText.text = "Fail";
            winPanel.SetActive(false);
            losePanel.SetActive(true);
            missingPanel.SetActive(false);
        }

        // Check for missing elements
        if (sequence.Count != draggables.Count)
        {
           // consoleText.text += ", Elements missing";
            winPanel.SetActive(false);
            losePanel.SetActive(false);
            missingPanel.SetActive(true);
        }
    }

    private bool CheckSequence(List<string> sequence)
    {
        // Define the correct sequence of tags
        List<string> correctSequence = new List<string> { "P", "R", "I", "N", "T", "(", "Q1", "H", "E", "L1", "L1", "O", "Q1", ")" };

        // Check if the sequence matches the correct sequence
        return sequence.SequenceEqual(correctSequence);
    }
}
