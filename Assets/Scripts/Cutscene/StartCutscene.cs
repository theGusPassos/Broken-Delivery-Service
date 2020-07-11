using Assets.Scripts.Ui;
using System;
using System.IO;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class StartCutscene : MonoBehaviour
    {
        [SerializeField] private TextData[] textsData;

        private int currentIndex = 0; 
        private TextData CurrentTextData { get => textsData[currentIndex]; }

        private bool showing = false;
        private float currentTime = 0;

        private void Awake()
        {
            foreach (var textData in textsData)
            {
                textData.mesh.color -= new Color(0, 0, 0, 1);
            }
        }

        private void GoToNextText()
        {
            currentTime = 0;
            showing = false;
            currentIndex++;

            if (currentIndex >= textsData.Length)
            {
                this.enabled = false;
            }
        }

        private void Update()
        {
            currentTime += Time.deltaTime;

            if (!showing)
            {
                if (currentTime > CurrentTextData.timeToAppear)
                {
                    showing = true;
                }
            }
            if (showing)
            {
                CurrentTextData.mesh.color += new Color(0, 0, 0, Time.deltaTime * CurrentTextData.speedToAppear);

                if (CurrentTextData.mesh.color.a >= 1)
                {
                    var component = CurrentTextData.mesh.gameObject.AddComponent<MakeTextDisappearAfterTime>();
                    component.StartToDisappear(CurrentTextData.timeToDisappear, CurrentTextData.speedToDisappear);

                    GoToNextText();
                }
            }
        }
    }

    [System.Serializable]
    public struct TextData
    {
        public TextMeshProUGUI mesh;
        public float speedToAppear;
        public float timeToAppear;
        public float speedToDisappear;
        public float timeToDisappear;
    }
}
