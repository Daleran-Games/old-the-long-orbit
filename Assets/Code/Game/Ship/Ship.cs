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
        [TextArea]
        [SerializeField]
        private string shipDescription = "A new ship";
        [SerializeField]
        private int tooltipPriority = 2;
        [SerializeField]
        private bool supressTooltip = false;

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
        [ReadOnly]
        [SerializeField]
        private Collider2D shipCollider;

        void Awake()
        {
            shipRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
        }
        
        // Use this for initialization
        void Start()
        {
            transform.position = GameManager.Instance.StartingPlanet.GetOrbitPosition();
            shipRenderer.sprite = ExteriorView;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public string GetObjectName()
        {
            return shipName;
        }

        public string GetRichTextBasicInfo()
        {
            string head = UIManager.Instance.Style.Subheading.ApplyTextSyle(shipName + " Class Ship");
            string foot = UIManager.Instance.Style.Footnote.ApplyTextSyle(shipDescription);

            return head + Environment.NewLine + foot;
        }

        public int GetPriority()
        {
            return tooltipPriority;
        }

        public bool IsSupressed()
        {
            return supressTooltip;
        }
    }
}

