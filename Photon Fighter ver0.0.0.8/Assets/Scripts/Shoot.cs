using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        


		if (target != null) {
            target.transform.position = transform.forward;

        }




	}

    Vector3 destinationVector;

    public GameObject target;
}
