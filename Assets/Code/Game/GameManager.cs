using UnityEngine;
using System.Collections;
using DalLib;

namespace TheLongOrbit
{
    public class GameManager : Singleton<GameManager>
    {
        protected GameManager() { }

        public NavBeacon StartingPlanet;
        public GameObject PlayerObject;

        [ReadOnly]
        [SerializeField]
        private NavigationModule shipNavModule;

        void Awake ()
        {
            shipNavModule = PlayerObject.GetRequiredComponent<NavigationModule>();
        }

        // Use this for initialization
        void Start()
        {
            shipNavModule.Teleport(StartingPlanet);
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void SaveToDisk ()
        {

        }

        public void LoadFromDisk ()
        {

        }
    }
}
