using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScripts : MonoBehaviour
{
    [SerializeField] Color cubeColor;
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", cubeColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
