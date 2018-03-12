using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiMove : MonoBehaviour {
    [SerializeField]
    Rigidbody RB;
    public int speed;
    public GameObject Emitter;
    private GameObject[] Obstacle;
    private GameObject[] Hazards;
    private GameObject Player;
    public Transform fucknamingthis;
    public PlayerTeleControl teleparams;
    private bool HasCollided;

    double angle;
    Vector3 Vector;
	// Use this for initialization
	
    private void Start()
    {
        Hazards = GameObject.FindGameObjectsWithTag("Hazards");
        Obstacle = GameObject.FindGameObjectsWithTag("Obstacles");
        Player = GameObject.FindGameObjectWithTag("Player");
        teleparams = GameObject.FindGameObjectWithTag("Controller").GetComponent<PlayerTeleControl>();
        Emitter = GameObject.Find("KunaiEmitter");
        RB = GetComponent<Rigidbody>();
        fucknamingthis = null;


        transform.position = Emitter.transform.position;
    }



    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < Obstacle.Length; i++)
        {
            if (collision.gameObject == Obstacle[i].gameObject)
            {
                HasCollided = true;
                teleparams.activeKunai = false;
                RB.velocity = Vector3.zero;
                RB.useGravity = false;
            }
            else
            {
                HasCollided = false;
            }
        }
        if (collision.gameObject == Player.gameObject)
        {
            GameObject.Destroy(this.gameObject);
            teleparams.activeKunai = false;
            teleparams.CanTeleport = false;
            
        }
        for (int k = 0; k < Hazards.Length; k++)
        {
            if (collision.gameObject == Hazards[k].gameObject)
            {
                GameObject.Destroy(this.gameObject);
            }
        }

    }

    public void setDirection(Vector3 directionVector)
    {
        
        Debug.Log(directionVector);
       if(Input.GetMouseButtonDown(0))
        {
           // fucknamingthis.transform.position = Input.mousePosition;
        }
        //transform.LookAt(fucknamingthis);
        RB.velocity = directionVector * speed;
    }


    // Update is called once per frame
    void Update () {
        
        /*
        if (HasCollided == false)
        {

            Vector.x = Input.mousePosition.x - Player.transform.position.x;
            Vector.y = Input.mousePosition.y - Player.transform.position.y;
            Vector.z = 0;
            Vector.Normalize();
            
            transform.position += Vector * speed * Time.deltaTime;
           
               // transform.position -= Vector * speed * Time.deltaTime;
            
            
        }*/
        
    }
}
