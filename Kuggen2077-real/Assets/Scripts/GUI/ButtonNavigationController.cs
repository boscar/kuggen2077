using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonNavigationController : MonoBehaviour, ISubmitHandler {

	public ApplicationState.Command Scene = ApplicationState.Command.Main;

	public void OnSubmit(BaseEventData data) {
		ApplicationManager.Instance.ChangeScene(Scene);
	}

}
