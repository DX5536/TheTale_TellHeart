using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    HashSet<GameEventListener> _listener = new HashSet<GameEventListener>();

    public void Invoke()
    {
        foreach (var gloabalEventListener in _listener) gloabalEventListener.RaiseEvent();
    }

    public void Register(GameEventListener gameEventListener) => _listener.Add(gameEventListener);

    public void Deregister(GameEventListener gameEventListener) => _listener.Remove(gameEventListener);
}
