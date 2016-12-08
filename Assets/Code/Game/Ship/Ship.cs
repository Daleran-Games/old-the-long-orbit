using UnityEngine;
using System.Collections;
using System;

namespace TheLongOrbit
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ship : MonoBehaviour
    {
        [Header("Ship Info")]
        [SerializeField]
        private string captainName = "NewCaptain";
        [SerializeField]
        private string shipName = "NewShip";
        [TextArea]
        [SerializeField]
        private string shipDescription = "A new ship";

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
            transform.position = GameManager.Instance.StartingLocation.GetOrbitPosition();
            shipRenderer.sprite = ExteriorView;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate ()
        {
            /*
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {

                if (hit.collider.gameObject.GetComponent<Planet>() != null)
                {
                    targetLocation = hit.collider.gameObject.GetComponent<Planet>();
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
            */
        }

    }
}

