using UnityEngine;
using System.Collections;

public class PathCloche : MonoBehaviour {



    public GameObject centre;
    public GameObject Visual;
    bool canTeleport = true;
    public float distanceRaycast = 1.5f;
    public float refreshRateInSeconds;

    Vector3 newDirection;
    Vector3 shortVector;
    Vector3 vectorCentre;
    Ray directionRay;
    RaycastHit hitInfo;

    Ray rayToCentre;

    void Start()
    {
        newDirection = new Vector3(Random.Range(-10,10), Random.Range(-10, 10));
        centre = ManagerSpawn.instance.m_CurrentLevel.GetComponent<ArenaSpawner>().m_CenterLevel;
        Scan();
    }


    void Update()
    {
        //Debug.DrawRay(transform.position, newDirection, Color.red, 5, false);
    }

    void Scan() 
    {
        newDirection = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10));
        directionRay = new Ray(transform.position, newDirection);

        if (Physics.Raycast(directionRay, out hitInfo, distanceRaycast))
        {
            if (hitInfo.collider.tag == "Floor")
            {
                WallCollide();
            }
        }
        else if (!Physics.Raycast(directionRay, out hitInfo, distanceRaycast))
        {
            StartCoroutine(CalculateRaycast());
        }
    }

    void WallCollide()
    {
        vectorCentre = transform.position - centre.transform.position;
        vectorCentre = Vector3.ClampMagnitude(vectorCentre, distanceRaycast * 50);
        transform.Translate(-vectorCentre - Vector3.ClampMagnitude(newDirection, distanceRaycast));
        canTeleport = false;
        Scan();

    }

    IEnumerator CalculateRaycast()
    {
        yield return new WaitForSeconds(refreshRateInSeconds);
        directionRay = new Ray(transform.position, newDirection);

        if (Physics.Raycast(directionRay, out hitInfo, distanceRaycast))
        {
            if (hitInfo.collider.tag == "Floor" || hitInfo.collider.tag == "DeathZone")
            {
                WallCollide();
                yield return null;
            }
        }
        else 
        {
            MoveToPosition();
            yield return null;
        }
    }

    void MoveToPosition()
    {
        shortVector = Vector2.ClampMagnitude(newDirection, distanceRaycast);
        transform.Translate(shortVector);
        StartCoroutine(CalculateRaycast());
    }

    public void StartRespawn()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn ()
    {
        for (int i = 0; i < 4; i++)
        {
            Visual.transform.GetChild(i).gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(3);
        transform.position = centre.transform.position;
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 4; i++)
        {
            Visual.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}


