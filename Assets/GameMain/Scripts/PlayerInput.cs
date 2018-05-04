using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;

public class PlayerInput : MonoBehaviour {
	public EventTrigger _EventRightTrigger;
	public EventTrigger _EventLeftTrigger;
	public BoolReactiveProperty isRightPressDown = new BoolReactiveProperty();
	public BoolReactiveProperty isLeftPressDown = new BoolReactiveProperty();

	void Start(){
		//Downイベントの登録
		EventTrigger.Entry pressRightDown = new EventTrigger.Entry ();
		pressRightDown.eventID = EventTriggerType.PointerDown;
		pressRightDown.callback.AddListener ((data) => InputRightButtonDown ());
        _EventRightTrigger.triggers.Add (pressRightDown);

		EventTrigger.Entry pressLeftDown = new EventTrigger.Entry ();
		pressLeftDown.eventID = EventTriggerType.PointerDown;
		pressLeftDown.callback.AddListener ((data) =>  InputLeftButtonDown ());
        _EventLeftTrigger.triggers.Add (pressLeftDown);

		//Upイベントの登録
		EventTrigger.Entry pressRightUp = new EventTrigger.Entry ();
        pressRightUp.eventID = EventTriggerType.PointerUp; 
        pressRightUp.callback.AddListener ((data) => InputRightButtonUp());
        _EventRightTrigger.triggers.Add (pressRightUp);

		EventTrigger.Entry pressLeftUp = new EventTrigger.Entry ();
        pressLeftUp.eventID = EventTriggerType.PointerUp; 
        pressLeftUp.callback.AddListener ((data) => InputLeftButtonUp());
        _EventLeftTrigger.triggers.Add (pressLeftUp);
	}

	public void InputRightButtonDown(){
		isRightPressDown.Value = true;
	}
	public void InputRightButtonUp(){
		isRightPressDown.Value = false;
	}
	public void InputLeftButtonDown(){
		isLeftPressDown.Value = true;
	}
	public void InputLeftButtonUp(){
		isLeftPressDown.Value = false;
	}
}
