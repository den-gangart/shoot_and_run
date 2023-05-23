using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RunShooter.InputSystem
{
    public class UIFirePlacement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,  IDragHandler
    {
        public Vector2 Direction { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Direction = (eventData.position - screenCenter).normalized;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Direction = Vector2.zero;
        }
    }
}
