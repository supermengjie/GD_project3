using UnityEngine;
using System.Collections;
using System;


public class BossScript : MonoBehaviour
{
    public int healthMax;
    public int energyMax;
    public float energyRegenPeriod;
    public float speed = 3.0F;
    private Rigidbody rb;
    private int currentHealth;
    private int currentEnergy;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = healthMax;
        currentEnergy = energyMax;
    }
    float lastTime = 0;
    float lastAngle = 0;
    void Update()
    {
        //Debug.Log(transform.position);
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity[1], Input.GetAxis("Vertical") * speed);
        if (currentHealth == 0)
        {
            //endgame
        }
        if (currentEnergy < 100)
        {
            if (Time.time > lastTime + energyRegenPeriod)
            {
                lastTime = Time.time;
                currentEnergy += 1;
            }
        }
        Vector2 mouseLocation = Input.mousePosition;
        double newAngle = GetDirection(mouseLocation[0], mouseLocation[1]);
        transform.localEulerAngles = new Vector3(0, (float)newAngle, 0);
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

}