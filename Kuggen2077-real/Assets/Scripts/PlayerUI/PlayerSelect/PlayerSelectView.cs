﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectView : MonoBehaviour {

	private Dictionary<PlayerSelectState.ViewState, Action> views = new Dictionary<PlayerSelectState.ViewState, Action> ();
	private const string PATH = "sprites/playerselect/";

	private RawImage backgroundTexture; 
	private RawImage statusTexture;
	private Text playerNumber;

	private Color highlightColor;

	void Start () {
		InitViews ();

		backgroundTexture = GetComponent<RawImage> ();
		if (backgroundTexture == null) {
			throw new KuggenException ("RawImage component required in gameobject for " + this);
		}

		statusTexture = transform.Find ("status/label").gameObject.GetComponent<RawImage>();
		if (statusTexture == null) {
			throw new KuggenException ("RawImage component required for 'status/label' gameobject in " + this);
		}

		playerNumber = transform.Find ("playernumber/label").gameObject.GetComponent<Text>();
		if (playerNumber == null) {
			throw new KuggenException ("Text component required for 'playernumber/label' gameobject in " + this);
		}

		highlightColor = playerNumber.color; 

	}

	private void InitViews(){
		views.Add (PlayerSelectState.ViewState.Connected, 	 () => setConnected () );
		views.Add (PlayerSelectState.ViewState.Disconnected, () => setDisconnected() );
		views.Add (PlayerSelectState.ViewState.Ready, 		 () => setReady() );
	}

	public void updateView(PlayerSelectState.ViewState state){
		if (views.ContainsKey (state)) {
			views [state].Invoke ();
		}
	}

	private void setDisconnected(){
		Texture2D background = Resources.Load (PATH + "background_disconnected") as Texture2D;
		Texture2D status = Resources.Load (PATH + "label_disconnected") as Texture2D;

		if (background == null) {
			throw new KuggenException ("Unable to find Texture2D 'sprites/playerSelect/background_disconnected', make sure the resource is available in the PATH");
		}

		if (status == null) {
			throw new KuggenException ("Unable to find Texture2D 'sprites/playerSelect/label_disconnected', make sure the resource is available in the PATH");
		}

		backgroundTexture.texture = background;
		statusTexture.texture = status;
		statusTexture.color = Color.white;
		playerNumber.color = new Color (255f, 255f, 255f, 0.25f);

	}

	private void setConnected(){
		Texture2D background = Resources.Load (PATH + "background_connected") as Texture2D;
		Texture2D status = Resources.Load (PATH + "label_connected") as Texture2D;

		if (background == null) {
			throw new KuggenException ("Unable to find Texture2D 'sprites/playerSelect/background_connected', make sure the resource is available in the PATH");
		}

		if (status == null) {
			throw new KuggenException ("Unable to find Texture2D 'sprites/playerSelect/label_connected', make sure the resource is available in the PATH");
		}

		backgroundTexture.texture = background;
		statusTexture.texture = status;
		statusTexture.color = Color.white;
		playerNumber.color = new Color (255f, 255f, 255f, 0.25f);
	}

	private void setReady(){
		Texture2D background = Resources.Load (PATH + "background_connected") as Texture2D;
		Texture2D status = Resources.Load (PATH + "label_ready") as Texture2D;

		if (background == null) {
			throw new KuggenException ("Unable to find Texture2D 'sprites/playerSelect/background_connected', make sure the resource is available in the PATH");
		}

		if (status == null) {
			throw new KuggenException ("Unable to find Texture2D 'sprites/playerSelect/label_ready', make sure the resource is available in the PATH");
		}

		backgroundTexture.texture = background;
		statusTexture.texture = status;
		statusTexture.color = highlightColor;
		playerNumber.color = highlightColor;
	}

}
