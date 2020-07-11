using Assets.Scripts.Systems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Options
{
    public class StartGameOption : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private GameStarterSystem gameStarter;

        public void OnPointerDown(PointerEventData eventData)
        {
            SoundSystem.Instance.PlaySoundEffect(OptionSounds.Instance.OnHoverClip);
            gameStarter.StartGame();
        }
    }
}
