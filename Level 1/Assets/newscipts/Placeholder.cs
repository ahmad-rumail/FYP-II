using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Placeholder : MonoBehaviour, IDropHandler
{
    public bool correctPosition;

    public void OnDrop(PointerEventData eventData)
    {
        DragDrop dropObject = eventData.pointerDrag.GetComponent<DragDrop>();

        if (dropObject.placeholder == null && correctPosition)
        {
            dropObject.placeholder = transform;
            dropObject.transform.position = transform.position;
            dropObject.canvasGroup.alpha = 1;
            dropObject.canvasGroup.interactable = true;
            dropObject.SetCorrectPosition(true);

            // Check if all objects are in the correct position
            if (CheckCorrectPosition())
            {
                // Display a success message here
            }
        }
    }

    private bool CheckCorrectPosition()
    {
        bool correct = true;

        // Replace this with your own check for correct position
        foreach (Transform child in transform.parent)
        {
            DragDrop dropObject = child.GetComponent<DragDrop>();
            if (dropObject.placeholder != transform)
            {
                correct = false;
                break;
            }
        }

        return correct;
    }
}