using UnityEngine;
using System.Collections;
using DalLib;


namespace TheLongOrbit
{
    public class UIManager : Singleton<UIManager>
    {

        protected UIManager () { }

        public UIStyle Style;
        [SerializeField]
        private GameObject tooltipPrefab;
        [SerializeField]
        private GameObject selectionPanelPrefab;
        [SerializeField]
        private Camera targetingCamera;
        [ReadOnly]
        [SerializeField]
        private bool uiTooltipLock = false;


        private GameObject gameTooltip;
        private TooltipPanelView gameTooltipView;

        private GameObject uiTooltip;
        private TooltipPanelView uiTooltipView;

        private GameObject selectionPanel;
        private SelectionPanelView selectionView;

        void Start ()
        {
            InstantiateGameTooltip();
        }

        void InstantiateGameTooltip()
        {
            gameTooltip = (GameObject) Instantiate(tooltipPrefab, transform);
            gameTooltipView = gameTooltip.GetRequiredComponent<TooltipPanelView>();
            gameTooltip.SetActive(false);
        }

        public void ShowGameTooltip (ShowTooltip tooltip)
        {
            gameTooltipView.Show(tooltip);
        }

        public void HideGameTooltip ()
        {
            gameTooltipView.Hide();
        }


    }

}
