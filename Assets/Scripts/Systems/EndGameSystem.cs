using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class EndGameSystem : MonoBehaviour
    {
        public static EndGameSystem Instance;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this; 
        }

        public void OnEndGameEvent()
        {
        }
    }
}
