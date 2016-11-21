using UnityEngine;
using System.Collections;

namespace TheLongOrbit
{
    public class PlayerShip : MonoBehaviour
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
        private float speed = 0f;
        [ReadOnly]
        private float acceleration = 0f;
        [ReadOnly]
        private Location currentLocation = null;
        [ReadOnly]
        private Location targetLocation = null;

        //Temp Read-only
        [Header("Debug")]
        [ReadOnly]
        private SpriteRenderer shipRenderer;
        [ReadOnly]
        private Collider2D shipCollider;

        void Awake()
        {
            shipRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
            shipCollider = gameObject.GetRequiredComponent<Collider2D>();
        }
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate ()
        {

        }

        public void SetLocation (Location newLocation)
        {
            currentLocation = newLocation;
        }
    }
}

