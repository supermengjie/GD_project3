﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    public int health;
    public int energy;
    public float speed = 3.0F;
		public float hp;
		
		private float maxHp;
    private Rigidbody rb;
		
		
    private void Start()
    {
      rb = GetComponent<Rigidbody>();
			maxHp = hp;
    }
    void Update()
    {
        //Debug.Log(transform.position);
        rb.velocity = new Vector3(Input.GetAxis("Horizontal")*speed,rb.velocity[1],Input.GetAxis("Vertical")*speed);
        if ( health == 0)
        {
            //endgame
        }
        if (energy < 100)
        {
            Debug.Log(Time.time);
        }
        
    }

}