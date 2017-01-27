using UnityEngine;
using System.Collections;

public class move_forward : MonoBehaviour {

    public float movementSpeed = 5.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }
}
