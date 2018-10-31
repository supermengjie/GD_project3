using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {
	
	public bool fast;
	public bool wiggle;
	public bool snake;
	public int minionSpeed;
	
	private float minionX = 0;
	private float minionY = 0;
	private float xVar;
	private int minionType;
	
	

	// Use this for initialization
	void Start () {
		// xVar is used to add variation to the patterns
		if (fast){
			minionType = 1;
			xVar = Random.Range(-5.0f, 5.0f);
		}
		else if (wiggle){
			minionType = 2;
			xVar = Random.Range(4.0f, 6.0f);
		}
		else if (snake){
			minionType = 3;
			xVar = Random.Range(1.0f, 4.0f);
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
				GetComponent<Rigidbody>().velocity = new Vector3(xVar, -minionSpeed, 0.0f);
			}
		}
		// wiggle
		else if (minionType == 2){
			GetComponent<Rigidbody>().velocity = new Vector3(minionSpeed, Mathf.Sin(Time.time) * xVar, 0.0f);
		}
		// snake
		else if (minionType == 3){
			GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Cos(Time.time) * xVar, -minionSpeed, 0.0f);
		}
		
		Vector3 minionPos = transform.position;
		
		// if minion reaches bottom/top,  wrap to opposite side
		if (minionPos.y < -6){
			minionPos.y = 6;
		}
		else if (minionPos.y > 6){
			minionPos.y = -6;
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
