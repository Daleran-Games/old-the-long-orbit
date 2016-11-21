using UnityEngine;
using System.Collections;

namespace TheLongOrbit
{
    [System.Serializable]
    public class TooltipEntry
    {
        [SerializeField]
        [ReadOnly]
        string text;

        [SerializeField]
        [ReadOnly]
        Color textColor;

        public TooltipEntry(string tooltipEntryText)
        {
            text = tooltipEntryText;
            textColor = Color.white;
        }

        public TooltipEntry (string tooltipEntryText, Color tooltipEntryColor)
        {
            text = tooltipEntryText;
            textColor = tooltipEntryColor;
        }

        public string GetText ()
        {
            return text;
        }

        public Color GetTextColor ()
        {
            return textColor;
        }
    }
}