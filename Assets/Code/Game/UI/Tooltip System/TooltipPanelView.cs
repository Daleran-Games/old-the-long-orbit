using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace TheLongOrbit
{
    public class TooltipPanelView : MonoBehaviour
    {

        [Header("Tooltip Panel Settings")]
        [SerializeField]
        private GameObject textPrefab;
        [SerializeField]
        private float offset;
        [SerializeField]
        private float width;

        [Header("Tooltip Components")]
        [ReadOnly]
        [SerializeField]
        private RectTransform thisRect;
        [ReadOnly]
        [SerializeField]
        private Image panelBackground;
        [ReadOnly]
        [SerializeField]
        private RectTransform canvasRect;


        private List<TextLinkEntry> textLinks = new List<TextLinkEntry>();

        void Awake()
        {
            thisRect = gameObject.GetRequiredComponent<RectTransform>();
            canvasRect = transform.root.GetComponent<RectTransform>();
            panelBackground = gameObject.GetRequiredComponent<Image>();
        }

        // Use this for initialization
        void Start()
        {
            panelBackground.color = UIManager.Instance.Style.PanelColor;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTextEntries();
        }

        public void Show(ShowTooltip tooltip)
        {
            gameObject.SetActive(true);
            InstantiateTextEntries(tooltip);
            MoveRectWithOffset(Camera.main.WorldToCanvasPoint(canvasRect,tooltip.transform.position));
            UpdateTextEntries();

        }

        public void Hide()
        {

            ClearTextEntries();
            gameObject.SetActive(false);
        }

        void ClearTextEntries()
        {
            textLinks.Clear();
            thisRect.ClearChildren();
        }

        void InstantiateTextEntries(ShowTooltip tooltip)
        {

            List<IDescribable> comps = tooltip.GetComponents<IDescribable>().ToList();
            IEnumerable<IDescribable> query = comps.OrderBy(des => des.GetPriority());

            foreach (IDescribable des in query)
            {
                GameObject newObj = Instantiate(textPrefab, transform);
                Text newText = newObj.GetRequiredComponent<Text>();
                newText.text = des.GetRichTextBasicInfo();
                textLinks.Add(new TextLinkEntry(des.GetPriority(), des, newText));
                Debug.Log(newText.text);
            }

        }
        
        void UpdateTextEntries()
        {
            if (gameObject.activeInHierarchy == true && textLinks.Count > 0)
            {
                foreach (TextLinkEntry entry in textLinks)
                {
                    entry.TooltipText.text = entry.DescribedObject.GetRichTextBasicInfo();
                }
            }
        }

        void MoveRectWithOffset(Vector2 newPosition)
        {
            thisRect.position = newPosition + new Vector2 (offset, -offset);
        }
     
    }
}

