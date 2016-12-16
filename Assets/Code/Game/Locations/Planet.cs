using UnityEngine;
using System.Collections;
using System;

namespace TheLongOrbit
{
    public class Planet : MonoBehaviour, INameable, IDescribable
    {

        [SerializeField]
        private string planetName = "Default Location";
        public string Name { get { return planetName; } }
        [SerializeField]
        [TextArea]
        private string description = "Default Location Description";
        [SerializeField]
        private int tooltipPriority = 1;
        public int TooltipPriority { get { return tooltipPriority; } }
        [SerializeField]
        private bool supressTooltip = false;
        public bool IsTooltipSuppressed { get { return supressTooltip; } }

        public string GetRichTextBasicInfo()
        {
            string head = UIManager.Instance.Style.Heading.ApplyTextSyle(planetName);
            string foot = UIManager.Instance.Style.Footnote.ApplyTextSyle(description);

            return head + Environment.NewLine + foot;
        }

    }
}
