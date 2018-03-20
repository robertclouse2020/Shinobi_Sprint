using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour {
    public int lives = 3;
    public int health = 15; // player health. default is set to 15
    public bool isDead = false;     // used to tell if the player has died
    private Vector3 Startposition;  // used to respawn the player
    public int currentCheckpoint = 0;
    public GameObject[] checkpoint;
    private GameObject[] Hazards;  // array for hazards
    private Damageplayer Damage;   // stores the current hazards damage
    
	// Use this for initialization
	void Start () {
        Hazards = GameObject.FindGameObjectsWithTag("Hazards");  // get all the hazards in the map
        Startposition.x = transform.position.x;
        Startposition.y = transform.position.y;         // get original start position
        Startposition.z = transform.position.z;
        checkpoint = GameObject.FindGameObjectsWithTag("Respawn");
    }
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < checkpoint.Length; i++)
        {
            if (collision.gameObject == checkpoint[i].gameObject)  // used to determine which checkpoint the player is at
            {                                                        // currently doesnt work at all
                Startposition = checkpoint[i].transform.position;
                
                checkpoint[i].active = false;
            }
        }

        for (int i = 0; i < Hazards.Length; i++)        // traverse the Hazards array
        {
            if (collision.gameObject == Hazards[i].gameObject) // check if the player has collided with one of the hazards
            {
                
                    Damage = Hazards[i].GetComponent<Damageplayer>();  // get the current hazards damage 

                    if (Damage.Damage >= health) // check if the hazard has one shot the player else just subtract the damage from health
                    {
                    lives--;
                        isDead = true;
                    } 
                    else
                    {
                        health = health - Damage.Damage;    // subtract health                    

                    }
                
            }
        }
    }
    // Update is called once per frame
    void Update () {


		if (isDead == true)
        {
            isDead = false;
            
            transform.position = Startposition;  // if the player dies set them back at the beginning
        }
        
    }
}
