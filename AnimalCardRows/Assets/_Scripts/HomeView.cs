using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeSampleOne
{
    public class HomeView : MonoBehaviour
    {
        [SerializeField]
        private RectTransform rowParent = default;
        [SerializeField]
        private TextMeshProUGUI titleText = default;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void Setup()
        {
            titleText.text = "This is a title";
        }

        public void Shutdown()
        {

        }
    }

}