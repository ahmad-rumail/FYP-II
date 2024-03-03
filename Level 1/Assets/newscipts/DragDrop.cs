using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Transform placeholder;
    public bool correctPosition;
    public Image image;
    public CanvasGroup canvasGroup;

    private Vector2 startPosition;

    void Awake()
    {
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (placeholder != null)
        {
            if (correctPosition)
            {
                transform.position = placeholder.position;
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                placeholder = null;
            }
            else
            {
                transform.position = startPosition;
                canvasGroup.alpha = 0.5f;
                canvasGroup.interactable = false;
            }
        }
    }

    public void SetCorrectPosition(bool correct)
    {
        correctPosition = correct;
        image.color = correctPosition ? Color.green : Color.red;
    }
}