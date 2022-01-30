using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookTxtChanger : MonoBehaviour
{
    [SerializeField] private UsableObject use;
    [SerializeField] private PickableObject pick;
    [SerializeField] private TMP_Text txt;

    private void Start()
    {
        if (pick != null) { txt.text = pick.Code; }
        else if (use != null) { txt.text = use.Code; }
        Destroy(this);
    }
}
