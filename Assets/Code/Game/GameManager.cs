using UnityEngine;
using System.Collections;
using DalLib;

namespace TheLongOrbit
{
    public class GameManager : Singleton<GameManager>
    {
        protected GameManager() { }


        [SerializeField]
        private NavBeacon startingPlanet;
        public NavBeacon StartingPlanet { get { return startingPlanet; } }

        [SerializeField]
        private GameSettings currentSettings;
        public GameSettings CurrentSettings { get { return currentSettings;  } }

        [ReadOnly]
        [SerializeField]
        private NavigationModule shipNavModule;

        [SerializeField]
        private GameObject playerObject;
        public GameObject PlayerObject { get { return playerObject;  } }

        void Awake ()
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
            shipNavModule = playerObject.GetRequiredComponent<NavigationModule>();
        }

        // Use this for initialization
        void Start()
        {
            shipNavModule.TeleportToLocation(startingPlanet);
        }

    }
}
