using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public GameObject grid;
    public string correctSequence = "PRINT(HELLO)";

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            string blockName = eventData.pointerDrag.name;
            int index = correctSequence.IndexOf(blockName);
            if (index != -1)
            {
                RectTransform dropRect = transform as RectTransform;
                RectTransform dragRect = draggable.transform as RectTransform;

                dragRect.SetParent(dropRect);
                dragRect.anchoredPosition = Vector2.zero;

                correctSequence = correctSequence.Remove(index, 1);

                if (correctSequence.Length == 0)
                {
                    Debug.Log("Level complete!");
                }
            }
            else
            {
                draggable.transform.position = draggable.StartPosition;
            }
        }
    }
}
