using TMPro;
using UnityEngine;

namespace Assets.Scripts.Ui
{
    public class ShowTextLetterByLetter : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;
        private string textToShow;

        [SerializeField] private float timeToShowLetter;
        private float currentTime;
        private int currentLetter = 0;
        private bool active = true;

        private void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();

            textToShow = textMesh.text;
            textMesh.text = "";
        }

        private void Update()
        {
            if (!active) return;

            currentTime += Time.deltaTime;

            if (currentTime > timeToShowLetter)
            {
                currentTime = 0;
                textMesh.text += textToShow[currentLetter];
                currentLetter++;

                if (currentLetter >= textToShow.Length)
                    active = false;
            }
        }
    }
}
