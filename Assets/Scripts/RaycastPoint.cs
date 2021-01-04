using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPoint : MonoBehaviour
{

    public Transform FirePoint;
    public float MaxDistance;
    public LayerMask Layer;

    public bool CanPickUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(FirePoint.position, FirePoint.forward, out hitInfo, MaxDistance, Layer);

        if (hit)
        {
            Debug.DrawLine(FirePoint.position, hitInfo.point, Color.red);
            CanPickUp = true;
        }
        else
        {
            CanPickUp = false;
        }
    
    }
}
