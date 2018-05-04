using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerCore : MonoBehaviour {

	public GameObject RightBallGameObj;
	public GameObject LeftBallGameObj;
	void Start () {
		PlayerInput playerInput = GetComponent<PlayerInput>();
		playerInput.isRightPressDown
		.DistinctUntilChanged().Subscribe(x => {
			if(x){
				RightBallGameObj.transform.position = new Vector3(3, 0.67f, 0);
			}else{
				RightBallGameObj.transform.position = new Vector3(1, 0.67f, 0); 
			}
		});

		playerInput.isLeftPressDown
		.DistinctUntilChanged().Subscribe(x => {
			if(x){
				LeftBallGameObj.transform.position = new Vector3(-2.66f, 0.67f, 0);
			}else{
				LeftBallGameObj.transform.position = new Vector3(-0.92f, 0.67f, 0); 
			}
		});
	}
}
