using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrakeBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Bike_controller.isBrakingbtn = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Bike_controller.isBrakingbtn = false;
    }
}
