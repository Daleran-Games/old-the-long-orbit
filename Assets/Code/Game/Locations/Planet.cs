using UnityEngine;
using System.Collections;
using System;

namespace TheLongOrbit
{
    public class Planet : MonoBehaviour, INameable, IDescribable
    {

        [SerializeField]
        private string planetName = "Default Location";
        [SerializeField]
        [TextArea]
        private string description = "Default Location Description";
          [SerializeField]
        private int tooltipPriority = 1;


        public string GetObjectName()
        {
            return planetName;
        }

        public string GetRichTextBasicInfo()
        {
            string head = UIManager.Instance.Style.Heading.ApplyTextSyle(planetName);
            string foot = UIManager.Instance.Style.Footnote.ApplyTextSyle(description);

            return head + Environment.NewLine + foot;
        }

        public int GetPriority()
        {
            return tooltipPriority;
        }
    }
}
