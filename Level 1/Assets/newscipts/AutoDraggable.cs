using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AutoDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector]
    public Transform parentToReturnTo = null;
    [HideInInspector]
    public Transform placeHolderParent = null;
    [HideInInspector]
    public bool IsLocked = false;
    [HideInInspector]
    public bool IsCorrect = false;

    private Vector3 startPosition;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsLocked)
        {
            parentToReturnTo = transform.parent;
            transform.SetParent(transform.parent.parent);
            startPosition = rectTransform.anchoredPosition;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsLocked)
        {
            rectTransform.anchoredPosition += eventData.delta / transform.lossyScale.x;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsLocked)
        {
            transform.SetParent(parentToReturnTo);
            rectTransform.anchoredPosition = startPosition;
            canvasGroup.blocksRaycasts = true;
            if (!IsCorrect)
            {
                ReturnToOriginalPosition();
            }
        }
    }

    public void ReturnToOriginalPosition()
    {
        transform.position = startPosition;
    }
}