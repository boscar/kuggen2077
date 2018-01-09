using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectState {

	public enum ViewState { Disconnected, Connected, Ready }
	public enum Command { Connect, Disconnect, Ready, Unready }

	/*
		From: https://stackoverflow.com/questions/5923767/simple-state-machine-example-in-c
	*/
	class StateTransition
	{
		readonly ViewState CurrentState;
		readonly Command Command;

		public StateTransition(ViewState currentState, Command command)
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


	private Dictionary<StateTransition, ViewState> transitions = new Dictionary<StateTransition, ViewState> {
		{ new StateTransition(ViewState.Disconnected, Command.Connect), ViewState.Connected },
		{ new StateTransition(ViewState.Connected, Command.Disconnect), ViewState.Disconnected },
		{ new StateTransition(ViewState.Connected, Command.Ready), ViewState.Ready },
		{ new StateTransition(ViewState.Ready, Command.Disconnect), ViewState.Disconnected },
		{ new StateTransition(ViewState.Ready, Command.Unready), ViewState.Connected },
	};

	public ViewState CurrentState { get; private set; }

	public ViewState getNext(Command command){
		StateTransition transition = new StateTransition (CurrentState, command);
		ViewState next;
		if (!transitions.TryGetValue(transition, out next))
			throw new KuggenException("Invalid transition: " + CurrentState + " -> " + command);
		return next;
	}

	public ViewState moveNext(Command command){
		CurrentState = getNext (command);
		return CurrentState;
	}

	public PlayerSelectState(ViewState initState){
		CurrentState = initState;
	}

	public PlayerSelectState(){
		CurrentState = ViewState.Disconnected;
	}
}
