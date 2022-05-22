using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class EventSystemExtensions
{
    public static T GetFirstComponentUnderPointer<T>(this EventSystem eventSystem, PointerEventData eventData)
        where T : class
    {
        var result = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, result);

        foreach (var raycastResult in result)
        {
            if (raycastResult.gameObject.TryGetComponent<T>(out T component))
            {
                return component;
            }
        }

        return null;
    }
}