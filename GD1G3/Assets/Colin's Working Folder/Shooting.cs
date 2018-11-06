using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject Bullet;
    public float bulletSpeed;
    public float coolDown;
    public int spawnOffset;
	// Use this for initialization
	void Start () {
		
	}
    float lastTime = 0;
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Fire1") == 1)
        {
            if (Time.time > coolDown + lastTime)
            {
                Vector3 currentDirection = transform.TransformDirection(Vector3.forward);
                Vector3 spawnLocation = currentDirection * spawnOffset * -1;
                spawnLocation += transform.localPosition;
                GameObject go = Instantiate(Bullet) as GameObject;
                go.transform.position = spawnLocation;
                go.transform.rotation = transform.rotation;
                Rigidbody rb = go.GetComponent<Rigidbody>();
                rb.velocity = currentDirection * -1 * bulletSpeed;
                lastTime = Time.time;
            }
        }
	}
}
