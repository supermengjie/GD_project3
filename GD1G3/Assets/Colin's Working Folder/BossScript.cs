using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{
    public int health;
    public int energy;
    public float speed = 3.0F;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Debug.Log(transform.position);
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity[1], Input.GetAxis("Vertical") * speed);
        if (health == 0)
        {
            //endgame
        }
        if (energy < 100)
        {
            Debug.Log(Time.time);
        }

    }

}