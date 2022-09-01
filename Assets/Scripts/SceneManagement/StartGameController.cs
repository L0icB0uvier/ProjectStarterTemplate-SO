using System;
using ScriptableObjects.EventChannels;
using UnityEngine;
using UnityEngine.Events;

namespace SceneManagement
{
	public class StartGameController : MonoBehaviour
	{
		[SerializeField] private LocationSO _startGameLocation;

		[SerializeField] private bool _showLoadScreen;
	
		[Header("Broadcasting on")]
		[SerializeField] private LoadEventChannel _loadLocation;
		
		[Header("Listening to")]
		[SerializeField] private VoidEventChannel _startGameEventChannel;
		
		[Header("Unity Events")]
		[SerializeField] private UnityEvent _onGameStart;
		
		private void Awake()
		{
			_startGameEventChannel.onEventRaised += StartGame;
		}

		private void OnDestroy()
		{
			_startGameEventChannel.onEventRaised -= StartGame;
		}

		private void StartGame()
		{
			_loadLocation.RaiseEvent(_startGameLocation, _showLoadScreen);
			_onGameStart?.Invoke();
		}
	}
}
