using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroControl : MonoBehaviour {


    public float speed = 3.0F;
    private Rigidbody rb;
    Transform target;

    private void Awake()
    {
        target = GameObject.FindWithTag("Boss").transform;
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            rb.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            rb.position += -transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed, Space.World);
            rb.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed, Space.World);
            rb.position += -transform.right * speed * Time.deltaTime;
        }
    }

}
