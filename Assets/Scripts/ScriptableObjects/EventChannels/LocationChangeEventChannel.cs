using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects.EventChannels
{
    [CreateAssetMenu(menuName = "Events/Location Changed Event Channel")]
    public class LocationChangeEventChannel : ScriptableObject
    {
        public UnityAction<LocationSO> OnLoadingRequested;

        public void RaiseEvent(LocationSO locationToLoad)
        {
            OnLoadingRequested?.Invoke(locationToLoad);
        }
    }
}