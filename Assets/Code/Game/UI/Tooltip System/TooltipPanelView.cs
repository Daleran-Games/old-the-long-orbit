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
        protected GameObject textPrefab;


        [Header("Tooltip Components")]
        [ReadOnly]
        [SerializeField]
        protected RectTransform thisRect;
        [ReadOnly]
        [SerializeField]
        protected Image panelBackground;
        [ReadOnly]
        [SerializeField]
        protected RectTransform canvasRect;

        protected List<TextLinkEntry> textLinks = new List<TextLinkEntry>();

        protected void Awake()
        {
            thisRect = gameObject.GetRequiredComponent<RectTransform>();
            canvasRect = transform.root.GetComponent<RectTransform>();
            panelBackground = gameObject.GetRequiredComponent<Image>();
        }

        // Use this for initialization
        protected void Start()
        {
            panelBackground.color = UIManager.Instance.Style.TooltipPanelColor;
            thisRect.sizeDelta = new Vector2(UIManager.Instance.Style.TooltipWidth, 0f);
            
        }

        // Update is called once per frame
        protected void Update()
        {
            UpdateTextEntries();
        }

        public virtual void Show(ShowTooltip tooltip)
        {
            gameObject.SetActive(true);
            InstantiateTextEntries(tooltip);
            Canvas.ForceUpdateCanvases();

            if (tooltip.TooltipMode == ShowTooltip.TooltipType.Game)
            {
                MoveToCanvasPoint(Camera.main.WorldToCanvasPoint(canvasRect, tooltip.transform.position), tooltip);
            }               
            else
            {
                RectTransform objRect = tooltip.gameObject.GetRequiredComponent<RectTransform>();
                MoveToCanvasPoint(objRect.rect.center + (Vector2)objRect.position, tooltip);           
            }
                
        }

        public virtual void Hide()
        {

            ClearTextEntries();
            gameObject.SetActive(false);
        }

        protected virtual void ClearTextEntries()
        {
            textLinks.Clear();
            thisRect.ClearChildren();
        }

        protected virtual void InstantiateTextEntries(ShowTooltip tooltip)
        {

            List<IDescribable> comps = tooltip.GetComponents<IDescribable>().ToList();
            IEnumerable<IDescribable> query = comps.OrderBy(des => des.TooltipPriority);

            foreach (IDescribable des in query)
            {
                if(!des.IsTooltipSuppressed)
                {
                    GameObject newObj = Instantiate(textPrefab, transform);
                    Text newText = newObj.GetRequiredComponent<Text>();
                    newText.text = des.GetRichTextBasicInfo();
                    textLinks.Add(new TextLinkEntry(des.TooltipPriority, des, newText));
                }
            }

        }

        protected virtual void UpdateTextEntries()
        {
            if (gameObject.activeInHierarchy == true && textLinks.Count > 0)
            {
                foreach (TextLinkEntry entry in textLinks)
                {
                    entry.TooltipText.text = entry.DescribedObject.GetRichTextBasicInfo();
                }
            }
        }

        protected virtual void MoveToCanvasPoint(Vector2 newPosition, ShowTooltip tooltip)
        {
            Vector2 centerCanvasPoint = canvasRect.sizeDelta * 0.5f;

            //Bottom right of canvas
            if (newPosition.x >= centerCanvasPoint.x && newPosition.y <= centerCanvasPoint.y)
            {
                thisRect.SetRectTransformAnchorsAndPivot(Vector2.right, Vector2.right, Vector2.right);
                thisRect.position = newPosition;
            }
            //Top right of canvas
            else if (newPosition.x >= centerCanvasPoint.x && newPosition.y > centerCanvasPoint.y)
            {
                thisRect.SetRectTransformAnchorsAndPivot(Vector2.one, Vector2.one, Vector2.one);
                thisRect.position = newPosition;
            }
            //Bottom left of canvas
            else if (newPosition.x < centerCanvasPoint.x && newPosition.y <= centerCanvasPoint.y)
            {
                thisRect.SetRectTransformAnchorsAndPivot(Vector2.zero, Vector2.zero, Vector2.zero);
                thisRect.position = newPosition;
            }
            //Top left of canvas
            else
            {
                thisRect.SetRectTransformAnchorsAndPivot(Vector2.up, Vector2.up, Vector2.up);
                thisRect.position = newPosition;
            }

        }

     
    }
}

