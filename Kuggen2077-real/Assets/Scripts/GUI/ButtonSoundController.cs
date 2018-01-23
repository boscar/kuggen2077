using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSoundController : MonoBehaviour, ISelectHandler, ISubmitHandler {

	public AudioClip select;
	public AudioClip submit;

	public void OnSelect(BaseEventData data) {
		GlobalSoundManager.Instance.PlaySingle (select);
	}

	public void OnSubmit(BaseEventData data) {
		GlobalSoundManager.Instance.PlaySingle (submit);
	}
}
