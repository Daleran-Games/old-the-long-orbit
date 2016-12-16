using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    public class NavBeacon : MonoBehaviour, INameable
    {

        [SerializeField]
        private float orbitPosition = 0f;
        [ReadOnly]
        [SerializeField]
        private string navigationPointName = "No Name Assigned";
        public string Name { get { return navigationPointName; } }

        // Use this for initialization
        void Start()
        {
            navigationPointName = gameObject.GetComponent<INameable>().Name;
        }

        public Vector2 GetOrbitPosition ()
        {
            return transform.position + new Vector3(0f, orbitPosition);
        }

    }
}

