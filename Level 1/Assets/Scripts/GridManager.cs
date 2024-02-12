using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Transform[,] gridArray;
    public int gridSizeX = 5;
    public int gridSizeY = 5;
    public Vector2 blockSize = new Vector2(1, 1);

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        gridArray = new Transform[gridSizeX, gridSizeY];
        // Write code here to create a grid of appropriate size
    }

    // Other methods for managing the grid (e.g., placing blocks, checking completion) will go here
}
