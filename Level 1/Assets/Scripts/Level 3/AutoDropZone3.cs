using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class AutoDropZone3 : MonoBehaviour, IDropHandler
{
    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;
    public float correctColorDuration = 2f;
    public float incorrectColorDuration = 2f;
    public Transform letterBox; // Reference to the letter box transform

    // New public variable to store original color
    public Color originalColor;

    public int totalCorrectPlacementsNeeded = 5; // Total number of correct placements needed

    private int correctPlacements = 0;

    private void Start()
    {
        // Store the original color
        originalColor = GetComponent<Graphic>().color;
    }

    public void OnDrop(PointerEventData eventData)
    {
        AutoDraggable draggable = eventData.pointerDrag.GetComponent<AutoDraggable>();
        if (draggable != null && !draggable.IsLocked)
        {
            draggable.parentToReturnTo = transform;

            // Check if the dropped object has the correct tag
            if (CheckCorrectness(draggable.gameObject))
            {
                draggable.IsCorrect = true;
                draggable.IsLocked = true;
                SetColor(draggable.gameObject, correctColor);
                StartCoroutine(LockCorrectObject(draggable));

                correctPlacements++;

                // If correct tag is dropped, use grid layout group
                draggable.GetComponent<RectTransform>().SetParent(transform);

                // Check if all correct placements are achieved
                if (correctPlacements == totalCorrectPlacementsNeeded)
                {
                    Debug.Log("All correct placements achieved. Proceeding to next stage...");
                    // Proceed to the next stage or perform any desired action
                }
            }
            else
            {
                // Highlight the dropped object indicating it's incorrect
                SetColor(draggable.gameObject, incorrectColor);
                StartCoroutine(ReturnIncorrectObject(draggable));
            }

            // Rebuild layout to reposition elements correctly
            StartCoroutine(RebuildLayout());
        }
    }

    private IEnumerator RebuildLayout()
    {
        // Wait for one frame for layout rebuild
        yield return null;

        // Rebuild layout
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
    }

    private bool CheckCorrectness(GameObject droppedObject)
    {
        // Check if the dropped object has the "Int" tag
        return droppedObject.CompareTag("int");
    }

    private IEnumerator LockCorrectObject(AutoDraggable draggable)
    {
        yield return new WaitForSeconds(correctColorDuration);
        SetColor(draggable.gameObject, originalColor); // Reset color to original color
    }

    private IEnumerator ReturnIncorrectObject(AutoDraggable draggable)
    {
        yield return new WaitForSeconds(incorrectColorDuration);
        SetColor(draggable.gameObject, originalColor); // Reset color to original color

        // Return the incorrect object to its original position or the letter box
        if (draggable.IsLocked)
        {
            // Object is correctly placed, return it to its original position
            draggable.ReturnToOriginalPosition();
        }
        else
        {
            // Object is incorrectly placed, respawn it in the letter box
            if (letterBox != null)
            {
                // Instantiate a new instance of the incorrect object
                GameObject newObject = Instantiate(draggable.gameObject, letterBox.position, Quaternion.identity, letterBox);

                // Ensure it's an AutoDraggable component
                AutoDraggable newDraggable = newObject.GetComponent<AutoDraggable>();
                if (newDraggable != null)
                {
                    newDraggable.ReturnToOriginalPosition(); // Return to original position in the letter box
                }
                else
                {
                    Debug.LogWarning("AutoDraggable component not found on respawned object.");
                }
            }
            else
            {
                Debug.LogWarning("Letter box reference is not set in AutoDropZone script.");
            }

            // Remove the original object from the drop zone
            Destroy(draggable.gameObject);
        }
    }

    private void SetColor(GameObject obj, Color color)
    {
        Graphic graphic = obj.GetComponent<Graphic>();
        if (graphic != null)
        {
            graphic.color = color;
        }
    }
}
