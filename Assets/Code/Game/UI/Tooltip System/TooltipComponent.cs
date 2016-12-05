using UnityEngine;
using System.Collections;


namespace TheLongOrbit
{
    public class TooltipComponent : MonoBehaviour
    {
        [SerializeField]
        private Tooltip tooltip;


        [ReadOnly]
        [SerializeField]
        private bool tooltipActive = false;

        void OnMouseEnter ()
        {
            if (tooltip != null)
            {
                tooltipActive = true;
                UIManager.Instance.ShowTooltip(Input.mousePosition, tooltip);
            }
                
        }

        void OnMouseExit ()
        {
            if (tooltip != null)
            {
                tooltipActive = false;
                UIManager.Instance.HideTooltip();
            }
                
        }

        public void SetTooltip (Tooltip tooltip)
        {
            this.tooltip = tooltip;
        }
      
    }
}

