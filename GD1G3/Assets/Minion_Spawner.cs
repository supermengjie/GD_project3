using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion_Spawner : MonoBehaviour {


	public GameObject fastMinion;
	public GameObject snakeMinion;
	public GameObject wiggleMinion;
    public int energyMax;
    public float energyRegenPeriod;
    public float spawnOffset;
    public int framesSinceLastSpawn;
    public int spawn1Energy;
    public int spawn2Energy;
    public int spawn3Energy;
    private int currentEnergy;
    // Use this for initialization
    void Start () {
        spawnOffset *= -1;
        currentEnergy = energyMax;
	}
	int currentFrames = 0;
    float lastTime = 0;
    // Update is called once per frame
    void Update () {
        if (currentEnergy < 100)
        {
            if (Time.time > lastTime + energyRegenPeriod)
            {
                lastTime = Time.time;
                currentEnergy += 1;
            }
        }
        if (currentFrames > framesSinceLastSpawn)
        {
            Vector3 spawnLocation = transform.TransformDirection(Vector3.forward);
            spawnLocation *= spawnOffset;
            spawnLocation += transform.localPosition;
            if (Input.GetAxis("Spawn1") == 1)
            {
                if (currentEnergy > spawn1Energy)
                {
                    GameObject go = Instantiate(fastMinion) as GameObject;
                    go.transform.position = spawnLocation;
                    currentFrames = 0;
                    currentEnergy -= spawn1Energy;
                }
            }
            else if (Input.GetAxis("Spawn2") == 1)
            {
                if (currentEnergy > spawn2Energy)
                {
                    GameObject go = Instantiate(snakeMinion) as GameObject;
                    go.transform.position = spawnLocation;
                    currentFrames = 0;
                    currentEnergy -= spawn2Energy;
                }
                
            }
            else if (Input.GetAxis("Spawn3") == 1)
            {
                if(currentEnergy > spawn3Energy)
                {
                    GameObject go = Instantiate(wiggleMinion) as GameObject;
                    go.transform.position = spawnLocation;
                    currentFrames = 0;
                    currentEnergy -= spawn3Energy;
                }
                
            }
        }
        currentFrames += 1;
	}
}
