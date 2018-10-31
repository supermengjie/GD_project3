using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class MovementScript : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 horizontal = transform.TransformDirection(Vector3.right);
        float updownSpeed = speed * Input.GetAxis("Vertical");
        float leftrightSpeed = speed * Input.GetAxis("Horizontal");
        Vector3 movement = forward * updownSpeed + horizontal * leftrightSpeed;
        //Debug.Log(transform.position);
        controller.SimpleMove(movement);
    }
}