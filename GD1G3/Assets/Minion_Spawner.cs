using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion_Spawner : MonoBehaviour {

	public Image energyBar;
	public GameObject fastMinion;
	public GameObject snakeMinion;
	public GameObject wiggleMinion;
	public float fastCost;
	public float snakeCost;
	public float wiggleCost;
	public float energyGain;
	public float energyMax;
	public float spawnOffset;
	public float spawnDelay;
	
	
	private float energy;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (energy < energyMax){
			energy += Time.deltaTime;
		}
		if (Input.GetAxis("Spawn1") == 1 && energy >= fastCost){
			GameObject go = Instantiate(fastMinion) as GameObject;
			go.transform.position = transform.position + new Vector3(spawnOffset, 0, 0);
			energy -= fastCost;
		}
		else if (Input.GetAxis("Spawn2") == 1 && energy >= snakeCost){
			GameObject go = Instantiate(snakeMinion) as GameObject;
			go.transform.position = transform.position + new Vector3(spawnOffset, 0, 0);
			energy -= snakeCost;
		}
		else if (Input.GetAxis("Spawn3") == 1 && energy >= wiggleCost){
			GameObject go = Instantiate(wiggleMinion) as GameObject;
			go.transform.position = transform.position + new Vector3(spawnOffset, 0, 0);
			energy -= wiggleCost;
		}
		
		energyBar.fillAmount = energy / energyMax;
		
	}
}
