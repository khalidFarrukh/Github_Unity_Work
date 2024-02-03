using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReverseGasBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Bike_controller.isReverseBtn = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Bike_controller.isReverseBtn = false;
    }
}
