/*using unityengine;

public class gamemanager : monobehaviour
{
    public gridmanager gridmanager;
    public string[] correcttagssequence; // array to hold the correct sequence of block tags

    private void update()
    {
        if (gridmanager == null)
        {
            debug.logwarning("gridmanager reference is null.");
            return; // return early to avoid further execution if gridmanager is null
        }

        if (checkcompletion())
        {
            // trigger completion event
            debug.log("level completed!");
        }
    }

    private bool checkcompletion()
    {
        transform[,] gridarray = gridmanager.gridarray;

        if (gridarray == null)
        {
            debug.logwarning("grid array is null.");
            return false; // return false if gridarray is null
        }

        // check if all blocks are in correct positions
        for (int x = 0; x < gridmanager.gridsizex; x++)
        {
            for (int y = 0; y < gridmanager.gridsizey; y++)
            {
                // get the block at the current position
                transform currentblock = gridarray[x, y];

                // check if the current block exists and has the correct tag
                if (currentblock != null && currentblock.comparetag(correcttagssequence[y * gridmanager.gridsizex + x]) == false)
                {
                    // if any block is not in the correct position, return false
                    return false;
                }
            }
        }

        // if all blocks are in correct positions, return true
        return true;
    }
}
*/
