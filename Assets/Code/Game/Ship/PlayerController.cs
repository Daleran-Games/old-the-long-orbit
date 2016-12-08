using UnityEngine;
using System.Collections;


namespace TheLongOrbit
{
    public class PlayerController : MonoBehaviour
    {


        [ReadOnly]
        private Ship playerShip;

        // Use this for initialization
        void Start()
        {
            playerShip = gameObject.GetRequiredComponent<Ship>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}