using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class PauseSystem : MonoBehaviour
    {
        [SerializeField] private GameObject pauseGameCanvas;
        private bool paused = false;

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
