using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] GameObject playerCamPos, ghostCamPos, playerPosition, ghostPosition;
    public float speed = 0.1f;
    public CinemachineVirtualCamera playerCam, ghostCam;
    public int chosenCharacter;

    //TODO: Varmista ett� pelaajan forward on eteenp�in suhteessa valitun objektin rotaatioon.
    //Varmista ett� ghostista siirtyminen takaisin pelaajaan palauttaa ghostin pelaajan positioon.
    //Aseta raja-arvo sille kuinka monen yksik�n p��h�n ghost voi matkata pelaajasta.
    //Ghost voi liikkua my�s Y-axiksella. Se toiminnallisuus pit�� lis�t�.
    private void Start()
    {
        ghostCamPos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            chosenCharacter++;
            ChangeCharacter();
        }
        if (chosenCharacter >= 2)
        {
            chosenCharacter = 0;
            ChangeCharacter();
        }
        if (chosenCharacter == 1)
        {
            ghostCamPos.transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            ghostPosition.transform.position += transform.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") * speed);
            ghostPosition.transform.position += transform.TransformDirection(Vector3.right * Input.GetAxis("Horizontal") * speed);
        }
        if (chosenCharacter == 0)
        {
            playerCamPos.transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            playerPosition.transform.position += transform.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") * speed);
            playerPosition.transform.position += transform.TransformDirection(Vector3.right * Input.GetAxis("Horizontal") * speed);
        }
 
    }
    void ChangeCharacter()
    {
        switch (chosenCharacter)
        {
            case 0:
                playerCamPos.SetActive(true);
                ghostCamPos.SetActive(false);
                playerCam.transform.rotation = playerPosition.transform.rotation;
                StartCoroutine(WaitForGhost());
                break;
            case 1:
                Transform newGhostPosition = playerPosition.transform;
                playerCamPos.SetActive(false);
                ghostCamPos.SetActive(true);
                ghostPosition.transform.position = newGhostPosition.position;
                ghostCam.transform.rotation = ghostPosition.transform.rotation;
                break;

        }
    }
    IEnumerator WaitForGhost()
    {
        Transform newGhostPosition = playerPosition.transform;
        yield return new WaitForSeconds(2);
        ghostPosition.transform.position = newGhostPosition.position;
        StopCoroutine(WaitForGhost());
    }
}
