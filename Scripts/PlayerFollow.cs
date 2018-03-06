using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public Transform Player;
    public Transform Camera;
    private Vector3 NewPosition;
	// Use this for initialization
	void Start () {
        NewPosition.x = Player.position.x;
        NewPosition.y = Player.position.y;      // initalize the camera position to the players position
        NewPosition.z = Camera.position.z;      // lock the camera on its current z

	}
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();                   // call the update position function
        Camera.position = NewPosition;      // set the camera top the new player position
	}

    void UpdatePosition()
    {
        NewPosition.x = Player.position.x;
        NewPosition.y = Player.position.y;      // initalize the camera position to the players position
        NewPosition.z = Camera.position.z;      // lock the camera on its current z
    }
}
