using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPlacement : MonoBehaviour
{
    
    public GameObject[] Players;
    public List<GameObject> WinSceneplacement;
    public int count;
    public GameObject cam;
    public int playercount;
    public GameObject slider;
    public GameObject text;
    public GameObject WinUI;

    // Start is called before the first frame update
    void Start()
    {
        
        count = 0;
    }

    // Update is called once per frame
   void Win()
    {
        WinUI.SetActive(true);
    }
    public void placement()
    {
        text.SetActive(false);
        if (Winplacement[0].gameObject.tag=="Enemy")
        {
            Winplacement[0].transform.localPosition = new Vector3(94, 11f, 214);
        }
        else
        {
            Winplacement[0].transform.localPosition = new Vector3(94, 11, 214);
        }
        if (Winplacement[1].gameObject.tag == "Enemy")
        {
            Winplacement[1].transform.localPosition = new Vector3(94, 11f, 211);
        }
        else
        {
            Winplacement[1].transform.localPosition = new Vector3(94, 11, 211);
        }
        if (Winplacement[2].gameObject.tag == "Enemy")
        {
            Winplacement[2].transform.localPosition = new Vector3(94, 11f, 217);
        }
        else
        {
            Winplacement[2].transform.localPosition = new Vector3(94, 11, 217);
        }


        Invoke("Win", 3);
        slider.SetActive(false);

        cam.SetActive(true);
    }
    List<GameObject> Winplacement = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Character"|| other.gameObject.tag == "Enemy" )&& count<3)
        {
            Winplacement.Add(other.gameObject);
            count += 1;
            Debug.Log(other.gameObject.name);

        }
        if ((other.gameObject.tag == "Character" || other.gameObject.tag == "Enemy"))
        {

            playercount += 1;
            if (playercount==5)
            {
                Invoke("placement", 2);
            }
        }
    }
}
