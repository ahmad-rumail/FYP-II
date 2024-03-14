using System.Collections.Generic;
using UnityEngine;

public class MainBox : MonoBehaviour
{
    public Box[] boxes;
    public string[] requiredElements;

    private void Start()
    {
        if (CheckCompletion())
        {
            Debug.Log("All boxes are complete. Loading next scene...");
            // Load next scene here
        }
        else
        {
            Debug.Log("Some boxes are missing elements. Please check and try again.");
        }
    }

    private bool CheckCompletion()
    {
        HashSet<string> allElements = new HashSet<string>();
        foreach (Box box in boxes)
        {
            allElements.UnionWith(box.elements);
        }
        return allElements.SetEquals(requiredElements);
    }
}

[System.Serializable]
public class Box
{
    public string[] elements;
}