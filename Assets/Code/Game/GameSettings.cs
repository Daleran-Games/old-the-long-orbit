using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    [CreateAssetMenu(fileName = "NewSettings", menuName = "Long Orbit/Game Settings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [Header("Navigation Physics")]
        [SerializeField]
        private float positionErrorTolerance = 10f;
        public float PositionErrorTollerance { get { return positionErrorTolerance; } }
        [SerializeField]
        private float headingErrorTolerance = 1f;
        public float HeadingErrorTolerance { get { return headingErrorTolerance; } }


    }
}
