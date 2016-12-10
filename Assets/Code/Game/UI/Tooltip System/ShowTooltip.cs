using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheLongOrbit
{
    public class ShowTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public enum TooltipType
        {
            Game,
            UI
        }

        public TooltipType TooltipMode = TooltipType.Game;
        public bool IsShowing = false;

        void Awake()
        {

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (TooltipMode == TooltipType.Game)
            {
                UIManager.Instance.ShowGameTooltip(this);
            } else if (TooltipMode == TooltipType.UI)
            {
                Debug.Log("Not Implemented Yet");
            }
            Debug.Log("Pointer Enter Fired!");
            IsShowing = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (TooltipMode == TooltipType.Game)
            {
                UIManager.Instance.HideGameTooltip();
            }
            else if (TooltipMode == TooltipType.UI)
            {
                Debug.Log("Not Implemented Yet");
            }
            IsShowing = false;
        }

    }
}
