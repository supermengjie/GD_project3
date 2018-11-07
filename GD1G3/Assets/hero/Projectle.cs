using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectle : MonoBehaviour {

    public float speed;
    private Transform player;
    private Vector3 target;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Boss").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        transform.LookAt(target);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * speed;
        if(Mathf.Abs(transform.localPosition.x) > 50 || Mathf.Abs(transform.localPosition.z) > 50)
        {
            DestroyProjectile();
        }
    
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boss")){
            Debug.Log("we hit");
            DestroyProjectile();
        }

    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
