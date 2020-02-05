using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Material highlight;
    public Material selected;
    private Material originalMat;
    public GameObject wand;
    private bool isclicked;
   // private bool isreleased;

    // Start is called before the first frame update
    void Start()
    {
        originalMat = GetComponent<Renderer>().material;
        isclicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isclicked = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isclicked = false;
            transform.parent = null;
        }
        print(isclicked);
    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wand"))
        {
            GetComponent<Renderer>().material = highlight;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wand"))
        {
            GetComponent<Renderer>().material = originalMat;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("wand"))
        {
            if (isclicked)
            {
                GetComponent<Renderer>().material = selected;
                transform.parent = wand.transform;
            }
        }
    }
}
