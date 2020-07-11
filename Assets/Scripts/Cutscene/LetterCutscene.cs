using TMPro;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class LetterCutscene : MonoBehaviour
    {
        [SerializeField] private GameObject backGround;
        [SerializeField] private TextMeshProUGUI textMesh;

        [ContextMenu("Start Letter Cutscene")]
        public void StartLetterCutscene()
        {
            backGround.SetActive(true);
            textMesh.gameObject.SetActive(true);

            textMesh.text = "ending game";
        }
    }
}
