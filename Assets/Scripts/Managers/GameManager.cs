using ScriptableObjects.EventChannels;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel _quitGameEventChannel;

        private void Awake()
        {
            _quitGameEventChannel.onEventRaised += QuitGame;
        }

        private void OnDestroy()
        {
            _quitGameEventChannel.onEventRaised -= QuitGame;
        }

        private void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
