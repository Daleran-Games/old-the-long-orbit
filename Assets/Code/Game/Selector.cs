using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace TheLongOrbit
{
    public class Selector : MonoBehaviour, IPointerDownHandler
    {

        [ReadOnly]
        [SerializeField]
        private string targetName = "No Name Assigned";
        public string TargetName { get { return targetName; } }

        public Vector3 GetLocationPosition()
        {
            return transform.position;
        }

        // Use this for initialization
        void Start()
        {
            targetName = gameObject.GetComponent<INameable>().Name;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            UIManager.Instance.ShowSelectionPanel(this);
            CommandManager.Instance.Select(this);
        }

    }
}

