using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GhostMovement : MonoBehaviour
{
    bool canMove = true;
    [SerializeField] GameObject playerCamPos, ghostCamPos, playerPosition, ghostPosition;
    Rigidbody playerRb, ghostRb;
    public float speed = 0.1f;
    public float ghostDistance = 50;
    public CinemachineVirtualCamera playerCam, ghostCam;
    public int chosenCharacter;

    //TODO: Varmista että pelaajan forward on eteenpäin suhteessa valitun objektin rotaatioon.
    //Varmista että ghostista siirtyminen takaisin pelaajaan palauttaa ghostin pelaajan positioon.
    //Aseta raja-arvo sille kuinka monen yksikön päähän ghost voi matkata pelaajasta.
    //Ghost voi liikkua myös Y-axiksella. Se toiminnallisuus pitää lisätä.
    private void Start()
    {
        ghostCamPos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                chosenCharacter++;
                StartCoroutine(ChangeCharacter());
            }
            if (chosenCharacter >= 2)
            {
                chosenCharacter = 0;
                StartCoroutine(ChangeCharacter());
            }

            if (chosenCharacter == 1)
            {

                ghostCamPos.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
                ghostPosition.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
                if (Vector3.Distance(playerPosition.transform.position, ghostPosition.transform.position) <= ghostDistance)
                {            
                    ghostPosition.transform.position += ghostCamPos.transform.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") * speed);
                    ghostPosition.transform.position += ghostCamPos.transform.TransformDirection(Vector3.right * Input.GetAxis("Horizontal") * speed);
                    ghostPosition.transform.position += Vector3.up * Input.GetAxis("Jump") * speed;
                }else
                {
                    StartCoroutine(Slideback());
                }
            }
            if (chosenCharacter == 0)
            {
                playerCamPos.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
                playerPosition.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
                playerPosition.transform.position += transform.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") * speed);
                playerPosition.transform.position += transform.TransformDirection(Vector3.right * Input.GetAxis("Horizontal") * speed);
            }
        }
 
    }
    IEnumerator Slideback()
    {
        canMove = false;
        ghostCamPos.transform.position = Vector3.MoveTowards(ghostCamPos.transform.position, playerPosition.transform.position, speed);
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }

    IEnumerator ChangeCharacter()
    {
        canMove = false;
        switch (chosenCharacter)
        {
            // Ghost -> Player
            case 0:
                playerCamPos.SetActive(true);
                ghostCamPos.SetActive(false);
                playerCam.transform.rotation = playerPosition.transform.rotation;

                StartCoroutine(WaitForGhost());
                break;

                //Player -> Ghost
            case 1:
                Transform newGhostPosition = playerPosition.transform;
                playerCamPos.SetActive(false);
                ghostCamPos.SetActive(true);
                ghostPosition.transform.position = newGhostPosition.position;
                ghostCam.transform.rotation = ghostPosition.transform.rotation;
                yield return new WaitForSeconds(2);
                ghostPosition.transform.parent = null;
                canMove = true;
                break;

        }
    }
    IEnumerator WaitForGhost()
    {
        Transform newGhostPosition = playerPosition.transform;
        yield return new WaitForSeconds(2);
        ghostPosition.transform.position = newGhostPosition.position;
        ghostPosition.transform.rotation = playerPosition.transform.rotation;
        ghostPosition.transform.parent = playerPosition.transform;
        canMove = true;
        StopCoroutine(WaitForGhost());
    }
}
