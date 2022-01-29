using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject Other;
    public bool inControl;
    public float speed = 0.1f;
    public Camera myCam;
    public Vector3 camConstraints;

    private void Start()
    {
        myCam = transform.Find("Camera").GetComponent<Camera>();
        
        if(!inControl)
        {
            myCam.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (inControl)
        {
            transform.position += transform.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") * speed);
            transform.position += transform.TransformDirection(Vector3.right * Input.GetAxis("Horizontal") * speed);

            myCam.transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0 );

            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartCoroutine(Switch());
            }
        }

    }

    IEnumerator Switch()
    {
        if (Other)
        {
            
            PlayerControl OtherControl = null;
            OtherControl = Other.GetComponent<PlayerControl>();
            if (OtherControl == null)
            {
                Debug.Log("Adding Controls to " + Other.name);
                OtherControl = Other.AddComponent<PlayerControl>();
                OtherControl.Other = this.gameObject;            
            }
            
            inControl = false;
            myCam.gameObject.SetActive(false);

            
            OtherControl.myCam.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            OtherControl.inControl = true;
        }
    }
}
