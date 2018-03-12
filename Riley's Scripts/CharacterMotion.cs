using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class CharacterMotion : MonoBehaviour {

    //setup
    public bool sidescroller;                   //if true, won't apply vertical input
    public Transform mainCam, floorChecks;      //main camera, and floorChecks object. FloorChecks are raycasted down from to check the player is grounded.
    public Animator animator;                   //object with animation controller on, which you want to animate
    public AudioClip jumpSound;                 //play when jumping
    public AudioClip landSound;                 //play when landing on ground

    //movement
    public float accel = 70f;                   //acceleration/deceleration in air or on the ground
    public float airAccel = 18f;
    public float decel = 7.6f;
    public float airDecel = 1.1f;
    [Range(0f, 5f)]
    public float rotateSpeed = 0.7f, airRotateSpeed = 0.4f; //how fast to rotate on the ground, how fast to rotate in the air
    public float maxSpeed = 9;                              //maximum speed of movement in X/Z axis
    public float slopeLimit = 40, slideAmount = 35;         //maximum angle of slopes you can walk on, how fast to slide down slopes you can't
    public float movingPlatformFriction = 7.7f;             //you'll need to tweak this to get the player to stay on moving platforms properly

    //jumping
    public Vector3 jumpForce = new Vector3(0, 13, 0);       //normal jump force
    public Vector3 secondJumpForce = new Vector3(0, 13, 0); //the force of a 2nd consecutive jump
    public Vector3 thirdJumpForce = new Vector3(0, 13, 0);  //the force of a 3rd consecutive jump
    public float jumpDelay = 0.1f;                          //how fast you need to jump after hitting the ground, to do the next type of jump
    public float jumpLeniancy = 0.17f;						//how early before hitting the ground you can press jump, and still have it work

    private int onJump;
    private bool grounded;
    private Transform[] floorCheckers;
    private Quaternion screenMovementSpace;
    private float airPressTime, groundedCount, curAccel, curDecel, curRotateSpeed, slope;
    private Vector3 direction, moveDirection, screenMovementForward, screenMovementRight, movingObjSpeed;
    CharacterMotor playerMotor;
	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionStay(Collision other)
    {
        //only stop movement on slight slopes if we aren't being touched by anything else
        if (other.collider.tag != "Untagged" || grounded == false)
            return;
        //if no movement should be happening, stop player moving in Z/X axis
        //if (direction.magnitude == 0 && slope < slopeLimit && rigid.velocity.magnitude < 2)
        {
            //it's usually not a good idea to alter a rigidbodies velocity every frame
            //but this is the cleanest way i could think of, and we have a lot of checks beforehand, so it should be ok
       //     rigid.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
