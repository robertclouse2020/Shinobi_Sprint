using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour {

    private float initialStartTime = 0.00f;
    public GameObject Player;
    private GameObject Kunai;
    public float Speed;


    private bool IsActiveTeleport = false;

    public Transform startMarker;
    public Transform endMarker;
    private float startTime;
    private float journeyLength;
    float distCovered;
    float fracJourney;
    private void Start()
    {

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position); // gets the distance between the player and the kunai
    }

  
    void Update()
    {



        if (IsActiveTeleport == false)  // checks if the player isnt teleporting
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))       // waits till the right mouse button is pressed
            {
                Kunai = GameObject.FindWithTag("Kunai");
                //Kunai.SetActive(true);
                IsActiveTeleport = true;// sets the state of IsTeleporting true
            }
        }

        


    }

    private void LateUpdate()
    {
        if (IsActiveTeleport == true)   // starts the teleporting if the player is teleporting
        {

            distCovered = (initialStartTime++) / Speed; // movement speed
            fracJourney = distCovered / journeyLength;  //

            if (Player.transform.position != endMarker.transform.position)  // checks if the player is still moving/teleporting
            {
                IsActiveTeleport = true;
                //Player.SetActive(false);
                Player.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
                //startMarker.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
            }
            else if (Player.transform.position == endMarker.transform.position) // checks if the player is finished teleporting
            {
                initialStartTime = 0;
                IsActiveTeleport = false;
                //Player.SetActive(true);

            }

        }
    }

}
