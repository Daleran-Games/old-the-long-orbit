using UnityEngine;
using System.Collections;
using DalLib;


namespace TheLongOrbit
{
    public class UIManager : Singleton<UIManager>
    {

        protected UIManager () { }

        [SerializeField]
        private GameObject tooltipPrefab;

        private GameObject tooltipObject;
        private UITooltipPanel tooltipScript;

        void Awake ()
        {
            
            tooltipObject = (GameObject) Instantiate(tooltipPrefab, this.transform.parent);
            tooltipScript = tooltipObject.GetRequiredComponent<UITooltipPanel>();
            tooltipObject.SetActive(false);
        }

        public void ShowTooltip (Vector2 location, Tooltip tooltip)
        {
            tooltipObject.SetActive(true);
            tooltipScript.GenerateTooltip(tooltip);
            tooltipScript.MoveToPosition(location);
        }

        public void HideTooltip ()
        {
            tooltipScript.ClearEntries();
            tooltipObject.SetActive(false);
        }

    }

}
