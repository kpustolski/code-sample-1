using UnityEngine;
using UnityEngine.Events;

namespace CodeSampleOne
{
    public class Modals : MonoBehaviour
    {
        private static AppManager appMan = AppManager.Instance;
        public static void CreateInfoModal(Animal a, UnityAction onSelect)
        {
            InfoModalTemplate m = Instantiate(appMan.InfoModalTemplatePrefab, appMan.ModalParent);
            m.Setup(a, onSelect);
        }
    }
}