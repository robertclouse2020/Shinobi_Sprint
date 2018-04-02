using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleControl : MonoBehaviour
{

    public GameObject Player;
    public GameObject TeleObject;
    public KunaiMove KuniPrefab;
    private GameObject[] NewKunai;    // new clone kunai obj
    public GameObject ShotEmitter;
    public float TeleSpeed;
    Transform offset;
    private Transform newKunaiPosition;
    public bool activeKunai;                // used to tell if the kunai is moving or not
    public bool CanTeleport;
    Vector3 directionVector;

    private Vector3 mouse_pos;
    private Vector3 object_pos;
    float angle;


    // Use this for initialization
    void Start()
    {
        activeKunai = false;  // initialize the kunai state to not moving
        CanTeleport = false;
        NewKunai = new GameObject[2];

        mouse_pos.z = -181;



    }

    // Update is called once per frame
    void Update()
    {



        KuniPrefab.transform.position = ShotEmitter.transform.position;
        if (Input.GetMouseButtonUp(0))       // check if the left mouse button is clicked and active kunai isnt set to moving
        {

            directionVector.x = Input.mousePosition.x - Camera.main.WorldToScreenPoint(Player.transform.position).x;               // gives weird normalization 
            directionVector.y = Input.mousePosition.y - Camera.main.WorldToScreenPoint(Player.transform.position).y;
            directionVector.z = Player.transform.position.z;

            directionVector.Normalize();

            mouse_pos.x = Input.mousePosition.x - Camera.main.WorldToScreenPoint(Player.transform.position).x;
            mouse_pos.y = Input.mousePosition.y - Camera.main.WorldToScreenPoint(Player.transform.position).y;

            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            angle -= 90;

            for (int i = 0; i < 1; i++)
            {
                if (NewKunai[0] != null)
                {
                    GameObject.Destroy(NewKunai[0]);
                }
               
                    NewKunai[i] = Instantiate(KuniPrefab.gameObject, offset);  // sets the new clone obj to the new clone
                    KunaiMove kunaiMove = NewKunai[i].GetComponent<KunaiMove>();
                    NewKunai[i].transform.position = ShotEmitter.transform.position;     // sets the new clone to the shot emitter on the player
                    kunaiMove.setDirection(directionVector);
                    kunaiMove.setRotation(angle);
                    kunaiMove.HasCollided = false;
                

            }



            activeKunai = true;         // set the kunai state to moving

        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !activeKunai)  // check if the right mouse button is clicked and active kunai isnt set to moving
        {
            CanTeleport = true;

        }

        if (CanTeleport == true && !activeKunai)  // check if the player isn't in contact with the kunai already
        {

            Player.transform.position = Vector3.Lerp(Player.transform.position, NewKunai[0].transform.position, TeleSpeed / 13); // move the player to the kunai

        }





    }


}
