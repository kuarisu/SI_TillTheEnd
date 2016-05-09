using UnityEngine;
using System.Collections;

public class Player_Push : MonoBehaviour {

    public GameObject Physic;


	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("A_0"))
        {
            StartCoroutine(Push());
        }
    }


    //Enable a Trigger to active movement script of the cubes
    IEnumerator Push()
    {
        
        Physic.GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        Physic.GetComponent<SphereCollider>().enabled = false;
        yield return null;
    }

}
