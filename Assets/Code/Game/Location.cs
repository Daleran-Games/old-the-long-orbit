using UnityEngine;
using System.Collections;
using System;

namespace TheLongOrbit
{
    public class Location : MonoBehaviour, ITooltipable
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

        private Tooltip LocationTooltip;

        // Use this for initialization
        void Awake()
        {
            LocationTooltip = new Tooltip(locationName, icon, new TooltipEntry(description));
            gameObject.GetRequiredComponent<TooltipComponent>().SetTooltip(LocationTooltip);

        }

        public Tooltip GetTooltip()
        {
            return LocationTooltip;
        }

        public Vector3 GetOrbitPosition()
        {
            return transform.position + new Vector3(0f, orbitOffset);
        }
    }
}
