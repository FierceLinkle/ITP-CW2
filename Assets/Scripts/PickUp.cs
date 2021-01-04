using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Transform PickupDest;

    public BoxCollider Crate;

    public RaycastPoint raycastPoint;

    public Text CratesText;
    public static int CratesDelivered = 0;

    public static bool hasCrate = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CratesText.text = "Crates Delivered: " + CratesDelivered;

        if (Input.GetKeyDown("x"))
        {
            this.transform.parent = null;

            GetComponent<Rigidbody>().useGravity = true;

            Crate.isTrigger = false;

            hasCrate = false;
        }
    }

    void OnMouseUp()
    {
        if (hasCrate == true) //Add message displaying crate already picked up
            return;


        if (raycastPoint.CanPickUp == true)
        {  
                GetComponent<Rigidbody>().useGravity = false;

                this.transform.position = PickupDest.position;

                this.transform.parent = GameObject.Find("PickupDestination").transform;

                Crate.isTrigger = true;

                hasCrate = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Table")
        {
            addDelivery();
        }
    }

    void addDelivery()
    {
        CratesDelivered++;
    }
}
