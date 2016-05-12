using UnityEngine;
using System.Collections;

public class FollowClocheMaster : MonoBehaviour {

    public Transform target;
    Vector3 offset;

    public float smoothTime = 0.5f;
    Vector3 vel;

    // Use this for initialization
    void Start()
    {

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

        if (target != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, (offset + target.position), ref vel, smoothTime);
        }

    }
}
