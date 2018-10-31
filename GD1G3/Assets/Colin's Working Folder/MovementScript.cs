using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class MovementScript : MonoBehaviour
{
    public float speed = 3.0F;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
        //Debug.Log(transform.position);
        rb.velocity = new Vector3(Input.GetAxis("Horizontal")*speed,rb.velocity[1],Input.GetAxis("Vertical")*speed);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.ToString());
    }

}