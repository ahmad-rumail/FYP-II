/*using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Sequence : MonoBehaviour, IDropHandler
{
    public GameObject grid;
    private Vector3 cellPosition;
    public Draggable draggableBlock;

    private void Start()
    {
        grid = GameObject.Find("Grid");
    }

    // Variable to store the correct sequence of the blocks
    private string correctSequence = "PRINT(HELLO)#IF";

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Save the starting position of the block
        draggableBlock.startPosition = transform.position;

        // Store the position of the cell where the block was dropped
        cellPosition = transform.parent.InverseTransformPoint(transform.localPosition);
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Get the block that was dropped
        GameObject block = eventData.pointerDrag.gameObject;

        // Check if the block is in the correct sequence
        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (block.name == correctSequence[i].ToString())
            {
                // Move the block to the new location
                block.transform.SetParent(grid.transform);
                block.transform.position = grid.transform.TransformPoint(cellPosition + new Vector3(0, grid.transform.position.y, 0));

                // Remove the block from the correct sequence
                correctSequence = correctSequence.Remove(i, 1);
                break;
            }
        }

        // If the block is not in the correct sequence, move it back to its starting position
        if (correctSequence.Length > 0)
        {
            // Move the block back to its starting position
            block.transform.SetParent(block.transform.parent);
            block.transform.position = draggableBlock.startPosition;
        }

        // Check if the sequence is complete
        if (correctSequence.Length == 0)
        {
            Debug.Log("Level complete!");
        }
    }
}*/