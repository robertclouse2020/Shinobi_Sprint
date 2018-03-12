using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiThrow : MonoBehaviour {

    public GameObject Kunai;
    public GameObject Player;
    public float Speed;
    private Vector3 Newposition;
    private float Rotation;
    public bool isActive;  // do not touch
    private Vector2 OriginalkunaiPosition;
    private Vector3 Vector;
    public bool isThrown = false;
	// Use this for initialization
	void Start () {
        Newposition.x = Kunai.transform.position.x;
        Newposition.y = Kunai.transform.position.y;
        Vector.x = 75;
        Vector.y = 0;
        OriginalkunaiPosition = Player.transform.position + Vector;
        //Newposition.y = 5;

        
            
	}
	
	// Update is called once per frame
	void Update () {
         
          
        
            

        if (isThrown == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || isActive == true)
            {
                isActive = true;

            Vector.y = Input.mousePosition.y - Player.transform.position.y;
            Vector.x = Input.mousePosition.x - Player.transform.position.x;
                Vector.Normalize();
                Newposition = Newposition + Vector * Speed * Time.deltaTime;
                Kunai.transform.position = Newposition;
            }
        }
        else
        {
                
        }
    }
  
}
