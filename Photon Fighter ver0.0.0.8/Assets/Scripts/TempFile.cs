using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFile : MonoBehaviour
{



    public float moveSpeed = 1.0f;
    public float delay = 10.0f;
    public float moveTime = 0.0f;
    public float up = 0;
    public float forward = 0;
    public float right = 0;
    public bool repeat = false;
    public float repeatThreshold = 0.0f;

    private float currentMoveTime = 0.0f;
    private float nup = 0.0f;
    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
    }




    // Update is called once per frame
    void Update()
    {
        Vector3 positionDelta = transform.position - startPosition;

        if (delay >= 0)
        {
            delay -= Time.deltaTime;
            return;
        }
        if (currentMoveTime >= moveTime)
        {
            if (repeat == true)
            {
                Translate(-up, -forward, -right);
                if (positionDelta.magnitude <= repeatThreshold)
                {
                    transform.position = startPosition;
                    currentMoveTime = 0.0f;
                }
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            Translate(up, forward, right);
            currentMoveTime += Time.deltaTime;
        }


    }

    void Translate(float a, float b, float c)
    {
        Vector3 directionY = a * transform.up;
        transform.Translate(directionY.normalized * moveSpeed, Space.World);
        Vector3 directionX = b * transform.forward;
        transform.Translate(directionX.normalized * moveSpeed, Space.World);
        Vector3 directionZ = c * transform.right;
        transform.Translate(directionZ.normalized * moveSpeed, Space.World);
    }
}
