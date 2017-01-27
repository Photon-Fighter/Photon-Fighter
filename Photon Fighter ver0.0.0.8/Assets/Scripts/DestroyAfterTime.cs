using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
    public float DesiredTime = 0.0f;
    private float CurrentTime = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CurrentTime += Time.deltaTime;
        if (DesiredTime > 0 && CurrentTime >= DesiredTime)
        {
            Destroy(gameObject);
        }
    }
}
