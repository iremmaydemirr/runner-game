using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform perspective; //Camera
    private Vector3 startOffset; 
    private Vector3 moveVector; //distance between player and camera
    private float transition =0.0f;
    private float animationDuration  =2.0f;

    private Vector3 animationOffset = new Vector3(0, 5, 5); //Animation start values
    void Start()
    {
        perspective=GameObject.FindGameObjectWithTag("Player").transform; // get player transform
        startOffset = transform.position - perspective.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = perspective.position + startOffset;
        transform.position = moveVector;

        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y,3,5);

        if(transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector,transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(perspective.position + Vector3.up);
        }
        
    }
}
