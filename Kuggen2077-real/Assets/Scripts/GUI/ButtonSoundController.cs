using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSoundController : MonoBehaviour {

	public AudioClip select;
	public AudioClip submit;

	void Start() {
		InitEvents ();
	}

	void InitEvents(){
		EventTrigger trigger = GetComponent<EventTrigger>();

		if (trigger == null) {
			throw new KuggenException ("EventTrigger component required for " + this);
		}

		// Handle select
		EventTrigger.Entry selectEntry = new EventTrigger.Entry();
		selectEntry.eventID = EventTriggerType.Select;
		selectEntry.callback.AddListener((data) => { OnSelectDelegate(); });
		trigger.triggers.Add(selectEntry);

		// Handle Submit
		EventTrigger.Entry submitEntry = new EventTrigger.Entry();
		submitEntry.eventID = EventTriggerType.Submit;
		submitEntry.callback.AddListener((data) => { OnSubmitDelegate(); });
		trigger.triggers.Add(submitEntry);
	}

	public void OnSelectDelegate() {
		SoundManager.Instance.PlaySingle (select);
	}

	public void OnSubmitDelegate() {
		SoundManager.Instance.PlaySingle (submit);
	}
}
