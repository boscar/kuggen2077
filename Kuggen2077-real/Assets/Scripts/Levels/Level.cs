using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour {

    public static Level Instance { get; private set; }

    private float timer = 0;
    public List<Player> players = new List<Player>();

    protected List<Event> Events { get; set; }
    
	protected void Start () {
        Events = new List<Event>();
        players.AddRange(FindObjectsOfType<Player>());
        Instance = this;
	}

    protected void FixedUpdate () {
        timer += Time.fixedDeltaTime;
        if (Events.Count > 0 && timer >= Events[0].TimeStamp) {
            Events[0].Activate();
            Events.RemoveAt(0);
        }
	}
}
