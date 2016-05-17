using UnityEngine;
using System.Collections;

public class FollowClocheMaster : MonoBehaviour {

    public Transform target;
    Vector3 offset;

    public float smoothTime = 0.5f;
    Vector3 vel;
    Vector3 currentpos;

    // Use this for initialization
    void Start()
    {
        currentpos = transform.position;

        if (target != null)
        {
            offset = (transform.position - target.position);
        }
        else
        {
            Debug.LogWarning("Please define target for" + this);
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.z != currentpos.z)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y, currentpos.z);
        }

        if (target != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, (offset + target.position), ref vel, smoothTime);
        }

    }
}
