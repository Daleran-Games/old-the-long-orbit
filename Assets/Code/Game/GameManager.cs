using UnityEngine;
using System.Collections;
using DalLib;

namespace TheLongOrbit
{
    public class GameManager : Singleton<GameManager>
    {
        protected GameManager() { }

        public Location StartingLocation;
        public GameObject PlayerPrefab;

        private GameObject PlayerObject;
        private PlayerShip Player;

        void Awake ()
        {
            PlayerObject = Instantiate(PlayerPrefab);
            Player = gameObject.GetRequiredComponent<PlayerShip>();
        }

        // Use this for initialization
        void Start()
        {
            PlayerObject.transform.position = StartingLocation.GetOrbitPosition();
            Player.SetLocation(StartingLocation);
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
