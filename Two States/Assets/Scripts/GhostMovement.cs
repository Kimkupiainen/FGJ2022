using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GhostMovement : MonoBehaviour
{
    bool canMove = true;
    [SerializeField] GameObject playerCamPos, ghostCamPos, playerPosition, ghostPosition;
    Rigidbody playerRb, ghostRb;
    [SerializeField] int speed = 20;
    float ghostDistance = 8;
    public CinemachineVirtualCamera playerCam, ghostCam;
    public int chosenCharacter;
    Vector3 PlayerNormalHeight;
    Vector3 crouchHeight = new Vector3(0, -0.5f, -0);
    [SerializeField] private UseObject ghostHand;
    [SerializeField] private UseObject humanHand;

    private void Start()
    {

        PlayerNormalHeight = playerPosition.transform.localScale;
        ghostHand.Enable(false);
        humanHand.Enable(true);
        ghostCamPos.SetActive(false);
        StartCoroutine(WaitForGhost());
        Cursor.lockState = CursorLockMode.Locked; // Pitää muistaa callaa unlockkia jos on menu tms
    }

    // Update is called once per frame
    void Update()
    {


        if (canMove)
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

            if (chosenCharacter == 1)  //GHOST
            {

                ghostCamPos.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
                ghostPosition.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
                ghostPosition.transform.position += ghostCamPos.transform.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
                ghostPosition.transform.position += ghostCamPos.transform.TransformDirection(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
                ghostPosition.transform.position += Vector3.up * Input.GetAxis("Jump") * speed * Time.deltaTime;
                ghostPosition.transform.position += Vector3.down * Input.GetAxis("Fire3") * speed * Time.deltaTime;
                if (Vector3.Distance(playerPosition.transform.position, ghostPosition.transform.position) >= ghostDistance)
                {
                    ghostPosition.transform.position = Vector3.MoveTowards(ghostPosition.transform.position, playerPosition.transform.position, speed * Time.deltaTime);
                }
            }
            if (chosenCharacter == 0) //PLAYER
            {
                playerCamPos.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
                playerPosition.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
                playerPosition.transform.position += transform.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
                playerPosition.transform.position += transform.TransformDirection(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);                
            }
            if (Input.GetButtonDown("Fire3") && chosenCharacter == 0)
            {
                playerPosition.transform.localScale += crouchHeight; 
            }
            if (Input.GetButtonUp("Fire3") || chosenCharacter != 0)
            {
                playerPosition.transform.localScale = PlayerNormalHeight;
            }
        }

    }

    void ChangeCharacter()
    {
        canMove = false;
        switch (chosenCharacter)
        {
            // Ghost -> Player
            case 0:
                ghostHand.Enable(false);
                humanHand.Enable(true);
                playerCamPos.SetActive(true);
                ghostCamPos.SetActive(false);
                playerCam.transform.rotation = playerPosition.transform.rotation;
                StartCoroutine(WaitForGhost());
                break;

            //Player -> Ghost
            case 1:
                ghostHand.Enable(true);
                humanHand.Enable(false);
                Transform newGhostPosition = playerPosition.transform;
                playerCamPos.SetActive(false);
                ghostCamPos.SetActive(true);
                ghostPosition.transform.position = newGhostPosition.position;
                ghostCam.transform.rotation = ghostCam.transform.rotation;
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
