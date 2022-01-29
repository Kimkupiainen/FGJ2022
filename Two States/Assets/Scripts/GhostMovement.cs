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
                Transform newGhostPosition = playerPosition.transform;
                ghostPosition.transform.position = newGhostPosition.position;
                playerCamPos.SetActive(true);
                ghostCamPos.SetActive(false);
                playerCam.transform.rotation = playerPosition.transform.rotation;
                break;
            case 1:
                playerCamPos.SetActive(false);
                ghostCamPos.SetActive(true);
                ghostCam.transform.rotation = ghostPosition.transform.rotation;
                break;

        }
    }
}
