using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DottedLinesToCursor : MonoBehaviour {
    public GameObject player;
    Vector3 mousePos;
    public float multiple = 12;
    public float zPos = 11;
    LineRenderer lineRenderer;
    RaycastHit info;
    bool isActive = false;
    // Use this for initialization
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));

        lineRenderer.startWidth = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || isActive == true)
        {
            isActive = true;
            mousePos = Input.mousePosition;

            Vector3 dir = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zPos)) - player.transform.position;
            //dir.Normalize();        
            dir.z = player.transform.position.z;

            Vector3 Destination = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zPos)) + (dir * multiple);
            Destination.z = player.transform.position.z;


            if (Physics.Raycast(player.transform.position, dir, out info))
            {
                //   Destination.z = player.transform.position.z;

                lineRenderer.SetPosition(0, player.transform.position);
                lineRenderer.SetPosition(1, info.point);

            }
            else
            {

                lineRenderer.SetPosition(0, player.transform.position);
                lineRenderer.SetPosition(1, Destination);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            isActive = false;
        }
    }
}
