using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ScreenshotView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _date;

    private Transform _dragingParent;
    private Transform _previousParent;

    public void Init(Transform dragingParent)
    {
        _dragingParent = dragingParent;
    }

    public void Render(Screenshot screenshot)
    {
        _image.sprite = screenshot.Image;
        _date.text = screenshot.CreationTime.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _previousParent = transform.parent;
        transform.parent = _dragingParent;
        Debug.Log($"OnBeginDrag eventData {eventData}");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
        transform.position = eventData.position;
        // transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Debug.Log($"OnDrag eventData {eventData}");
        Debug.Log($"OnDrag transform.position {transform.position}");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var container = EventSystem.current.GetFirstComponentUnderPointer<DropContainer>(eventData);

        if (container != null)
        {
            transform.parent = container.Container;
        }
        else
        {
            transform.parent = _previousParent;
        }

        Debug.Log($"OnEndDrag transform.parent.position {transform.parent.position}");
    }
}