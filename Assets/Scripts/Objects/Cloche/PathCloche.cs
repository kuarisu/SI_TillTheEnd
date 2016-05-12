using UnityEngine;
using System.Collections;

public class PathCloche : MonoBehaviour {



    public GameObject cloche;
    public GameObject centre;

    bool canTeleport = true;

    public float spawningTime;
    public float distanceRaycast;
    public float refreshRateInSeconds;


    Vector3 direction;
    Vector3 newDirection;
    Vector3 shortVector;
    Vector3 vectorCentre;
    Ray directionRay;
    RaycastHit hitInfo;

    Ray rayToCentre;

    //variables pour stocker les coordonnées aléatoires des vecteurs
    float x;
    float y;
    float newX;
    float newY;
    float centerX;
    float centerY;

    // Use this for initialization
    void Start()
    {
        cloche.transform.localScale = new Vector3(0, 0, 0);
        newDirection = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1));
        StartCoroutine(WaitForSpawning());

        centerX = centre.transform.position.x; //coordonnées du centre géographique du niveau (z=0)
        centerY = centre.transform.position.y;


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CalculateRaycast()
    {
        yield return new WaitForSeconds(refreshRateInSeconds);

        if (canTeleport)
        {
            //StartCoroutine(GenerateCoordinates());
            newX = Random.Range(newX - 1, newX + 1);
            newY = Random.Range(newY - 1, newY + 1);

        }

        canTeleport = true;
        //le nouveau vecteur est calculé aléatoirement mais avec une certaine contrainte par rapport à l'ancien vecteur (pour garder un mouvement cohérent)
        newDirection = new Vector3(newX * 1.5f, newY * 1.5f);
        directionRay = new Ray(transform.position, newDirection);//le ray directionnel prend les valeurs aléatoires déterminées auparavant

        Debug.DrawRay(transform.position, newDirection);

        if (Physics.Raycast(directionRay, out hitInfo, distanceRaycast)) //le if se déclenche que s'il y a un objet devant
        {
            if (hitInfo.collider.tag == "Floor" || hitInfo.collider.tag == "DeathZone"  || hitInfo.collider.tag == "BlockMove" || hitInfo.collider.tag == "BlockStill")
            {
                //newX = newX * 2;
                //newY = newY * 2;
                WallCollide();
                Debug.Log("Chemin obstrué");
                yield return null;
            }
        }
        else //se déclenche s'il n'y a rien
        {
            MoveToPosition();
            Debug.Log("Rien par ici mon capitaine!");
            yield return null;
        }
    }

    void MoveToPosition()
    {

        shortVector = Vector3.ClampMagnitude(newDirection, distanceRaycast);
        transform.Translate(shortVector);
        StartCoroutine(CalculateRaycast());
    }

    //cette coroutine détermine quand la cloche spawnera dans la partie
    IEnumerator WaitForSpawning()
    {
        yield return new WaitForSeconds(spawningTime);
        cloche.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(CalculateRaycast());
    }

    void Scan() //doit se déclencher quand le chemin est obstrué, pour pouvoir dévier de manière plus marquée
    {
        newDirection = new Vector3(Random.Range(-40, 40), Random.Range(-40, 40));

        if (!canTeleport)
        {
            newDirection = -newDirection + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1));
            canTeleport = true;
        }
        directionRay = new Ray(transform.position, newDirection);
        Debug.Log("scan");

        if (Physics.Raycast(directionRay, out hitInfo, distanceRaycast))
        {

            if (hitInfo.collider.tag == "Floor")
            {
                WallCollide();
                Debug.Log("WallCollide");


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
        vectorCentre = Vector3.ClampMagnitude(vectorCentre, distanceRaycast * 10);
        //rayToCentre = new Ray(transform.position, vectorCentre);
        transform.Translate(-vectorCentre);
        newX = -newX * 2;
        newY = -newY * 2;
        canTeleport = false;
        StartCoroutine(CalculateRaycast());

    }
}

