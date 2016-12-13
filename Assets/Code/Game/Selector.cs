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

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            UIManager.Instance.ShowSelectionPanel(this);
            CommandManager.Instance.Select(this);
        }

    }
}

