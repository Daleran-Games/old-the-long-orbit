using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheLongOrbit
{
    public class ActionButtonView : MonoBehaviour, IDescribable, INameable
    {

        [SerializeField]
        private string buttonTitle = "NewActionButton";
        public string Name { get { return buttonTitle; } }
        [SerializeField]
        [TextArea]
        private string buttonDescription = "Action Description";
        [SerializeField]
        private int tooltipPriority = 0;
        public int TooltipPriority { get { return tooltipPriority; } }
        [SerializeField]
        private bool supressTooltip = false;
        public bool IsTooltipSuppressed { get { return supressTooltip; } }
        [ReadOnly]
        [SerializeField]
        private Selector currentSelection;
        [ReadOnly]
        [SerializeField]
        private Button launchButton;

        private Text buttonLabel;
        private NavigationModule playerNavMod;

        void Awake()
        {
            buttonLabel = GetComponentInChildren<Text>();
            launchButton = GetComponent<Button>();
            playerNavMod = GameObject.FindGameObjectWithTag("Player").GetComponent<NavigationModule>();
        }
        // Use this for initialization
        void Start()
        {
            if (buttonLabel !=null)
            {
                buttonLabel.text = buttonTitle;
            }

            CommandManager.Instance.OnSelection += PlayerTargetSelected;

        }

        void OnDestroy()
        {
            CommandManager.Instance.OnSelection -= PlayerTargetSelected;
        }

        public void PlayerTargetSelected(Selector target)
        {
            currentSelection = target;
            if (target.GetComponent<NavBeacon>() != null)
                launchButton.interactable = true;
            else
                launchButton.interactable = false;
        }

        public string GetRichTextBasicInfo()
        {
            string head = UIManager.Instance.Style.Heading.ApplyTextSyle(buttonTitle);
            string foot = UIManager.Instance.Style.Body.ApplyTextSyle(buttonDescription);

            return head + Environment.NewLine + foot;
        }

    }
}

