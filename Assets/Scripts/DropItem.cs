using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var item = DragItem.dragItem;
        var childrens = transform.GetComponentsInChildren<DragItem>();
        if (item != null && childrens.Length == 0)
        {
            item.SetItemToSlot(transform);
        }
        else if (item != null && childrens.Length > 0)
        {
            var slot = item.currentSlot;
            childrens[0].SetItemToSlot(slot);
            item.SetItemToSlot(transform);
        }
    }
}
