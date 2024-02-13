using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject[] objectsToDrag;
    public GameObject[] objectsDragToPos;

    public string correctSequence = "PRINT(\"HELLO\")";
    public float dropDistance;
    public bool[] isLocked;

    Vector2[] objectInitPos;
    private bool[] isDragging;

    void Start()
    {
        objectInitPos = new Vector2[objectsToDrag.Length];
        isLocked = new bool[objectsToDrag.Length];
        isDragging = new bool[objectsToDrag.Length];

        for (int i = 0; i < objectsToDrag.Length; i++)
        {
            objectInitPos[i] = objectsToDrag[i].transform.position;
        }
    }

    void Update()
    {
        for (int i = 0; i < objectsToDrag.Length; i++)
        {
            if (isDragging[i])
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                objectsToDrag[i].transform.position = new Vector2(mousePosition.x, mousePosition.y);
            }
        }
    }

    public void StartDrag(int index)
    {
        if (!isLocked[index])
        {
            isDragging[index] = true;
        }
    }

    public void EndDrag(int index)
    {
        if (!isLocked[index])
        {
            isDragging[index] = false;

            float distance = Vector3.Distance(objectsToDrag[index].transform.position, objectsDragToPos[index].transform.position);
            if (distance < dropDistance)
            {
                isLocked[index] = true;
                objectsToDrag[index].transform.position = objectsDragToPos[index].transform.position;

                // Check if the dropped block matches the correct sequence
                bool sequenceMatched = true;
                string currentSequence = "";
                for (int i = 0; i <= index; i++)
                {
                    currentSequence += objectsToDrag[i].name;
                }
                if (currentSequence != correctSequence.Substring(0, currentSequence.Length))
                {
                    sequenceMatched = false;
                }

                // Display result based on the matching condition
                if (sequenceMatched)
                {
                    Debug.Log("Correct order!");
                }
                else
                {
                    Debug.Log("Incorrect order. Try again!");
                    ResetBlocks();
                }
            }
            else
            {
                objectsToDrag[index].transform.position = objectInitPos[index];
            }
        }
    }

    void ResetBlocks()
    {
        for (int i = 0; i < objectsToDrag.Length; i++)
        {
            isLocked[i] = false;
            objectsToDrag[i].transform.position = objectInitPos[i];
        }
    }
}
