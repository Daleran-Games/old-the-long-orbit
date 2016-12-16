using UnityEngine;
using System.Collections;
using System;

namespace TheLongOrbit
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ship : MonoBehaviour, INameable, IDescribable
    {
        [Header("Ship Info")]
        [SerializeField]
        private string shipName = "NewShip";
        public string Name { get { return shipName; } }
        [TextArea]
        [SerializeField]
        private string shipDescription = "A new ship";
        [SerializeField]
        private int tooltipPriority = 2;
        public int TooltipPriority { get { return tooltipPriority; } }
        [SerializeField]
        private bool supressTooltip = false;
        public bool IsTooltipSuppressed {get { return supressTooltip; } }

        [Header("Ship Graphics")]
        [SerializeField]
        private Sprite ExteriorView;
        [SerializeField]
        private Sprite InteriorView;


        //Temp Read-only
        [Header("Debug")]
        [ReadOnly]
        [SerializeField]
        private SpriteRenderer shipRenderer;

        void Awake()
        {
            shipRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
        }
        
        // Use this for initialization
        void Start()
        {
            shipRenderer.sprite = ExteriorView;
        }

        public string GetRichTextBasicInfo()
        {
            string head = UIManager.Instance.Style.Subheading.ApplyTextSyle(shipName + " Class Ship");
            string foot = UIManager.Instance.Style.Footnote.ApplyTextSyle(shipDescription);

            return head + Environment.NewLine + foot;
        }
    }
}

