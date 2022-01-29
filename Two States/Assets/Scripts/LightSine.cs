using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSine : MonoBehaviour
{
    Light pointLight;
    [SerializeField]int t = 200;
    // Start is called before the first frame update
    private void Start()
    {
      pointLight = gameObject.GetComponent<Light>();
    }
    // Update is called once per frame
    void Update()
    {

        pointLight.intensity =(Mathf.Lerp(2, 10, t));
    }
}
