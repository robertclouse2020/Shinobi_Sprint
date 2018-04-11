using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiMove : MonoBehaviour
{
    [SerializeField]
    Rigidbody RB;
    public int speed;

    public GameObject Emitter;
    private GameObject[] Obstacle;
    private GameObject[] Hazards;
    private GameObject Player;
    private GameObject[] checkpoints;
    public PlayerTeleControl teleparams;
    public bool HasCollided = true;
    public float timer = 0.0f;
    public float maxThrowTime = 3.0f;
    Vector3 Vector;
    // Use this for initialization

    private void Start()
    {
        Hazards = GameObject.FindGameObjectsWithTag("Hazards");
        Obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
        Player = GameObject.FindGameObjectWithTag("Player");
        teleparams = GameObject.FindGameObjectWithTag("Controller").GetComponent<PlayerTeleControl>();
        Emitter = GameObject.Find("KunaiEmitter");
        checkpoints = GameObject.FindGameObjectsWithTag("Respawn");
        RB = GetComponent<Rigidbody>();


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
        }
        if (collision.gameObject == Player.gameObject)
        {
            HasCollided = true;
            GameObject.Destroy(this.gameObject);
            teleparams.activeKunai = false;
            teleparams.CanTeleport = false;

        }
        for (int k = 0; k < Hazards.Length; k++)
        {
            if (collision.gameObject == Hazards[k].gameObject)
            {
                HasCollided = true;
                GameObject.Destroy(this.gameObject);
                teleparams.activeKunai = false;
                teleparams.CanTeleport = false;
            }
        }

        for (int j = 0; j < checkpoints.Length; j++)
        {
            if (collision.gameObject == checkpoints[j].gameObject)
            {
                checkpoints[j].GetComponent<Renderer>().material.color = Color.gray;
            }

        }

    }



    public void setDirection(Vector3 directionVector)
    {
        Vector3 DirectionSpeed;

        directionVector.z = 0;

        
        DirectionSpeed.x = directionVector.x * speed;
        DirectionSpeed.y = directionVector.y * speed;
        DirectionSpeed.z = 0;
        
        Debug.Log(DirectionSpeed.magnitude);
        RB.velocity = DirectionSpeed;

    }

    public void setRotation(float angle)
    {

        Quaternion test = Quaternion.identity;
        test.eulerAngles = new Vector3(0, 0, angle);
        RB.transform.localRotation = test;

    }
    // Update is called once per frame
    void Update()
    {
        if (!HasCollided)
        {
            timer += Time.deltaTime;
            if (timer > maxThrowTime)
            {
                HasCollided = true;
                timer = 0;
            }
        }
        
        

    }
}
