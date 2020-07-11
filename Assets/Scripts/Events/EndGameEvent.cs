using Assets.Scripts.Cutscene;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class EndGameEvent : MonoBehaviour
    {
        [SerializeField] private EndCutscene endCutscene;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            endCutscene.StartEndCutscene();
        }
    }
}
