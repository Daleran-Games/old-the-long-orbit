using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheLongOrbit
{
    public class SelectionPanelView : MonoBehaviour
    {
        [Header("Selection Panel Settings")]
        [SerializeField]
        private GameObject cameraPanel;
        [SerializeField]
        private GameObject infoPanel;
        [SerializeField]
        private GameObject textPrefab;

        [Header("Selection Panel Components")]
        [ReadOnly]
        [SerializeField]
        private RectTransform thisRect;
        [ReadOnly]
        [SerializeField]
        private RectTransform canvasRect;
        [ReadOnly]
        [SerializeField]
        private Image cameraPanelBackground;
        [ReadOnly]
        [SerializeField]
        private InfoPanelView infoView;


        void Awake()
        {
            thisRect = gameObject.GetRequiredComponent<RectTransform>();
            canvasRect = transform.root.GetComponent<RectTransform>();
            cameraPanelBackground = cameraPanel.GetRequiredComponent<Image>();
            infoView = gameObject.GetComponentInChildren<InfoPanelView>();
        }
        
        // Use this for initialization
        void Start()
        {
            cameraPanelBackground.color = UIManager.Instance.Style.TooltipPanelColor;
            infoPanel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Show(Selector selectedObject)
        {
            gameObject.SetActive(true);
            if (selectedObject.gameObject.GetComponent<ShowTooltip>() != null)
                infoView.Show(selectedObject.gameObject.GetComponent<ShowTooltip>());
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            infoView.Hide();
        }

    }

}
