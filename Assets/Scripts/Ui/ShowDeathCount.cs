using Assets.Scripts.Systems;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Ui
{
    public class ShowDeathCount : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<TextMeshProUGUI>().text = $"You've died {DeathCounter.numberOfDeaths} times";
        }
    }
}
