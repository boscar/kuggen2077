using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour {

    public static Level Instance { get; private set; }

    private float timer = 0;
    public List<Player> Players { get; set; }
    protected List<Section> Sections { get; set; }

    protected void Start () {
        Players = new List<Player> (FindObjectsOfType<Player>());
        Instance = this;
	}

    protected void FixedUpdate () {
        timer += Time.fixedDeltaTime;
        if(Sections != null) {
            HandleSections();
        }
	}

    private void HandleSections() {
        if (Sections.Count > 0) {
            if (Sections[0].IsFinished) {
                Sections.RemoveAt(0);
                timer = 0;
            } else {
                HandleEvents(Sections[0].Events);
            }
        }
    }

    private void HandleEvents(List<Event> events) {
        if (events.Count > 0 && timer >= events[0].TimeStamp) {
            events[0].Activate();
            events.RemoveAt(0);
        }
    }
}
