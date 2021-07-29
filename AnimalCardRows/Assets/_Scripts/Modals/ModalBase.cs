using UnityEngine;
using UnityEngine.UI;

namespace CodeSampleOne
{
    public class ModalBase : MonoBehaviour
    {
        [Header("Modal Base Variables")]
        [Space(5)]
        [SerializeField]
        protected Button cancelButton = default;

        public virtual void Initialize()
        {
            cancelButton.onClick.AddListener(Shutdown);
        }

        public virtual void Shutdown()
        {
            cancelButton.onClick.RemoveAllListeners();
        }
    }

}