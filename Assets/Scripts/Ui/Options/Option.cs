using Assets.Scripts.Systems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Options
{
    public class Option : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            SoundSystem.Instance.PlaySoundEffect(OptionSounds.Instance.OnHoverClip);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            SoundSystem.Instance.PlaySoundEffect(OptionSounds.Instance.OnClickClip);
        }
    }
}
