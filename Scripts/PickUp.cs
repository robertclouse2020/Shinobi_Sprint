using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public GameObject[] Pickups;
    public int NumItemsPickedUp;
    public Playerhealth playerHealth;
	// Use this for initialization
	void Start () {
        
        Pickups = GameObject.FindGameObjectsWithTag("PickUp");  // looks for any object in the scene with the pickup tag
	}
    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < Pickups.Length; i++)        // traverse the pickup[ object array
        {
            if (collision.gameObject == Pickups[i].gameObject)      // check which pickup the player has collided with
            {
                
                Pickups[i].SetActive(false);  // hide the pick up
                NumItemsPickedUp++;                     // increase the total picked up pickups 
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
