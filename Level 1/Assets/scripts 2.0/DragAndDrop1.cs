using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop1 : MonoBehaviour, IBeginDragHandler, IDropHandler
{
    // Create a reference to the prefab to instantiate
    public GameObject prefab;

    // Create a reference to the parent object to add the panel to
    public Transform parent;

    // Implement the IBeginDragHandler interface
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create a new panel and add it to the parent object
        GameObject newPanel = new GameObject("Panel");
        newPanel.transform.SetParent(parent);

        // Create a new RectTransform for the panel
        RectTransform panelRectTransform = newPanel.AddComponent<RectTransform>();
        panelRectTransform.anchoredPosition = Vector2.zero;
        panelRectTransform.sizeDelta = new Vector2(100, 100);

        // Create a new Image component for the panel
        Image panelImage = newPanel.AddComponent<Image>();
        panelImage.color = new Color(1, 1, 1, 0.1f);

        // Instantiate a new object and add it to the panel
        GameObject newObject = Instantiate(prefab, panelRectTransform);
        newObject.transform.position = transform.position;
    }

    // Implement the IDropHandler interface
    public void OnDrop(PointerEventData eventData)
    {
        // Do nothing when the object is dropped
    }
}