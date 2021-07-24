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
        private string id = default;

        public void Setup(string id, string name)
        {
            id = this.id;
            titleText.text = name;

            //TODO: Set up the image
        }

        public void Shutdown()
        {
            Destroy(gameObject);
        }
    }
}