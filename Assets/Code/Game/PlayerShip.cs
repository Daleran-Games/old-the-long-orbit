using UnityEngine;
using System.Collections;
using System;

namespace TheLongOrbit
{
    public class PlayerShip : MonoBehaviour, ITooltipable
    {
        [Header("Ship Info")]
        [SerializeField]
        private string playerName = "NewPlayer";
        [SerializeField]
        private ShipType PlayerShipType;

        [Header("Ship Inventory")]
        [SerializeField]
        private int fuel = 0;
        [SerializeField]
        private int health = 0;
        [SerializeField]
        private int supplies = 0;
        [SerializeField]
        private int missles = 0;

        [Header("Ship Stats")]
        [ReadOnly]
        [SerializeField]
        private float speed = 0f;
        [ReadOnly]
        [SerializeField]
        private float acceleration = 0f;
        [ReadOnly]
        [SerializeField]
        private Location currentLocation = null;
        [ReadOnly]
        [SerializeField]
        private Location targetLocation = null;

        //Temp Read-only
        [Header("Debug")]
        [ReadOnly]
        [SerializeField]
        private SpriteRenderer shipRenderer;
        [ReadOnly]
        [SerializeField]
        private Collider2D shipCollider;
        [ReadOnly]
        [SerializeField]
        private TooltipComponent tooltipComp;
        [ReadOnly]
        [SerializeField]
        private Tooltip shipTooltip;

        void Awake()
        {
            shipRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
            shipCollider = gameObject.GetRequiredComponent<Collider2D>();
            tooltipComp = gameObject.GetRequiredComponent<TooltipComponent>();
        }
        
        // Use this for initialization
        void Start()
        {
            transform.position = GameManager.Instance.StartingLocation.GetOrbitPosition();
            shipRenderer.sprite = PlayerShipType.ExteriorView;
            health = PlayerShipType.MaxHealth;
            fuel = PlayerShipType.MaxFuel;
            supplies = PlayerShipType.MaxSupplies;
            missles = PlayerShipType.MaxMissles;
            currentLocation = GameManager.Instance.StartingLocation;
            shipTooltip = GetTooltip();
            tooltipComp.SetTooltip(shipTooltip);
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTooltip();
        }

        void FixedUpdate ()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {

                if (hit.collider.gameObject.GetComponent<Location>() != null)
                {
                    targetLocation = hit.collider.gameObject.GetComponent<Location>();
                }
            }

            if (targetLocation != null)
            {
                if (transform.position == targetLocation.GetOrbitPosition())
                {
                    currentLocation = targetLocation;
                    targetLocation = null;
                }
                else
                {
                    this.transform.Translate(targetLocation.GetOrbitPosition() * Time.deltaTime);
                }
            }
        }

        public void SetLocation (Location newLocation)
        {
            currentLocation = newLocation;
        }

        public Tooltip GetTooltip()
        {
            return new Tooltip(playerName, PlayerShipType.ExteriorView, 
                new TooltipEntry("Ship Class: " + PlayerShipType.ShipName),
                new TooltipEntry("Speed: "+speed+" / "+PlayerShipType.MaxSpeed ),
                new TooltipEntry("Health: "+health + " / " + PlayerShipType.MaxHealth),
                new TooltipEntry("Fuel: "+fuel + " / " + PlayerShipType.MaxFuel),
                new TooltipEntry("Supplies: "+supplies + " / " + PlayerShipType.MaxSupplies),
                new TooltipEntry("Missles: "+missles + " / " + PlayerShipType.MaxMissles)
                );
        }

        public void UpdateTooltip ()
        {
            shipTooltip.GetTooltipEntries()[1].Text = "Speed: " + speed + " / " + PlayerShipType.MaxSpeed;
            shipTooltip.GetTooltipEntries()[2].Text = "Health: " + health + " / " + PlayerShipType.MaxHealth;
            shipTooltip.GetTooltipEntries()[3].Text = "Fuel: " + fuel + " / " + PlayerShipType.MaxFuel;
            shipTooltip.GetTooltipEntries()[4].Text = "Supplies: " + supplies + " / " + PlayerShipType.MaxSupplies;
            shipTooltip.GetTooltipEntries()[5].Text = "Missles: " + missles + " / " + PlayerShipType.MaxMissles;
        }


    }
}

