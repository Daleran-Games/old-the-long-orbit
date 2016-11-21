using UnityEngine;
using System.Collections;


namespace TheLongOrbit
{
    public class TooltipComponent : MonoBehaviour
    {
        [SerializeField]
        private Tooltip tooltip;
           
        void OnMouseEnter ()
        {
            if (tooltip != null)
                UIManager.Instance.ShowTooltip(Input.mousePosition, tooltip);
        }

        void OnMouseExit ()
        {
            if (tooltip != null)
                UIManager.Instance.HideTooltip();
        }

        public void SetTooltip (Tooltip tooltip)
        {
            this.tooltip = tooltip;
        }
      
    }
}

