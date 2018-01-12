using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectController : MonoBehaviour {

	private Component[] views;
	private PlayerSelectState sm;

	// Use this for initialization
	void Start () {
		sm = new PlayerSelectState ();
		views = GetComponentsInChildren<PlayerSelectView> ();

		if (views == null) {
			throw new KuggenException ("Unable to find component PlayerSelectView in " + this);
		}

		sm.MoveNext (PlayerSelectState.Command.Connect);
	}
	
	// Update is called once per frame
	void Update () {
		foreach (PlayerSelectView view in views){
			if (view.ActiveView != sm.CurrentState) {
				view.updateView (sm.CurrentState);
			}
		}
	}
}
