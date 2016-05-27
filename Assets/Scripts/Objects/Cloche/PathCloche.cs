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

    //variables pour stocker les coordonnées aléatoires des vecteurs
    float newX;
    float newY;

    // Use this for initialization
    void Start()
    {
        newDirection = new Vector3(Random.Range(-500, 400), Random.Range(-500, 400));
        centre = ManagerSpawn.instance.m_CurrentLevel.GetComponent<ArenaSpawner>().m_CenterLevel;
        Scan();
    }

    void Scan() //doit se déclencher quand le chemin est obstrué, pour pouvoir dévier de manière plus marqué
    {
        newDirection = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50));

        if (!canTeleport)
        {
            newDirection = -newDirection + new Vector3(Random.Range(-50, 50), Random.Range(-50, 50));
            canTeleport = true;
        }

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

    void WallCollide() //va se déclencher quand le raycast va rencontrer un mur
    {
        vectorCentre = transform.position - centre.transform.position;
        vectorCentre = Vector3.ClampMagnitude(vectorCentre, distanceRaycast * 50);
        //rayToCentre = new Ray(transform.position, vectorCentre);
        transform.Translate(-vectorCentre - Vector3.ClampMagnitude(newDirection, distanceRaycast));
        //newX = -newX * 2;
        //newY = -newY * 2;
        canTeleport = false;
        newDirection = newDirection + new Vector3(Random.Range(Random.Range(-500, -400), Random.Range(500, 400)), Random.Range(Random.Range(-500, -400), Random.Range(500, 400)));
        StartCoroutine(CalculateRaycast());

    }

    IEnumerator CalculateRaycast()
    {
        yield return new WaitForSeconds(refreshRateInSeconds);

        //if (canTeleport)
        //{
        //    //StartCoroutine(GenerateCoordinates());
        //    newX = Random.Range(newX - 10, newX + 10);
        //    newY = Random.Range(newY - 10, newY + 10);

        //}

       // canTeleport = true;
        //le nouveau vecteur est calculé aléatoirement mais avec une certaine contrainte par rapport à l'ancien vecteur (pour garder un mouvement cohérent)
        newDirection = newDirection + new Vector3(Random.Range(Random.Range(-200, -150), Random.Range(200, 150)), Random.Range(Random.Range(-200, -150), Random.Range(200, 150)));
        directionRay = new Ray(transform.position, newDirection);//le ray directionnel prend les valeurs aléatoires déterminées auparavant



        if (Physics.Raycast(directionRay, out hitInfo, distanceRaycast)) //le if se déclenche que s'il y a un objet devant
        {
            if (hitInfo.collider.tag == "Floor" || hitInfo.collider.tag == "DeathZone" || hitInfo.collider.tag == "BlockMove" || hitInfo.collider.tag == "BlockStill")
            {
                WallCollide();
                yield return null;
            }
        }
        else //se déclenche s'il n'y a rien
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
        //Visual.transform.GetChild(0).gameObject.SetActive(false); // Ca coupe le script aussi
        //Visual.transform.GetChild(1).gameObject.SetActive(false);
        //Visual.transform.GetChild(2).gameObject.SetActive(false);
        //Visual.transform.GetChild(3).gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        transform.position = centre.transform.position;
        newDirection = newDirection +  new Vector3(Random.Range(-100, 100), Random.Range(-100, 100));
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 4; i++)
        {
            Visual.transform.GetChild(i).gameObject.SetActive(true);
        }
        //Visual.transform.GetChild(0).gameObject.SetActive(true);
        //Visual.transform.GetChild(1).gameObject.SetActive(true);
        //Visual.transform.GetChild(2).gameObject.SetActive(true);
        //Visual.transform.GetChild(3).gameObject.SetActive(true);
    }
}

