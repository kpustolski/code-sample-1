using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeSampleOne
{
    public class AnimalCard : MonoBehaviour
    {
        [SerializeField]
        private Image cardImage = default;
        [SerializeField]
        private TextMeshProUGUI titleText = default;

        public void Setup()
        {

        }

        public void Shutdown()
        {

        }
    }
}