using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion_Spawner : MonoBehaviour {

	public Image energyBar;
	public GameObject fastMinion;
	public GameObject snakeMinion;
	public GameObject wiggleMinion;
	public GameObject wallObject;
	public float fastCost;
	public float snakeCost;
	public float wiggleCost;
	public float wallCost;
	public float energyGain;
	public float energyMax;
	public float spawnOffset;
	public float spawnDelay;
	
	
	private float energy;
	private float spawning;
	public Animator anim;
	
	private float lasttime  =0f;
	
	// Use this for initialization
	void Start () {
		spawnOffset *= -1;
		spawning = spawnDelay;
		energy = energyMax;

		//anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
    
        if (energy < energyMax){
			energy += energyGain * Time.deltaTime;
            energyBar.fillAmount = energy / energyMax;
        }
		if (Time.time  > lasttime+spawnDelay){
			Vector3 spawnLocation = transform.TransformDirection(Vector3.forward);
			spawnLocation *= spawnOffset;
			spawnLocation += transform.localPosition;
            lasttime = Time.time;
			if (Input.GetAxis("Spawn1") == 1 && energy >= fastCost){
				GameObject go = Instantiate(fastMinion) as GameObject;
				go.transform.position = spawnLocation;
				anim.SetBool("Spawning", true);
				energy -= fastCost;
                spawning = spawnDelay;
            }
			else if (Input.GetAxis("Spawn2") == 1 && energy >= snakeCost){
				GameObject go = Instantiate(snakeMinion) as GameObject;
				go.transform.position = spawnLocation;
				anim.SetBool("Spawning", true);
				energy -= snakeCost;
                spawning = spawnDelay;
            }
			else if (Input.GetAxis("Spawn3") == 1 && energy >= wiggleCost){
				GameObject go = Instantiate(wiggleMinion) as GameObject;
				go.transform.position = spawnLocation;
				anim.SetBool("Spawning", true);
				energy -= wiggleCost;
                spawning = spawnDelay;
            }
			else if (Input.GetAxis("Spawn4") == 1 && energy >= wallCost){
				GameObject go = Instantiate(wallObject) as GameObject;
				go.transform.position = spawnLocation;
				anim.SetBool("Spawning", true);
			    energy -= wallCost;
                spawning = spawnDelay;
            }
			anim.SetBool("Spawning", false);
            
		}
		
	}
}
