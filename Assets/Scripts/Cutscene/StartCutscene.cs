using Assets.Scripts.Ui;
using System;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Cutscene
{
    public class StartCutscene : MonoBehaviour
    {
        [SerializeField] private string gameSceneName;
        [SerializeField] private float timeToWaitBeforeLoadingScene;
        [SerializeField] private TextData[] textsData;

        private int currentIndex = 0; 
        private TextData CurrentTextData { get => textsData[currentIndex]; }

        private bool showing = false;
        private float currentTime = 0;

        private bool active = true;

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
                active = false;
                StartCoroutine(LoadScene());
            }
        }

        private void Update()
        {
            if (!active) return;

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
        
        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(timeToWaitBeforeLoadingScene);

            AsyncOperation loading = SceneManager.LoadSceneAsync(gameSceneName);

            while (!loading.isDone)
            {
                Debug.Log("loading");
                yield return null;
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
