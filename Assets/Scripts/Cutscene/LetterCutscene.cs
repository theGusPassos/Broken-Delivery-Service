using TMPro;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class LetterCutscene : MonoBehaviour
    {
        [SerializeField] private GameObject backGround;
        [SerializeField] private GameObject textObject;
        [SerializeField] private GameObject continueButton;

        [SerializeField] private TextMeshProUGUI[] textsMesh;
        [SerializeField] private float timeBetweenTexts;

        private float currentTimer;
        private int currentText = 0;

        private bool active = false;

        private void Awake()
        {
            foreach (var mesh in textsMesh)
            {
                mesh.enabled = false;
            }
        }

        [ContextMenu("Start Letter Cutscene")]
        public void StartLetterCutscene()
        {
            backGround.SetActive(true);
            textObject.SetActive(true);

            active = true;
        }

        private void Update()
        {
            if (!active) return;

            currentTimer += Time.deltaTime;

            if (currentTimer > timeBetweenTexts)
            {
                if (currentText >= textsMesh.Length)
                {
                    continueButton.SetActive(true);
                    active = false;
                }
                else
                {
                    textsMesh[currentText].enabled = true;
                    currentText++;
                    currentTimer = 0;
                }
            }
        }
    }
}
