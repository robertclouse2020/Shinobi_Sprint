using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleControl : MonoBehaviour {

    public GameObject Player;
    public GameObject TeleObject;
    public KunaiMove kunaiMove;
    public GameObject kunai;
    private GameObject NewKunai;    // new clone kunai obj
    public GameObject ShotEmitter;
    public float TeleSpeed;
     Transform offset;
   private Transform newKunaiPosition;
    public bool activeKunai;                // used to tell if the kunai is moving or not
    public bool CanTeleport;
    Vector3 Vector;

	// Use this for initialization
	void Start ()
    {
        activeKunai = false;  // initialize the kunai state to not moving
        CanTeleport = false;
    }

    // Update is called once per frame
    void Update () {
        kunai.transform.position = ShotEmitter.transform.position;
        if (Input.GetButtonDown("Fire1") && !activeKunai)       // check if the left mouse button is clicked and active kunai isnt set to moving
        {
            Vector.x = Input.mousePosition.x - Player.transform.position.x;
            Vector.y = Input.mousePosition.y - Player.transform.position.y;
            Vector.Normalize();

            NewKunai = Instantiate(kunai, offset);  // sets the new clone obj to the new clone
            NewKunai.transform.position = Vector * kunaiMove.speed;     // sets the new clone to the shot emitter on the player

            activeKunai = true;         // set the kunai state to moving
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !activeKunai)  // check if the right mouse button is clicked and active kunai isnt set to moving
        {
            CanTeleport = true;
        }

        if (CanTeleport)  // check if the player isn't in contact with the kunai already
        {
            
            Player.transform.position = Vector3.Lerp(Player.transform.position, NewKunai.transform.position, TeleSpeed / 13); // move the player to the kunai
        }
       


    }

    
}
