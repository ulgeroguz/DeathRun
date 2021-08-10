using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 OldLocation;
 
    public bool isFallStart;
    public bool isFallEnd;
    public bool isHitWall;
    public bool hasSlipped;
    public float add90f=0;
    private Quaternion targetRotation ;

    private bool hasFaded = false;
    
    public GameObject player;
    public int count;
    public float speed;
    public Animator anim;
    public  bool isProtected;
    public GameObject[] enemies;
    public GameObject SmallestDistantObject;
    public GameObject FinishLine;
    public GameObject[] FinisPoints;
    private int finishpointcount;
    public float newdistance;
    public float olddistance;
    public float mydistance;
    public Enemy enemy;
    public List<Transform> checkpoints;
    public Transform checkp;
    public ParticleSystem ShieldParticle;
    public GameObject spikecloseParticle;
    public ParticleSystem hitwallParticle;
    public ParticleSystem hitwall2Particle;
    public ParticleSystem SlipParticle;
    public ParticleSystem BlownParticle;
    public GameObject rockprojectile;
    public int turnspeed;
    public Transform enemypos;
    private int enemynum;
    public GameObject confetti;
    public GameObject confetti2;


    // Start is called before the first frame update
    void Start()
    {
        finishpointcount = 0;
        speed = 10;
        isProtected = false;
        isFallEnd = false;
        checkp.transform.position = player.transform.position;
    }
  
   public void Blown()
    {
        anim.SetTrigger("Blown");
        BlownParticle.Play();
        speed = 0;
        count = 0;
        Invoke("LateStartFade", 2);
    }
    public void Slip()
    {
        SlipParticle.Play();
        anim.SetTrigger("Slip");
        speed = 0;
        count = 0;
        Invoke("LateStartFade", 2);
       
    }
    void LateStartFade()
    {
        speed = 10;
        // isHitWall = true;
    }

    void Fall()
    {
        player.transform.localPosition = checkp.transform.position; 
        isFallStart = false;
        isFallEnd = true;
        if (add90f==-90)
        {

            player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, -180, player.transform.rotation.z);
            add90f += 90;
        }
        else if (add90f == -180)
        {

            player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, -270, player.transform.rotation.z);
            add90f += 90;
        }
        else if (add90f == -270)
        {

            player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, 0, player.transform.rotation.z);
            add90f += 90;
        }
    }
    void WallFall()
    {
        speed = 10;
        //isHitWall = true;
    }
    void RemoveShield()
    {
        spikecloseParticle.SetActive(false);
       
        isProtected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("Slip")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Blown") )&& player.transform.position.y>-0.43f)
        {
            Vector3 tempVector = player.transform.localPosition;
            tempVector.y -= 0.25f* Time.deltaTime;
            player.transform.localPosition = tempVector;
        }
        else
        {
            //Vector3 tempVector = player.transform.localPosition;
            //tempVector.y = 0.039f;
            //player.transform.localPosition = tempVector;
        }
            if (!hasFaded&&isFallEnd&&count<4)
        {
          //  StartCoroutine(Fade(player, 0.3f));
            
          
        }
       
        if (!hasFaded && isHitWall)
        {
            StartCoroutine(FadeWall(player, 0.3f));
           
        }

        if (GetComponent<Transform>().position.y<0&&isFallStart==false)
        {
            OldLocation = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            
            Invoke("Fall", 2);
            isFallStart = true;
            isFallEnd = false;
            count = 0;
           
            

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (player.transform.rotation.y==-1)//&& player.transform.rotation.y <= -0.15f)
            {
               
                transform.position -= Vector3.right * speed * Time.deltaTime;
            }
            else if (player.transform.rotation.y == 0)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else if (player.transform.rotation.y == 0.7071068f)
                //&& player.transform.rotation.y >= -0.15f)
            {
             
                transform.position -= Vector3.forward * speed * Time.deltaTime;
            }
            else if (player.transform.rotation.y == -0.7071068f)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (player.transform.rotation.y == -1 )//&& player.transform.rotation.y <= -0.15f)
            {
              
                transform.position -= Vector3.left * speed * Time.deltaTime;
            }
           else if (player.transform.rotation.y == 0)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
           else if (player.transform.rotation.y == 0.7071068f)
                //&& player.transform.rotation.y >= -0.15f)
            {
                //if (player.transform.rotation.y != 0.7071068f)
                //{
                //    turnspeed = -10;

                //}
                //else
                //{
                //    turnspeed = 0;
                //}
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            else if (player.transform.rotation.y == -0.7071068f)
            {
                transform.position -= Vector3.forward * speed * Time.deltaTime;
            }
        }
        GetComponent<Transform>().position += transform.forward * speed * Time.deltaTime;
    }
    public IEnumerator Fade(GameObject player, float seconds)
    {

        hasFaded = true;
        player.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        player.SetActive(true);
        yield return new WaitForSeconds(0.3f); // Appear for one second
        count = count + 1;
        hasFaded = false;
    }
    public IEnumerator FadeWall(GameObject player, float seconds)
    {
        Time.timeScale = 1;
        if (count<4)
        {
            speed = 10;
            hasFaded = true;
            player.SetActive(false);
            while (hasFaded)
            {
                yield return new WaitForSeconds(0.3f);
            }
            Time.timeScale = 1;
            player.SetActive(true);
            while (hasFaded)
            {
                yield return new WaitForSeconds(0.3f);
            } // Appear for one second
            count = count + 1;
            hasFaded = false;
        }
        else
        {
            isHitWall = false;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Win")
        {
            anim.SetTrigger("Win");
            speed = 0;
            confetti.SetActive(true);
            confetti2.SetActive(true);

        }
        if (other.gameObject.tag == "finish")
        {
            
            FinishLine = FinisPoints[finishpointcount+1];
            finishpointcount += 1;
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
                    enemynum = i;
                }
            }
            if (SmallestDistantObject == enemies[0])
            {

            }
            else
            {
                // Vector3 xyz = enemies[enemynum].transform.position;
                //     /*new Vector3(enemies[enemynum].transform.position.x, enemies[enemynum].transform.position.y, enemies[enemynum].transform.position.z);*/
                // Quaternion newRotation = Quaternion.Euler(xyz);
                // //  enemypos.position = enemies[0].transform.localPosition;
                // Instantiate(rockprojectile, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), newRotation);
                //// rockprojectile.SetActive(true);
                ///
               
                
                enemy = enemies[enemynum].GetComponent<Enemy>();
                RaycastHit hit;


                GameObject projectile = Instantiate(rockprojectile, new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z), Quaternion.identity) as GameObject; //Spawns the selected projectile
                projectile.transform.LookAt(new Vector3(enemies[enemynum].transform.position.x, enemies[enemynum].transform.position.y, enemies[enemynum].transform.position.z));
                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 50); //Set the speed of the projectile by applying force to the rigidbody

                Destroy(projectile, 2f);
                enemy.Blown();
                //SmallestDistantObject.GetComponent<Enemy>. fonksiyon çağır
            }
        }
        if (other.gameObject.tag == "Banana")
        {
            other.gameObject.SetActive(false);
            mydistance = Vector3.Distance(enemies[0].transform.position, FinishLine.transform.position);
            olddistance = 10000;
            for (int i = 1; i < enemies.Length; i++)
            {
                newdistance = Vector3.Distance(enemies[i].transform.position, FinishLine.transform.position);
                if (mydistance < newdistance)
                {
                    if (olddistance > newdistance)
                    {
                        SmallestDistantObject = enemies[i];
                        olddistance = newdistance;
                        enemynum = i;
                    }

                   
                }

            }
            if (SmallestDistantObject == enemies[0])
            {

            }
          
            else 
            {
                if (enemies[1].GetComponent<Enemy>().isProtected)
                {

                }
                enemy = enemies[enemynum].GetComponent<Enemy>();
                enemy.Slip();
                //SmallestDistantObject.GetComponent<Enemy>. fonksiyon çağır
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
        if (other.gameObject.tag == "Wall")
        {
            speed = 0;
            anim.SetTrigger("Fall");
            hitwallParticle.Play();
            hitwall2Particle.Play();
          
            count = 0;
            Invoke("WallFall", 2);
          
        }
        if (other.gameObject.tag == "test")
        {

            Slip();
        }
        if (other.gameObject.name=="CheckA")
        {
            checkp = checkpoints[0];
        }
        if (other.gameObject.name == "CheckB")
        {
            checkp = checkpoints[1];
        }
        if (other.gameObject.name == "CheckC")
        {
            checkp = checkpoints[2];
        }
        if (other.gameObject.name == "CheckD")
        {
            checkp = checkpoints[3];
        }
        if (other.gameObject.name == "CheckE")
        {
            checkp = checkpoints[4];
        }
        if (other.gameObject.name == "CheckF")
        {
            checkp = checkpoints[5];
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "turn")
        {
             targetRotation = Quaternion.Euler(transform.eulerAngles.x, add90f+90f, transform.eulerAngles.z);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, (22)* Time.deltaTime);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "turn")
        {
            add90f = add90f - 90;
            turnspeed = 0;
        }
    }
}
