using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	void Update () {
        	gameObject.transform.position += new Vector3(0,0,-0.5f);
	}
}
