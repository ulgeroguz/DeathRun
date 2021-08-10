using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampName : MonoBehaviour
{
    // Start is called before the first frame update
    public Text namelabel;
    // Update is called once per frame
    void Update()
    {
        Vector3 namepos = Camera.main.WorldToScreenPoint(this.transform.position);
        namelabel.transform.position = namepos;
    }
}
