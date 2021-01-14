using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjects : MonoBehaviour
{

    public Transform grabDetector;
    public Transform objectHolder;

    public float distance;
    
    void Update()
    {
        RaycastHit2D grabChecker = Physics2D.Raycast(grabDetector.position, Vector2.right * transform.localScale.x, distance);

        if (grabChecker.collider != null && grabChecker.collider.tag == "Pickable")
        {
            if (Input.GetKeyDown(KeyCode.E)) //Grab Object
            {
                grabChecker.collider.gameObject.transform.parent = objectHolder;
                grabChecker.collider.gameObject.transform.position = objectHolder.position;
                grabChecker.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else if(Input.GetKeyUp(KeyCode.E)) //Release object
            {
                grabChecker.collider.gameObject.transform.parent = null;
                grabChecker.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
}
