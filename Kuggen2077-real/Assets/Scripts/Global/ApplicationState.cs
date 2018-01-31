using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ApplicationState {

	public enum SceneState { Main, Play, Level, Result }
	public enum Command { Main, Play, Level, Result }
	private Dictionary<StateTransition, List<Action>> Actions = new Dictionary<StateTransition, List<Action>>();

	/*
		From: https://stackoverflow.com/questions/5923767/simple-state-machine-example-in-c
	*/
	class StateTransition
	{
		readonly SceneState CurrentState;
		readonly Command Command;

		public StateTransition(SceneState currentState, Command command)
		{
			CurrentState = currentState;
			Command = command;
		}

		public override int GetHashCode()
		{
			return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			StateTransition other = obj as StateTransition;
			return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
		}
	}


	private Dictionary<StateTransition, SceneState> transitions = new Dictionary<StateTransition, SceneState> {
		{ new StateTransition(SceneState.Main, Command.Play), SceneState.Play },
		{ new StateTransition(SceneState.Play, Command.Main), SceneState.Main },
		{ new StateTransition(SceneState.Play, Command.Level), SceneState.Level },
		{ new StateTransition(SceneState.Level, Command.Result), SceneState.Result },
		{ new StateTransition(SceneState.Level, Command.Main), SceneState.Main },
		{ new StateTransition(SceneState.Result, Command.Level), SceneState.Level },
		{ new StateTransition(SceneState.Result, Command.Main), SceneState.Main },
	};

	public SceneState CurrentState { get; private set; }

	public SceneState GetNext(Command command){
		StateTransition transition = new StateTransition (CurrentState, command);
		SceneState next;
		if (!transitions.TryGetValue (transition, out next)) {
			throw new KuggenException ("Invalid transition: " + CurrentState + " -> " + command);
		}
		return next;
	}

	public void Subscribe (ApplicationState.SceneState scene, ApplicationState.Command command, Action callback){
		Debug.Log ("subscribed to: " + scene + " -> " + command);
		StateTransition st = new StateTransition (scene, command);
		if (!Actions.ContainsKey(st)) {
			Actions [st] = new List<Action> ();
		}

		Actions [st].Add (callback);
	}

	public void Publish (ApplicationState.SceneState previousScene, ApplicationState.Command command){
		StateTransition st = new StateTransition (previousScene, command);
		if (Actions.ContainsKey (st)) {
			List<Action> subscribers = Actions [new StateTransition (previousScene, command)];
			foreach (Action sub in subscribers) {
				sub.Invoke ();
			}
		}
	}

	public SceneState MoveNext(Command command){
		SceneState previous = CurrentState;
		CurrentState = GetNext (command);
		Publish (previous, command);
		return CurrentState;
	}

	public ApplicationState(SceneState initState){
		CurrentState = initState;
	}
}
