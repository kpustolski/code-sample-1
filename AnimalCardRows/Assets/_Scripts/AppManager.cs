using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodeSampleOne
{
    public class AppManager : MonoBehaviour
    {
        [Header("Views")]
        [Space(10)]
        [SerializeField]
        private HomeView homeView = default;

        [Header("Prefabs")]
        [Space(10)]
        [SerializeField]
        private AnimalRow animalRowPrefab = default;
        [SerializeField]
        private AnimalCard animalCardPrefab = default;
        public AnimalRow AnimalRowPrefab { get { return animalRowPrefab; } }
        public AnimalCard AnimalCardPrefab { get { return animalCardPrefab; } }
        public DataManager DataManager { get; private set; }
        //Global Static Variables
        public static AppManager Instance { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            DataManager = new DataManager();
            DataManager.Initialize();

            //Setup the home view
            homeView.Setup();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}