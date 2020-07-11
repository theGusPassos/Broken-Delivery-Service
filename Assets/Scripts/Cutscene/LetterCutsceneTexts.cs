using TMPro;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class LetterCutsceneTexts : MonoBehaviour
    {
        [SerializeField] private TextCutsceneData[] textsData;
        [SerializeField] private byte alpha;

        private int currentText = 0;
        private int currentLetter = 0;
        private bool typing = false;
        private float currentTimer;

        private string currentTextToType = "";

        private void Awake()
        {
            foreach (var textData in textsData)
            {
                textData.textMesh.enabled = false;
            }
        }

        private void Update()
        {
            if (!typing)
            {
                currentTimer += Time.deltaTime;

                if (currentTimer > textsData[currentText].timeToWaitBeforeStartTyping)
                {
                    currentTimer = 0;
                    typing = true;
                    currentTextToType = textsData[currentText].textMesh.text;
                    textsData[currentText].textMesh.text = "";
                    textsData[currentText].textMesh.enabled = true;
                }
            }
            else
            {
                currentTimer += Time.deltaTime;

                if (currentTimer > textsData[currentText].timeToType)
                {
                    textsData[currentText].textMesh.text += currentTextToType[currentLetter];
                    currentLetter++;

                    currentTimer = 0;

                    if (currentLetter >= currentTextToType.Length)
                    {
                        typing = false;
                        currentLetter = 0;
                        currentText++;

                        if (currentText >= textsData.Length)
                        {
                            Debug.Log("ended");
                        }
                    }
                }
            }
        }

        [System.Serializable]
        public struct TextCutsceneData
        {
            public TextMeshProUGUI textMesh;
            public float timeToType;
            public float timeToWaitBeforeStartTyping;
        }
    }
}
