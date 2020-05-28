using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static DragItem dragItem;
    public Transform currentSlot;
    private Vector3 startPosition;
    private Transform startParrent;
    private CanvasGroup canvasGroup;
    private RectTransform dragLayer;
    private Transform slot;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        dragLayer = GameObject.FindGameObjectWithTag("DragLayer").GetComponent<RectTransform>();
        currentSlot = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        slot = null;
        dragItem = this;
        startPosition = transform.position;
        startParrent = transform.parent;
        transform.SetParent(dragLayer);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragItem = null;
        canvasGroup.blocksRaycasts = true;
        if (slot == null)
        {
            transform.SetParent(startParrent);
            transform.position = startPosition;
        }
        slot = null;
    }

    public void SetItemToSlot(Transform slot)
    {
        this.slot = slot;
        transform.SetParent(slot);
        currentSlot = slot;
        transform.localPosition = Vector3.zero;
    }
}
