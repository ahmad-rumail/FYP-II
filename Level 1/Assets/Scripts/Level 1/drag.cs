using UnityEngine;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        AutoDraggable draggable = eventData.pointerDrag.GetComponent<AutoDraggable>();
        if (draggable != null && !draggable.IsLocked)
        {
            draggable.parentToReturnTo = transform;
            draggable.GetComponent<RectTransform>().SetParent(transform);
        }
    }
}
