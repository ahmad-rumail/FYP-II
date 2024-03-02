using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;
    public float colorChangeDuration = 1.0f; // Duration for which the color remains changed

    private Image dropZoneImage;

    private void Start()
    {
        dropZoneImage = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeHolderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeHolderParent == this.transform)
        {
            d.placeHolderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " dropped on " + gameObject.name + ". Expected Tag: " + gameObject.tag);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;

            // Check if the dropped item is in the correct position
            if (IsCorrectPosition(d.gameObject.tag))
            {
                Debug.Log("Correct position!");
                StartCoroutine(ColorObject(d.gameObject, correctColor));
            }
            else
            {
                Debug.Log("Incorrect position!");
                StartCoroutine(ColorObject(d.gameObject, incorrectColor));
            }
        }
    }

    private bool IsCorrectPosition(string draggedTag)
    {
        // Implement your logic to determine if the dragged object is in the correct position
        // Here, we compare the tag of the dragged object with the expected tag for this drop zone
        Debug.Log("Dragged Tag: " + draggedTag);
        Debug.Log("Expected Tag: " + gameObject.tag);
        return draggedTag == gameObject.tag;
    }

    private IEnumerator ColorObject(GameObject obj, Color color)
    {
        // Change the color of the object
        obj.GetComponent<Image>().color = color;

        // Wait for a duration
        yield return new WaitForSeconds(colorChangeDuration);

        // Revert the color back to its original color
        obj.GetComponent<Image>().color = Color.white; // Change this to the original color if it's not white
    }
}
