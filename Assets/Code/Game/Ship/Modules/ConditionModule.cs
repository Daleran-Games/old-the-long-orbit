using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    [RequireComponent(typeof(Collider2D))]
    public class ConditionModule : MonoBehaviour
    {

        [Header("Debug")]
        [ReadOnly]
        [SerializeField]
        private Collider2D goCollider;

        void Awake ()
        {
            goCollider = gameObject.GetRequiredComponent<Collider2D>();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
