using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkBackAndForth : MonoBehaviour {

	// Use this for initialization
	void Start () {
 
    }
    float direction = 3.0F;
    // Update is called once per frame
    void Update () {
        CharacterController controller = GetComponent<CharacterController>();
        if (transform.position[2] > 5)
        {
            direction = -3.0F;
            Debug.Log("move down");
        }
        else if (transform.position[2] < -5)
        {
            direction = 3.0F;
            Debug.Log("move up");
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.Log(forward*direction);
        Debug.Log(transform.position);
        controller.SimpleMove(forward * direction);
    }
}
