using UnityEngine;
using System.Collections.Generic;

namespace TheLongOrbit
{
    [System.Serializable]
    public class Tooltip
    {
        [SerializeField]
        [ReadOnly]
        Sprite icon;

        [SerializeField]
        [ReadOnly]
        string header;

        [SerializeField]
        [ReadOnly]
        TooltipEntry[] tooltipEntries;

        public Tooltip (string tooltipHeader, Sprite tooltipIcon, params TooltipEntry[] tooltipEntries)
        {
            header = tooltipHeader;
            icon = tooltipIcon;
            this.tooltipEntries = tooltipEntries;
        }

        public Tooltip(string tooltipHeader, params TooltipEntry[] tooltipEntries)
        {
            header = tooltipHeader;
            this.tooltipEntries = tooltipEntries;
        }

        public Sprite GetIcon ()
        {
            return icon;
        }

        public string GetHeader ()
        {
            return header;
        }

        public TooltipEntry[] GetTooltipEntries ()
        {
            return tooltipEntries;
        }

    }
}