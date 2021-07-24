using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeSampleOne
{
    public class AnimalRow : MonoBehaviour
    {
        [SerializeField]
        private RectTransform cardParent = default;
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