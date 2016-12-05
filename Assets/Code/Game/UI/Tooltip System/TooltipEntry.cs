using UnityEngine;
using System.Collections;

namespace TheLongOrbit
{
    [System.Serializable]
    public class TooltipEntry
    {
        [ReadOnly]
        public string Text;

        [ReadOnly]
        public Color TextColor;


        public TooltipEntry(string tooltipEntryText)
        {
            Text = tooltipEntryText;
            TextColor = Color.white;
        }

        public TooltipEntry (string tooltipEntryText, Color tooltipEntryColor)
        {
            Text = tooltipEntryText;
            TextColor = tooltipEntryColor;
        }

    }
}