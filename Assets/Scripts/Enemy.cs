using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject heros;
    public NavMeshAgent agent;
    public GameObject[] enemies;
    public GameObject SmallestDistantObject;
    public GameObject FinishLine;
    public float newdistance;
    public float olddistance;
    public float mydistance;
    public bool isProtected;
    public Animator anim;
    public Vector3 OldLocation;
    public bool isFallStart;
    public bool isFallEnd;
    public GameObject player;
    public float timebreak;
    public int PossibiltyFall;
    public bool isFall;
    public Player plyr;
    public ParticleSystem ShieldParticle;
    public ParticleSystem SlipParticle;
    public ParticleSystem BlownParticle; 
    public ParticleSystem hitwallParticle;
    public ParticleSystem hitwall2Particle;
    public GameObject[] FinisPoints;
    private int finishpointcount;
    public float destdistance;
    private int changelocation;
    public GameObject spikecloseParticle;
    public bool isWin;
    void Start()
    {
        isProtected = false;
        agent.destination = FinisPoints[0].transform.position;
        isFall = false;
    }
    public void Win()
    {
        anim.SetTrigger("Win");
        agent.enabled = false;
    }
    public void Blown()
    {
        BlownParticle.Play();
        anim.SetTrigger("Blown");
        agent.speed = 0;
       
        Invoke("LateStartFade", 2);
    }
    public void Slip()
    {
        anim.SetTrigger("Slip");
        agent.speed = 0;
        SlipParticle.Play();
       
       Invoke("LateStartFade", 2);

    }
    void LateStartFade()
    {
        agent.speed = 10;
       //isHitWall = true;
    }

    void Fall()
    {
        heros.transform.position = OldLocation;
        isFallStart = false;
        isFallEnd = true;
    }
    void Wallfall()
    {
        agent.enabled = true;
        agent.destination = FinishLine.transform.position;
        agent.speed = 10;

    }

    void RemoveShield()
    {
        spikecloseParticle.SetActive(false);

        isProtected = false;
    }


    // Update is called once per frame
    void Update()
    {

        destdistance = Vector3.Distance(FinishLine.transform.position, transform.position);
        if (destdistance <=6)
        {
            changelocation++;
            if (changelocation == 1)
            {
                FinishLine = FinisPoints[1];
                agent.destination = FinishLine.transform.position;
            }
        }  
            if ((anim.GetCurrentAnimatorStateInfo(0).IsName("Slip") || anim.GetCurrentAnimatorStateInfo(0).IsName("Blown")) && player.transform.position.y > -0.43f)
        {
            Vector3 tempVector1 = player.transform.position;
            tempVector1.y -= 0.5f * Time.deltaTime;
            player.transform.position = tempVector1;
        }
        else if(!isFall&&!isWin)
        {
            Vector3 tempVector1 = player.transform.localPosition;
            tempVector1.y = 0.039f;
            player.transform.localPosition = tempVector1;
        }
        //timebreak += Time.deltaTime;
        //if (timebreak>5)
        //{
        //    PossibiltyFall = Random.Range(0, 5);
        //    if (PossibiltyFall==1)
        //    {
                
        //        agent.enabled = false;
        //        isFall = true;
        //    }
        //    timebreak = 0;
        //}
        if(false)
        {
           
           
        }
        if (GetComponent<Transform>().position.y < 0 && isFallStart == false && !isWin)
        {
            OldLocation = new Vector3(heros.transform.position.x, 0, heros.transform.position.z);

            Invoke("Fall", 2);
            isFallStart = true;
            isFallEnd = false;
          
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Win")
        {
           
            isWin = true;
            Invoke("Win", 0.5f);
            
            
        }
        if (other.gameObject.tag == "Wall")
        {
            hitwallParticle.Play();
            hitwall2Particle.Play();
            agent.enabled = false ;
            agent.speed = 0;
            anim.SetTrigger("Fall");
           
            Invoke("Wallfall", 2);


        }

        if (other.gameObject.tag == "Rock")
        {
            other.gameObject.SetActive(false);
            olddistance = Vector3.Distance(enemies[0].transform.position, FinishLine.transform.position);
            SmallestDistantObject = enemies[0];
            for (int i = 1; i < enemies.Length; i++)
            {
                newdistance = Vector3.Distance(enemies[i].transform.position, FinishLine.transform.position);
                if (olddistance > newdistance)
                {
                    SmallestDistantObject = enemies[i];
                    olddistance = newdistance;
                }
            }
            if (SmallestDistantObject == enemies[0])
            {

            }
            else if (SmallestDistantObject==enemies[1])
            {
                if (enemies[1].GetComponent<Player>().isProtected)
                {

                }
                else
                {
                    plyr.Blown();
                }
               
                //player.script fonksiyon çağır
            }
            else
            {

                SmallestDistantObject.GetComponent<Enemy>().Blown();
            }
        }
        if (other.gameObject.tag=="Banana")
                  {
            other.gameObject.SetActive(false);
            mydistance = Vector3.Distance(enemies[0].transform.position, FinishLine.transform.position);
            olddistance = 10000;
            for (int i = 1; i < enemies.Length; i++)
            {
                newdistance = Vector3.Distance(enemies[i].transform.position, FinishLine.transform.position);
                if (mydistance < newdistance)
                {
                    if (olddistance>newdistance)
                    {
                        SmallestDistantObject = enemies[i];
                        olddistance = newdistance;

                    }
                    
                    
                }

            }
            if (SmallestDistantObject == enemies[0])
            {

            }
            else if (SmallestDistantObject == enemies[1])
            {
                if (enemies[1].GetComponent<Player>().isProtected)
                {

                }
                else
                {
                    plyr.Slip();
                }
               
    //player.script fonksiyon çağır
}
            else
            {

                SmallestDistantObject.GetComponent<Enemy>().Slip();
            }
        }
        if (other.gameObject.tag == "Shield")
        {
            other.gameObject.SetActive(false);
            spikecloseParticle.SetActive(true);
            ShieldParticle.Play();
            isProtected = true;
            Invoke("RemoveShield", 5);
        }
       
        if (other.gameObject.tag == "test")
        {
           Blown();
        }
    }
}
