using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheLongOrbit
{
    public class InfoPanelView : TooltipPanelView
    {

        new void Awake()
        {
            base.Awake();
        }

        // Use this for initialization
        new void Start()
        {
            panelBackground.color = UIManager.Instance.Style.TooltipPanelColor;
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();
        }

        public override void Show(ShowTooltip tooltip)
        {
            gameObject.SetActive(true);
            InstantiateTextEntries(tooltip);
            Canvas.ForceUpdateCanvases();
        }

    }
}

