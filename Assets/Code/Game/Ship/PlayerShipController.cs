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

        [Header("Navigation")]
        [ReadOnly]
        [SerializeField]
        private NavigationModule navModule;
        [ReadOnly]
        [SerializeField]
        private string playerTargetText;
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
            CommandManager.Instance.OnMove += navModule.Move;
        }

        // Update is called once per frame
        void Update()
        {
            if (playerTarget != null)
                playerTargetText = playerTarget.GetTargetName();
            else
                playerTargetText = "";
        }

        void OnDestroy()
        {
            CommandManager.Instance.OnSelection -= PlayerTargetSelected;
            CommandManager.Instance.OnMove += navModule.Move;
        }

        public void PlayerTargetSelected (Selector target)
        {
            playerTarget = target;
            canNavigateToTarget = IsTargetNavigatable(target);
        }

        public bool IsTargetNavigatable(Selector target)
        {
            if (target == null)
            {
                return false;
            } else
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
    }
}