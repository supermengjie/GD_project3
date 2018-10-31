using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion_Spawner : MonoBehaviour {


	public GameObject fastMinion;
	public GameObject snakeMinion;
	public GameObject wiggleMinion;
    public float spawnOffset;
    public int framesSinceLastSpawn;
	// Use this for initialization
	void Start () {
	}
	int currentFrames = 0;
	// Update is called once per frame
	void Update () {
        if (currentFrames > framesSinceLastSpawn)
        {
            if (Input.GetAxis("Spawn1") == 1)
            {
                GameObject go = Instantiate(fastMinion) as GameObject;
                go.transform.position = transform.position + new Vector3(spawnOffset, 0, 0);
                currentFrames = 0;
            }
            else if (Input.GetAxis("Spawn2") == 1)
            {
                GameObject go = Instantiate(snakeMinion) as GameObject;
                go.transform.position = transform.position + new Vector3(spawnOffset, 0, 0);
                currentFrames = 0;
            }
            else if (Input.GetAxis("Spawn3") == 1)
            {
                GameObject go = Instantiate(wiggleMinion) as GameObject;
                go.transform.position = transform.position + new Vector3(spawnOffset, 0, 0);
                currentFrames = 0;
            }
        }
        currentFrames += 1;
	}
}
