using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update

    bool onX = false;
    bool started = false;
    bool dead = true;
    float deathThresh = 0.5f;
    Rigidbody rb;
    [SerializeField] float speed;
    Vector3 xVec;
    Vector3 zVec;
    [SerializeField] Camera cam;
    [SerializeField] Vector3 camOffset = new Vector3(-11,16,-14);


    public static BallController instance;


    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        xVec = new Vector3(speed, 0, 0);
        zVec = new Vector3(0, 0, speed);
    }

    public bool GetDead()
    {
        return dead;
    }
    public void Press()
    {
        if (!started) return;

        onX = !onX;
    }
    // Update is called once per frame
    public void GameStart()
    {
        print("yipeee");
        dead = false;
        started = true;
    }
    public void GameOver()
    {
        dead = true;
        GameManager.instance.GameOver();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            Destroy(col.gameObject);
            ScoreManager.instance.IncrementScore();
        }
    }
    void Update()
    {
        //Make the ball fall when it’s not on the platform and the game should be over.
        if (transform.position.y < deathThresh) GameOver();
        if (dead) return;
        float dt = Time.deltaTime;
        cam.transform.position = transform.position + camOffset;
        if (onX)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y,0);

            //rb.AddForce(xVec * dt, ForceMode.Force);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, speed);
            //rb.velocity = zVec;
            //rb.AddForce(zVec * dt, ForceMode.Force);
        }
       
    }
}
