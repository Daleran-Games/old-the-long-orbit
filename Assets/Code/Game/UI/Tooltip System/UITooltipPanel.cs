using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace TheLongOrbit
{
    public class UITooltipPanel : MonoBehaviour
    {

        [SerializeField]
        private Text headerText;
        [SerializeField]
        private Image tooltipImage;
        [SerializeField]
        private RectTransform tooltipEntriesParent;


        [SerializeField]
        private GameObject TooltipEntryPrefab;
        [SerializeField]
        private Sprite defaultIcon;

        private RectTransform panelRect;

        void Awake ()
        {
            panelRect = gameObject.GetRequiredComponent<RectTransform>();
        }

        public void MoveToPosition (Vector2 newPosition)
        {
            panelRect.position = newPosition;
        }

        public void GenerateTooltip (Tooltip newTooltip)
        {
            
            headerText.text = newTooltip.GetHeader();

            if (newTooltip.GetIcon() != null)
            {
                tooltipImage.sprite = newTooltip.GetIcon();
            }
            else
            {
                tooltipImage.sprite = defaultIcon;
            }

            foreach (TooltipEntry te in newTooltip.GetTooltipEntries())
            {
                GameObject newEntry = (GameObject)Instantiate(TooltipEntryPrefab, tooltipEntriesParent);
                newEntry.GetRequiredComponent<Text>().text = te.GetText();
                newEntry.GetRequiredComponent<Text>().color = te.GetTextColor();
            }
            
        }

        public void ClearEntries ()
        {
            tooltipEntriesParent.ClearChildren();
        }


    }
}

