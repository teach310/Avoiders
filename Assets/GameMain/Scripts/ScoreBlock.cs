using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreBlock : MonoBehaviour {

	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Block"){
			Destroy(other.gameObject);
			MessageBroker.Default.Publish(new ScoreBlockHit());
		}
	}
}
