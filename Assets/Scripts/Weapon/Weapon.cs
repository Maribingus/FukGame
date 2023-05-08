using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform parentTransform;
    private Vector2 mousePosition;
    private float aimAngle;
    private Vector2 aimDirection;
    private Vector2 collisionPoint;
    public float distance;
    public float squish;
    //public float offset;
    private Vector3 yVector;
    //private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        parentTransform = gameObject.transform.parent.GetComponent<Transform>();
        //gameObject.layer = 6;
    }

    void Update()
    {
        mousePosition = gameObject.transform.parent.GetComponent<PlayerController>().mousePosition;
        aimAngle = gameObject.transform.parent.GetComponent<PlayerController>().aimAngle;
        aimDirection = (transform.position - (Vector3)mousePosition).normalized;
        //Raycast();
    }

    void FixedUpdate()
    {
        Quaternion quatAngle = Quaternion.Euler(0f, 0f, aimAngle);
        transform.rotation = quatAngle;
        yVector = new Vector3(0, aimDirection.y, 0);
        transform.position = (parentTransform.position - distance * ((Vector3)aimDirection - squish * yVector));// - offset * yVector.normalized;
        //print(collisionPoint);
    }

    void Raycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(parentTransform.position, mousePosition, 2000f, ~0);
        if (hit.collider)// != null && hit.collider.tag == "weapon")
        {
            collisionPoint = hit.point;
            print(hit.collider);
        }
    }
}
