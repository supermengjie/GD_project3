using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {
	
	public bool fast;
	public bool wiggle;
	public bool snake;
	public int minionSpeed;
	public float damage;
	
	private float minionX = 0;
	private float minionY = 0;
	private float xVar;
    private int minionDirX;
    private int minionDirY;
    private int minionType;
	private Rigidbody rb;
    
	
	

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
		rb = GetComponent<Rigidbody>();
        minionDirX = 1;
        minionDirY = 1;
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
				rb.velocity = new Vector3(xVar * minionDirX, 0.0f, -minionSpeed * minionDirY);
			}
		}
		// wiggle
		else if (minionType == 2){
			rb.velocity = new Vector3(minionSpeed * minionDirX, 0.0f, Mathf.Sin(Time.time) * xVar * minionDirY);
		}
		// snake
		else if (minionType == 3){
			rb.velocity = new Vector3(Mathf.Cos(Time.time) * xVar * minionDirX, 0.0f, -minionSpeed * minionDirY);
		}
		
		Vector3 minionPos = transform.position;
		
		// if minion reaches bottom/top,  wrap to opposite side
		if (minionPos.z < -45){
            minionDirY *= -1;
            minionPos.z = -45;
        }
		else if (minionPos.z > 45){
            minionDirY *= -1;
            minionPos.z = 45;
        }
		
		// if minion reaches left/right, wrap to opposite side
		if (minionPos.x > 45){
            minionDirX *= -1;
            minionPos.x = 45;
        }
		else if(minionPos.x < -45){
            minionDirX *= -1;
            minionPos.x = -45;
        }
		
		transform.position = minionPos;
	}
}
