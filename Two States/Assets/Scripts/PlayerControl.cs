using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject Other;
    public bool inControl;
    public float speed = 0.1f;


    // Update is called once per frame
    void Update()
    {
        if (inControl)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0);
            if(Input.GetKeyDown(KeyCode.Q))
            {
                StartCoroutine(Switch());
            }
        }

    }

    IEnumerator Switch()
    {
        if (Other)
        {
            Debug.Log("Other found");
            PlayerControl OtherControl = null;
            OtherControl = Other.GetComponent<PlayerControl>();
            if (OtherControl == null)
            {
                Debug.Log("Adding Controls to " + Other.name);
                OtherControl = Other.AddComponent<PlayerControl>();
                OtherControl.Other = this.gameObject;            
            }
            
            inControl = false;
            yield return new WaitForSeconds(0.1f);
            OtherControl.inControl = true;
        }
    }
}
