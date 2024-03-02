// LetterBox.cs

using UnityEngine;
using UnityEngine.EventSystems;

public class LetterBox : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        AutoDraggable draggable = eventData.pointerDrag.GetComponent<AutoDraggable>();
        if (draggable != null && !draggable.IsLocked)
        {
            draggable.ReturnToOriginalPosition(); // Return to original position in the letter box
        }
    }
}
