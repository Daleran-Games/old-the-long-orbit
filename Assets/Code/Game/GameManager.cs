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

        void Awake ()
        {
            PlayerObject = Instantiate(PlayerPrefab);
        }

        // Use this for initialization
        void Start()
        {
            
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
