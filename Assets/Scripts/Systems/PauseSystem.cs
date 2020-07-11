using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class PauseSystem : MonoBehaviour
    {
        [SerializeField] private GameObject pauseGameCanvas;
        private bool paused = false;

        public void ResumeGame()
        {
            Time.timeScale = 1;
            paused = false;
            pauseGameCanvas.SetActive(paused);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = !paused;
                pauseGameCanvas.SetActive(paused);

                if (paused)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
        }
    }
}
