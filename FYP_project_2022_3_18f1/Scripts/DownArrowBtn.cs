using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownArrowBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Bike_controller.isDownbtn = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Bike_controller.isDownbtn = false;
    }
}
