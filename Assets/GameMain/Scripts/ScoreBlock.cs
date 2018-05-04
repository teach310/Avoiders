using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBlock : MonoBehaviour {
	[SerializeField]
	private GameManager gameManager;

	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Block"){
			Destroy(other.gameObject);
			gameManager.SetScore();
		}
	}
}
