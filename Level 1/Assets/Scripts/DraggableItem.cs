using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private RectTransform rectTransform;

    public Vector3 StartPosition => startPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Canvas canvas = eventData.pointerDrag.GetComponent<Canvas>();
            if (canvas != null)
            {
                rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
            else
            {
                Debug.LogError("Canvas component is missing from the pointerDrag object: " + eventData.pointerDrag.name);
            }
        }
        else
        {
            Debug.LogError("pointerDrag object is null.");
        }
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
    }
}
