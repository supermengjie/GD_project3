using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroAI : MonoBehaviour {

    public float lookRadious = 5f;
    Transform target;

    //public float moveForce = 0f;
    private Rigidbody rbody;
    public Vector3 moveDir;
    public LayerMask whatIsWall;
    public float maxDistFromWall = 0f;
    public int maxDist = 5;
    public int minDist = 5;
    // Use this for initialization

    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool rotatingLeft = false;
    private bool rotatingRight = false;
    private bool isWalking = false;

    private void Awake()
    {
        target = GameObject.FindWithTag("Boss").transform;
    }

    
    void Start () {
        rbody = GetComponent<Rigidbody>();
        moveDir = ChooseDirection();
        transform.rotation = Quaternion.LookRotation(moveDir);



    }
	
	// Update is called once per frame
	void Update () {
        /*rbody.velocity = moveDir * moveSpeed;
        if(Physics.Raycast(transform.position,transform.forward,maxDistFromWall,whatIsWall))
        {
            moveDir = ChooseDirection();
            transform.rotation = Quaternion.LookRotation(moveDir);

        }*/

       // transform.LookAt(target);

        
       if (Vector3.Distance(transform.position, target.position) <= 10)
        {
            transform.LookAt(target);
            Debug.Log("we at" + transform.position + " boss at" + target.position);

            if (Vector3.Distance(transform.position, target.position) >= minDist)
            {
                //Debug.Log("time: "+Time.deltaTime);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }else{

            if (isWandering == false)
            {
                StartCoroutine(Wander());
            }

           if (rotatingRight == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            }
            if (rotatingLeft == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
            }

            if (isWalking == true)
            {
                //moveDir = ChooseDirection();
                transform.position += transform.forward * moveSpeed * Time.deltaTime;

            }
        }
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadious);
    }

    Vector3 ChooseDirection()
    {
        int i = Random.Range(0, 3);
        Vector3 temp = new Vector3();
        if(i==0)
        {
            temp = transform.forward;
        }
        else if (i == 1)
        {
            temp = -transform.forward;
        }
        else if (i == 2)
        {
            temp = transform.right;
        }
        else if (i == 3)
        {
            temp = -transform.right;
           
        }

        return temp;
    }


    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(0, 2);
        int rotateLorR = Random.Range(0, 3);
        int walkWait = Random.Range(0, 2);
        int walkTime = Random.Range(1, 3);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            rotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            rotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            rotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            rotatingLeft = false;
        }
        isWandering = false;
    }

}
