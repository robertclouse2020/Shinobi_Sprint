using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleControl : MonoBehaviour {

    public GameObject Player;
    public GameObject TeleObject;    
    public KunaiMove KuniPrefab;
    private GameObject NewKunai;    // new clone kunai obj
    public GameObject ShotEmitter;
    public float TeleSpeed;
     Transform offset;
   private Transform newKunaiPosition;
    public bool activeKunai;                // used to tell if the kunai is moving or not
    public bool CanTeleport;
    Vector3 directionVector;

    float angle;
	// Use this for initialization
	void Start ()
    {
        activeKunai = false;  // initialize the kunai state to not moving
        CanTeleport = false;
    }

    // Update is called once per frame
    void Update () {
        KuniPrefab.transform.position = ShotEmitter.transform.position;
        if (Input.GetButtonDown("Fire1") && !activeKunai)       // check if the left mouse button is clicked and active kunai isnt set to moving
        {
             Debug.Log(Camera.main.WorldToScreenPoint(Input.mousePosition));
             Debug.Log(Player.transform.position);
             directionVector.x = Input.mousePosition.x - Camera.main.WorldToScreenPoint(Player.transform.position).x;               // gives weird normalization 
            directionVector.y = Input.mousePosition.y - Camera.main.WorldToScreenPoint(Player.transform.position).y;

            Debug.Log(directionVector);
            directionVector.Normalize();
            //directionVector.y = directionVector.y * 3;
             

            //angle = Vector3.Angle(Player.transform.position, Input.mousePosition);

            //angle = angle * Mathf.PI / 180;                                                   // doesnt work at all

            //directionVector.x = KuniPrefab.speed * Mathf.Cos(angle);
            //directionVector.y = KuniPrefab.speed * Mathf.Sin(angle);
            //directionVector.Normalize();

            Debug.Log(directionVector);
            NewKunai = Instantiate(KuniPrefab.gameObject, offset);  // sets the new clone obj to the new clone
            KunaiMove kunaiMove = NewKunai.GetComponent<KunaiMove>();
            NewKunai.transform.position = ShotEmitter.transform.position;     // sets the new clone to the shot emitter on the player
            kunaiMove.setDirection(directionVector);

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
