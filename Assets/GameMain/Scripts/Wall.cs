using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += new Vector3(0,0,-1);
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag=="Player")
        {
            Debug.Log("GameOver");
        }
	}
}
