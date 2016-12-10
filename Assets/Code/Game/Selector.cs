using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheLongOrbit
{
    public class Selector : MonoBehaviour
    {

        [ReadOnly]
        [SerializeField]
        private string targetName = "No Name Assigned";

        public Vector3 GetLocationPosition()
        {
            return transform.position;
        }

        // Use this for initialization
        void Start()
        {
            targetName = gameObject.GetComponent<INameable>().GetObjectName();
        }

        public string GetTargetName()
        {
            return targetName;
        }

    }
}

