using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    public Rigidbody ballPrefabs;
    public GameObject cursor;
    public Transform shootPoint;
    public LayerMask layer;

    private Camera camera;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Throw();
    }

    void Throw()
    {
        Ray camRay = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point +Vector3.up *1.0f;

            Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, 1f); // vector of velocity
            //transform.rotation = Quaternion.LookRotation(Vo); 

            if(Input.GetMouseButtonDown(0))
            {
                Rigidbody obj = Instantiate(ballPrefabs, shootPoint.position, Quaternion.identity);
                obj.velocity = Vo;
            }
        }
        else
        {
            cursor.SetActive(false);
        }
    }
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        // distance x and y
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        // create a float the represent distance
        float disY = distance.y;
        float disXZ = distanceXZ.magnitude;

        float Vxz =disXZ /time; //velocity x
        float Vy = disY / time + 1f * Mathf.Abs(Physics.gravity.y) * time;// velocity y

        Vector3 result= distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;

    }
}
