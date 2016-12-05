using UnityEngine;
using System.Collections;


namespace TheLongOrbit
{
    public class PlayerController : MonoBehaviour
    {


        [ReadOnly]
        private PlayerShip playerShip;

        // Use this for initialization
        void Start()
        {
            playerShip = gameObject.GetRequiredComponent<PlayerShip>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}