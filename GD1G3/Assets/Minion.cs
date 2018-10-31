using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {
	
	public bool fast;
	public bool snake;
	public bool wiggle;
	public int minionSpeed;
	
	private float minionX = 0;
	private float minionY = 0;
	private int minionType;
	

	// Use this for initialization
	void Start () {
		if (fast){
			minionType = 1;
		}
		else if (snake){
			minionType = 2;
		}
		else if (wiggle){
			minionType = 3;
		}
	}
	
	// Update is called once per frame
	void Update () {
		MinionMove(minionType, minionX, minionY);
	}
	
	// Minion Movement
	void MinionMove(int minionType, float x, float y){
		// fast
		if (minionType == 1){
			if (x == 0 || y == 0){
				GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5.0f, 5.0f), 10.0f, 0.0f);
			}
		}
		// wiggle
		else if (minionType == 2){
			GetComponent<Rigidbody>().velocity = new Vector3(minionSpeed, Mathf.Sin(Time.time) * 5, 0.0f);
		}
		// snake
		else if (minionType == 3){
			GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Cos(Time.time) * 2, -minionSpeed, 0.0f);
		}
		
		Vector3 minionPos = transform.position;
		
		// if minion reaches bottom of screen, wrap to top
		if (minionPos.y < -6){
			minionPos.y = 6;
		}
		
		// if minion reaches left/right, wrap to opposite side
		if (minionPos.x > 15){
			minionPos.x = -15;
		}
		else if(minionPos.x < -15){
			minionPos.x = 15;
		}
		transform.position = minionPos;
	}
}
