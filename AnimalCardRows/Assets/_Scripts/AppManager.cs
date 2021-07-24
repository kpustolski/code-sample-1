using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public AnimalCard AnimalCard { get { return animalCardPrefab; } }

        //Global Variables
        public static AppManager Instance { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            //Grab the data
            //Setup the home view
            homeView.Setup();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}