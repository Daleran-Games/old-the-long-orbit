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
        [SerializeField]
        [TextArea]
        private string buttonDescription = "Action Description";
        [SerializeField]
        private int tooltipPriority = 0;
        [SerializeField]
        private bool supressTooltip = false;
        [ReadOnly]
        [SerializeField]
        private Selector currentSelection;
        [ReadOnly]
        [SerializeField]
        private Button launchButton;

        private Text buttonLabel;

        void Awake()
        {
            buttonLabel = GetComponentInChildren<Text>();
            launchButton = GetComponent<Button>();
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

        public int GetPriority()
        {
            return tooltipPriority;
        }

        public string GetRichTextBasicInfo()
        {
            string head = UIManager.Instance.Style.Heading.ApplyTextSyle(buttonTitle);
            string foot = UIManager.Instance.Style.Body.ApplyTextSyle(buttonDescription);

            return head + Environment.NewLine + foot;
        }

        public string GetObjectName()
        {
            return buttonTitle;
        }

        public bool IsSupressed()
        {
            return supressTooltip;
        }
    }
}

