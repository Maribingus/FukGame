using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, player.position + offset, smoothing);
            transform.position = newPosition;
        }
    }
}