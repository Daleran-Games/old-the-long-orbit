using UnityEngine;
using System.Collections;

namespace TheLongOrbit
{
    [CreateAssetMenu(fileName = "NewShipType", menuName = "Long Orbit/Ship Type", order = 50)]
    public class ShipType : ScriptableObject
    {
        [Header ("Ship Info")]
        public string ShipName = "New Ship";
        [TextArea]
        public string ShipDescription = "A new ship";
        public Sprite ExteriorView;
        public Sprite InteriorView;

        [Header("Ship Stats")]
        public int MaxFuel = 0;
        public int MaxHealth = 0;
        public int MaxSupplies = 0;
        public int MaxMissles = 0;
        public float MaxAcceleration = 0f;


    }
}
