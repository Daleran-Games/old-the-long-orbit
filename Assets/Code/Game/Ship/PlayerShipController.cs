using UnityEngine;
using System.Collections;
using System;

namespace TheLongOrbit
{
    public class PlayerShipController : MonoBehaviour, INameable, IDescribable
    {
        [Header("Captain Info")]
        [SerializeField]
        private string captainName = "NewCaptain";
        [ReadOnly]
        [SerializeField]
        private Ship playerShip;
        [SerializeField]
        private int tooltipPriority = 1;
        [SerializeField]
        private bool supressTooltip = false;

        [Header("Navigation")]
        [ReadOnly]
        [SerializeField]
        private NavigationModule navModule;
        [ReadOnly]
        [SerializeField]
        private Selector playerTarget;
        [ReadOnly]
        [SerializeField]
        private bool canNavigateToTarget = false;

        


        // Use this for initialization
        void Start()
        {
            playerShip = gameObject.GetRequiredComponent<Ship>();
            navModule = gameObject.GetRequiredComponent<NavigationModule>();
            CommandManager.Instance.OnSelection += PlayerTargetSelected;
            CommandManager.Instance.OnMove += Move;
        }

        void OnDestroy()
        {
            CommandManager.Instance.OnSelection -= PlayerTargetSelected;
            CommandManager.Instance.OnMove -= Move;
        }

        public void PlayerTargetSelected (Selector target)
        {
            playerTarget = target;
            canNavigateToTarget = IsTargetNavigatable(target);
        }

        public void Move(NavBeacon nav)
        {
            

            if (canNavigateToTarget)
            {
                NavBeacon newLoc = playerTarget.gameObject.GetComponent<NavBeacon>();
                Debug.Log("Moving to: "+newLoc.GetNavBeaconName());
                navModule.Move(newLoc);
            }
                
        }

        public bool IsTargetNavigatable(Selector target)
        {
            if (target == null)
            {
                return false;
            } else if (target.gameObject.GetComponent<NavBeacon>() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetRichTextBasicInfo()
        {
            return UIManager.Instance.Style.Heading.ApplyTextSyle(captainName);
        }

        public int GetPriority()
        {
            return tooltipPriority;
        }

        public string GetObjectName()
        {
            return captainName;
        }

        public bool IsSupressed()
        {
            return supressTooltip;
        }
    }
}