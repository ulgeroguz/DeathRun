using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Slider[] Sliders;
    public GameObject[] TotalDestination;
    public GameObject Apoint;
    public GameObject Bpoint;
    public float distance;
    public float distanceCOunt;
    public float herodistance;
    public GameObject[] Users;
    public float userdistance;
    public float user2distance;
    public float userdistance1;
    public float user2distance1;
    public float userdistance2;
    public float user2distance2;
    public float userdistance3;
    public float user2distance3;
    public float userdistance4;
    public float user2distance4;
    public float userdistance5;
    public float user2distance5;
    public GameObject AApoint;
    public GameObject BBpoint;
    public GameObject[] Cpoint;

    // Start is called before the first frame update
    void Start()
    {
       
      
        for (int i = 0; i < TotalDestination.Length; i++)
        {
            Apoint = TotalDestination[i];
            Bpoint = TotalDestination[i+1];
            distance = Vector3.Distance(Apoint.transform.position, Bpoint.transform.position);
            distanceCOunt = distanceCOunt + distance;
        }
    }

    // Update is called once per frame
    void Update() 
    {

        Sliders[0].value = userdistance+user2distance;
        
        if (userdistance > 150)
        {

            user2distance = Vector3.Distance(BBpoint.transform.position, Cpoint[0].transform.position);
        }
        else
        {
            userdistance = Vector3.Distance(AApoint.transform.position, Cpoint[0].transform.position);
        }
        Sliders[1].value = userdistance1 + user2distance1;

        if (userdistance1 > 150)
        {

            user2distance1 = Vector3.Distance(BBpoint.transform.position, Cpoint[1].transform.position);
        }
        else
        {
            userdistance1 = Vector3.Distance(AApoint.transform.position, Cpoint[1].transform.position);
        }
        Sliders[2].value = userdistance2 + user2distance2;

        if (userdistance2 > 150)
        {

            user2distance2 = Vector3.Distance(BBpoint.transform.position, Cpoint[2].transform.position);
        }
        else
        {
            userdistance2 = Vector3.Distance(AApoint.transform.position, Cpoint[2].transform.position);
        }
        Sliders[3].value = userdistance3 + user2distance3;

        if (userdistance3 > 150)
        {

            user2distance3 = Vector3.Distance(BBpoint.transform.position, Cpoint[3].transform.position);
        }
        else
        {
            userdistance3 = Vector3.Distance(AApoint.transform.position, Cpoint[3].transform.position);
        }
        Sliders[4].value = userdistance4 + user2distance4;

        if (userdistance4 > 150)
        {

            user2distance4 = Vector3.Distance(BBpoint.transform.position, Cpoint[4].transform.position);
        }
        else
        {
            userdistance4 = Vector3.Distance(AApoint.transform.position, Cpoint[4].transform.position);
        }
        Sliders[5].value = userdistance5 + user2distance5;

        if (userdistance5 > 150)
        {

            user2distance5 = Vector3.Distance(BBpoint.transform.position, Cpoint[5].transform.position);
        }
        else
        {
            userdistance5 = Vector3.Distance(AApoint.transform.position, Cpoint[5].transform.position);
        }
        
    }
    //
    //    userdistance = Vector3.Distance(Apoint.transform.position, Users[0].transform.position);

    //    Sliders[0].value =A+B+C+D;
    //    if (Sliders[0].value==)
    //    {
    //        A += userdistance;
    //    }
    //    for (int i= 0; i < TotalDestination.Length; i++)
    //    {

    //        Apoint = TotalDestination[i];
    //        Bpoint = TotalDestination[i + 1];
    //        AB = Vector3.Distance(Apoint.transform.position, Bpoint.transform.position);




    //        userdistance = 0;
    //        }
    //

 
}
