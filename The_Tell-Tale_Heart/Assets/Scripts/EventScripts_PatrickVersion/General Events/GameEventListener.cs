using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    GameEvent _gameEvent;

    [SerializeField]
    UnityEvent _unityEvent;

    private void Awake() => _gameEvent.Register(this);

    private void OnDestroy() => _gameEvent.Deregister(this);

    public void RaiseEvent() => _unityEvent.Invoke();
    



}
