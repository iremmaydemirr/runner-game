using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject Ball;
    //public GameObject Target;
    private GameObject[] Gate;

    public float GatePosition;
    private bool vuruldu=false;
    private Vector3 endPos;
    private static int counter= 0;
    void Start()
    {
        Gate = GameObject.FindGameObjectsWithTag("Gate");

        
    }

    void Update()
    {
        if(vuruldu == true)
        {
            
            Debug.Log("counter" + counter);
            endPos = Gate[counter].transform.position +Vector3.down *7;
            
            Gate[counter].transform.position = Vector3.Lerp(Gate[counter].transform.position, endPos, Time.time * 0.5f);
            counter++;
            vuruldu = false;
           Debug.Log("vuruldu" + vuruldu);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Target")
        {
            Debug.Log("vurdu");
            //Gate.transform.position = new Vector3(Gate.transform.position.x, -5.0f, Gate.transform.position.z);
            
            vuruldu = true;
           
        }
    }

    
}
