using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class BossScript : MonoBehaviour
{
    private float hp;
    public float speed = 3.0F;
    private Rigidbody rb;
    public Image healthBar;
    public float maxHp;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = maxHp;
    }

    private void Update()
    {
        healthBar.fillAmount = hp / maxHp;
        //Debug.Log(transform.position);
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity[1], Input.GetAxis("Vertical") * speed);
        
			if (hp <= 0){
				// Game Over
			}
			
        Vector2 mouseLocation = Input.mousePosition;
        double newAngle = GetDirection(mouseLocation[0], mouseLocation[1]);
        if (!PauseMenu.IsGamePaused)
        {
            transform.localEulerAngles = new Vector3(0, (float)newAngle, 0);
        }
    }

    double GetDirection(float x, float y)
    {
        Vector3 gameLocation = transform.localPosition;
        Vector2 screenCoordinates = Camera.main.WorldToScreenPoint(gameLocation);
        double ydistance = screenCoordinates[1] - y;
        double xdistance = screenCoordinates[0] - x;
        double angleToMouse = Math.Atan2(xdistance, ydistance);
        angleToMouse *= 180 / Math.PI;
        return angleToMouse;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 12)
        {
            hp -= 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            hp -= 1; 
        }
    }
}