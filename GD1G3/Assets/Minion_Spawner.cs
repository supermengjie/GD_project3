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
            float currentRotation = transform.localEulerAngles.y;
            Vector3 spawnLocation = new Vector3(Mathf.Sin(currentRotation), 0, Mathf.Cos(currentRotation));
            spawnLocation *= spawnOffset;
            spawnLocation += transform.localPosition;
            spawnLocation[1] = 0.1F;
            Debug.Log(transform.localPosition);
            if (Input.GetAxis("Spawn1") == 1)
            {
                GameObject go = Instantiate(fastMinion) as GameObject;
                go.transform.position = spawnLocation;
                currentFrames = 0;
                Debug.Log("minion spawn position");
                Debug.Log(go.transform.position);
            }
            else if (Input.GetAxis("Spawn2") == 1)
            {
                GameObject go = Instantiate(snakeMinion) as GameObject;
                go.transform.position = spawnLocation;
                currentFrames = 0;
            }
            else if (Input.GetAxis("Spawn3") == 1)
            {
                GameObject go = Instantiate(wiggleMinion) as GameObject;
                go.transform.position = spawnLocation;
                currentFrames = 0;
            }
        }
        currentFrames += 1;
	}
}
