using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridManager gridManager;
    public string[] correctTagsSequence; // Array to hold the correct sequence of block tags

    private void Update()
    {
        if (gridManager == null)
        {
            Debug.LogWarning("GridManager reference is null.");
            return; // Return early to avoid further execution if gridManager is null
        }

        if (CheckCompletion())
        {
            // Trigger completion event
            Debug.Log("Level completed!");
        }
    }

    private bool CheckCompletion()
    {
        Transform[,] gridArray = gridManager.gridArray;

        if (gridArray == null)
        {
            Debug.LogWarning("Grid array is null.");
            return false; // Return false if gridArray is null
        }

        // Check if all blocks are in correct positions
        for (int x = 0; x < gridManager.gridSizeX; x++)
        {
            for (int y = 0; y < gridManager.gridSizeY; y++)
            {
                // Get the block at the current position
                Transform currentBlock = gridArray[x, y];

                // Check if the current block exists and has the correct tag
                if (currentBlock != null && currentBlock.CompareTag(correctTagsSequence[y * gridManager.gridSizeX + x]) == false)
                {
                    // If any block is not in the correct position, return false
                    return false;
                }
            }
        }

        // If all blocks are in correct positions, return true
        return true;
    }
}
