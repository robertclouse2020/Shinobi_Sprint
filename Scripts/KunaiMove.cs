using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiMove : MonoBehaviour {
    public int speed;
    public GameObject Emitter;
    private GameObject[] Obstacle;
    private GameObject[] Hazards;
    private GameObject Player;
    public PlayerTeleControl teleparams;
    private bool HasCollided;
    Vector3 Vector;
	// Use this for initialization
	
    private void Start()
    {
        Hazards = GameObject.FindGameObjectsWithTag("Hazards");
        Obstacle = GameObject.FindGameObjectsWithTag("Obstacles");
        Player = GameObject.FindGameObjectWithTag("Player");
        teleparams = GameObject.FindGameObjectWithTag("Controller").GetComponent<PlayerTeleControl>();
        Emitter = GameObject.Find("KunaiEmitter");
        Vector.x = Input.mousePosition.x - Player.transform.position.x;
        Vector.y = Input.mousePosition.y - Player.transform.position.y;
        Vector.z = 0;
        Vector.Normalize();

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
    // Update is called once per frame
    void Update () {
        if (HasCollided == false)
        {
            
                transform.position += Vector * speed * Time.deltaTime;
            
        }
        
    }
}
