using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        LookToMouse();
	}

    public void LookToMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = (Camera.main.transform.position - transform.position).magnitude;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        mouseWorldPos.y = 40f; // player's height location

        transform.LookAt(mouseWorldPos);
    }
}
