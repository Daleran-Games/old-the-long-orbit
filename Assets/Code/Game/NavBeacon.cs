using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    public class NavBeacon : MonoBehaviour
    {

        [SerializeField]
        private float orbitOffset = 0f;
        [ReadOnly]
        [SerializeField]
        private string navigationPointName = "No Name Assigned";

        public Vector3 GetOrbitPosition()
        {
            return transform.position + new Vector3(0f, orbitOffset);
        }

        // Use this for initialization
        void Start()
        {
            navigationPointName = gameObject.GetComponent<INameable>().GetObjectName();
        }

        public string GetNavBeaconName()
        {
            return navigationPointName;
        }
    }
}

