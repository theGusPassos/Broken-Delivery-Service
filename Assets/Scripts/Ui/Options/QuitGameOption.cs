using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Options
{
    public class QuitGameOption : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("qutting game");
            StartCoroutine(QuitGame());
        }

        public void Quit()
        {
            StartCoroutine(QuitGame());
        }

        private IEnumerator QuitGame()
        {
            yield return new WaitForSeconds(0.5f);

            Application.Quit();
        }
    }
}
