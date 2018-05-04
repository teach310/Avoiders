using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour {

    public GameObject wall;
    public GameObject spawner;

	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnWall");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private IEnumerator SpawnWall()
    {
        int n = 0;
        while (true){
            n = Random.Range(0, 4);
            switch (n)
            {
                case 0:
                    Instantiate(wall, new Vector3(-2.66f, 0.6f, 44.1f), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(wall, new Vector3(-0.92f, 0.6f, 44.1f), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(wall, new Vector3(1.0f, 0.6f, 44.1f), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(wall, new Vector3(3.0f, 0.6f, 44.1f), Quaternion.identity);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.4f);
        }
    }
}
