using Assets.Scripts.Utilities;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class DeathCounter : MonoBehaviour
    {
        [SerializeField] private GameObject icon;
        private RotateObjectOnce rotateOnce;
        [SerializeField] private TextMeshProUGUI mesh;
        public static int numberOfDeaths;

        private void Awake()
        {
            numberOfDeaths = 0;
            rotateOnce = icon.GetComponent<RotateObjectOnce>();
        }

        [ContextMenu("die")]
        public void AddDeath()
        {
            if (numberOfDeaths == 0)
            {
                icon.SetActive(true);
                mesh.enabled = true;
            }

            rotateOnce.Rotate();
            numberOfDeaths++;
            mesh.text = $"x {numberOfDeaths}";
        }
    }
}
