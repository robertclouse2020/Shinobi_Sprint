using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DottedLinesToCursor : MonoBehaviour
{
    public GameObject player;
    Vector3 mousePos;
    public float multiple = 12.0f;
    public float zPos = 11;
    LineRenderer lineRenderer;
    RaycastHit info;
    bool isActive = false;
    public bool MouseActive;
    public Transform lookDir;
    Vector3 inputDir=new Vector3(1.0f,0,0);
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
        inputDir.x = Input.GetAxisRaw("HorizontalAim");
        inputDir.y = Input.GetAxisRaw("VerticalAim");

        //if (inputDir.x > -0.1 && inputDir.x < 0.1 || inputDir.y > -0.1 && inputDir.y < 0.1)
        //{
        //    inputDir.x = 0;
        //    inputDir.y = 0;
        //}
        if (MouseActive == true)
        {
            if (Input.GetMouseButtonDown(0) || isActive == true)
            {
                lineRenderer.enabled = true;
                isActive = true;
                mousePos = Input.mousePosition;

                Vector3 dir = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zPos)) - player.transform.position;
                //dir.Normalize();        
                dir.z = player.transform.position.z;

                Vector3 Destination = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zPos)) + (dir * multiple);
                Destination.z = player.transform.position.z;

                Debug.Log(mousePos);
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
            if (Input.GetMouseButtonUp(0))
            {
                isActive = false;
                lineRenderer.enabled = false;
            }
        }
        else
        {


            //double 
            //if (inputDir.x < 0)
            //{
            //    lookDir.position * inputDir.x - 400;
            //}
            //else
            //{
            //    lookDir.x = inputDir.x + 400;
            //}

            //if (inputDir.y < 0)
            //{
            //    lookDir.y = inputDir.y - 400;
            //}
            //else
            //{
            //    lookDir.y = inputDir.y + 400;
            //}

            //if (inputDir.x != 0 || inputDir.y != 0)
            //{
            //    lineRenderer.enabled = true;
            //    isActive = true;
            //    mousePos = Input.mousePosition;

            //Vector3 dir = Vector3.zero;
            //dir.y = Mathf.Atan2(inputDir.y, inputDir.x) * Mathf.Rad2Deg;


            Vector3 dir = inputDir;
            //dir.Normalize();        
            //dir.z = player.transform.position.z;
            Vector3 temp = inputDir;
            temp.x *= multiple;
            temp.y *= multiple;
            temp.z *= multiple;
            Vector3 Destination = player.transform.position + temp;


            if (Physics.Raycast(player.transform.position, temp, out info))
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
    }
}

