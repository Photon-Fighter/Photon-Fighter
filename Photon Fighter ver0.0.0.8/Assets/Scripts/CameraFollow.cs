using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	private float step;

	public Camera myCamera;
	public GameObject player;
    private Vector3 cameraOffset;

    public float xOffset = 10;
    public float yOffset = 10;
    public float zOffset = 10;



	// Use this for initialization
	void Start () {
        //myCamera = Camera.main;
        //step = (myCamera.transform.position - transform.position).magnitude;

        //oldPos = transform.position;
        cameraOffset = new Vector3(xOffset, yOffset, zOffset);

	}
	
	// Update is called once per frame
	void Update () {
        /*Vector3 newPos = transform.position - oldPos;
		Vector3 startPos = myCamera.transform.position;

		oldPos = transform.position;

		myCamera.transform.position = Vector3.Lerp(startPos, startPos + newPos, step);*/
        if (player != null)
        {
            transform.position = player.transform.position + cameraOffset;
            transform.LookAt(player.transform);
        }
        
	}
}
