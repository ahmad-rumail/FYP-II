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

        // Iterate through each object in the grid
        for (int x = 0; x < gridManager.gridSizeX; x++)
        {
            // Get the correct tag for the current object
            string correctTag = correctTagsSequence[x];

            // Check if the blocks in the current object match the correct tag sequence
            for (int y = 0; y < gridManager.gridSizeY; y++)
            {
                Transform currentBlock = gridArray[x, y];

                // Check if the block exists and has the correct tag
                if (currentBlock == null || !currentBlock.CompareTag(correctTag))
                {
                    // If any block does not match the correct tag, return false
                    return false;
                }
            }
        }

        // If all objects have the correct blocks in the correct positions, return true
        return true;
    }
}
