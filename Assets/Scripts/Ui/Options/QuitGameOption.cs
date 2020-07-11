using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Options
{
    public class QuitGameOption : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Application.Quit();
        }
    }
}
