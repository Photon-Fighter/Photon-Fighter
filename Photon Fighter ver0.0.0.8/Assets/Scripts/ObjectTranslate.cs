using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTranslate : MonoBehaviour
{



    public float moveSpeed = 1.0f;
    public float delay = 10.0f;
    public float moveTime = 0.0f;
    public float magnitude = 0.0f;
    public float up = 0;
    public float forward = 0;
    public float right = 0;
    public bool repeat = false;
    public float repeatThreshold = 0.0f;

    private float currentMoveTime = 0.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private int direction = 1;
    private int condition = 1;


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
        if (positionDelta.magnitude >= magnitude)
        {
            currentMoveTime = 0.0f;
            if (repeat == true)
            {
                direction = -direction;
            }
            else
            {
                direction = 0;
            }

        }
        Translate(direction);
        currentMoveTime += Time.deltaTime;

        if (positionDelta.magnitude <= repeatThreshold && direction == -1)
        {
            transform.position = startPosition;
            if (repeat == true)
            {
                direction = -direction;
            }
            else
            {
                direction = 0;
            }

        }

    }

    void Translate(int direction)
    {
        Vector3 directionY = direction * up * transform.up;
        transform.Translate(directionY.normalized * moveSpeed, Space.World);
        Vector3 directionX = direction * forward * transform.forward;
        transform.Translate(directionX.normalized * moveSpeed, Space.World);
        Vector3 directionZ = direction * right * transform.right;
        transform.Translate(directionZ.normalized * moveSpeed, Space.World);
    }
}
