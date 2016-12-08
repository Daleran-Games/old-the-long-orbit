using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    public class Location : Target
    {

        [SerializeField]
        private string locationName = "Default Location";
        [SerializeField]
        [TextArea]
        private string description = "Default Location Description";
        [SerializeField]
        private Sprite icon;
        [SerializeField]
        private float orbitOffset = 0f;

        public Vector3 GetOrbitPosition()
        {
            return transform.position + new Vector3(0f, orbitOffset);
        }

        public string GetLocationName ()
        {
            return locationName;
        }

    }
}
