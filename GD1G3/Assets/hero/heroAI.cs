using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class heroAI : MonoBehaviour {

	public Image hpBar;
    public float lookRadious = 5f;
    Transform target;

    //public float moveForce = 0f;
    private Rigidbody rbody;
    public Vector3 moveDir;
    public LayerMask whatIsWall;
    public float maxDistFromWall = 0f;
    public int maxDist = 5;
    public int minDist = 5;
    public float maxHealth = 100;
    public int bulletDamage = 5;
    public int minionDamage = 10;
    public float bulletStagger = 0.25F;
    public float minionStagger = 0.5F;
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;
    private float timeBTWShots;
    public float starttimeBTWShots;
    public string nextScene;

    private float staggered = 0F;
    private float currentHealth;
    private bool isWandering = false;
    private bool rotatingLeft = false;
    private bool rotatingRight = false;
    private bool isWalking = false;
    private bool isStaggered = false;
    public GameObject projectile;

    private void Awake()
    {
        target = GameObject.FindWithTag("Boss").transform;
    }

    
    void Start () {
        rbody = GetComponent<Rigidbody>();
        moveDir = ChooseDirection();
        transform.rotation = Quaternion.LookRotation(moveDir);
        currentHealth = maxHealth;

    }
	
	// Update is called once per frame
	void Update () {
       if (staggered > 0)
        {
            StartCoroutine(stagger(staggered));
            staggered = 0;
        }
        if (isStaggered == false)
        {
            if(transform.position.x > 40)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
                transform.position = new Vector3(40, transform.position.y,transform.position.z);
            }
            if (transform.position.x < -40)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
                transform.position = new Vector3(-40, transform.position.y, transform.position.z);
            }
            if (transform.position.z > 40)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
                transform.position = new Vector3(transform.position.x, transform.position.y, 40);
            }
            if (transform.position.z < -40)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
                transform.position = new Vector3(transform.position.z, transform.position.y, -40);
            }
            if (Vector3.Distance(transform.position, target.position) <= 10)
            {
                transform.LookAt(target);
                if (Vector3.Distance(transform.position, target.position) >= minDist)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                }
            }
            else
            {

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
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;

                }

               
                
            }
            if (timeBTWShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBTWShots = starttimeBTWShots;

            }
            else
            {
                timeBTWShots -= Time.deltaTime;
            }


        }
		hpBar.fillAmount = currentHealth / maxHealth;
	}

    IEnumerator stagger(float x)
    {
        Debug.Log("in the stagger function");
        Debug.Log(Time.time);
        isStaggered = true;
        yield return new WaitForSecondsRealtime(x);
        isStaggered = false;
        Debug.Log(Time.time);
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 9) // Collision with bullet
        {
            Destroy(collision.gameObject);
            currentHealth -= bulletDamage;
            Debug.Log(currentHealth);
            staggered = bulletStagger;
            //stagger less than when there is a collision witha  minion?
        }

        if (collision.gameObject.layer == 8) // Collision with minion
        {
            Destroy(collision.gameObject);
            currentHealth -= minionDamage;
            staggered = minionStagger;
        }
        if (collision.gameObject.layer == 11) // Collision with Boss
        {
            //stop for a few seconds?
        }
        if ( currentHealth <= 0) // round won
        {
            Debug.Log("GG");
            SceneManager.LoadScene(nextScene);
            //change to new scene somehow
        }
    }
}
