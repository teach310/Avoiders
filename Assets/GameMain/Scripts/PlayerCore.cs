using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerCore : MonoBehaviour {

	public GameObject RightBallGameObj;
	public GameObject LeftBallGameObj;
	void Start () {
		PlayerInput playerInput = GetComponent<PlayerInput>();
	}
}
