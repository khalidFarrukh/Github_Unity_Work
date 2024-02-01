using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightArrowBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Bike_controller.isRightbtn = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Bike_controller.isRightbtn = false;
    }
}
