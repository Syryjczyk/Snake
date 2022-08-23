using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
	HashSet<GameEventListener> listeners = new HashSet<GameEventListener>();

	public void Invoke()
	{
		foreach (var globalEventListener in listeners)
			globalEventListener.OnEventRaised();
	}

	public void Register(GameEventListener gameEventListener) => listeners.Add(gameEventListener);

	public void Deregister(GameEventListener gameEventListener) => listeners.Remove(gameEventListener);
}
