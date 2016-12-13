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

        public void OnPointerEnter(PointerEventData eventData)
        {
            UIManager.Instance.ShowGameTooltip(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UIManager.Instance.HideGameTooltip();
        }

    }
}
