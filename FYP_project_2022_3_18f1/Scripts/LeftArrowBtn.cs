using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftArrowBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Bike_controller.isLeftbtn = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Bike_controller.isLeftbtn = false;
    }
}
