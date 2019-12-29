using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Daughter_Finish : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;
    public GameObject Daughter;
    public Animator Daughter_Ani;
    public Monster_Damaged monster_damaged;

    private AudioSource audio_source;
    public AudioClip hug;
    // Start is called before the first frame update
    void Start()
    {
        Daughter.GetComponent<BoxCollider>().enabled = false;

        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = hug;
        audio_source.loop = false;
        audio_source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (monster_damaged.living == false)
        {
            Daughter.GetComponent<BoxCollider>().enabled = true;
        }

        if (nav.destination != target.transform.position)
        {
            nav.SetDestination(target.transform.position);
        }
        else
        {
            nav.SetDestination(transform.position);
        }

      

    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player_Round"))
        {
          
            nav = GetComponent<NavMeshAgent>();
            target = GameObject.Find("Daughter_hug");

            Daughter_Ani.SetBool("Run", true);

            Invoke("Hug", 2.0f);

        }
      

          
         

        

    }
    void Hug()
    {
        Daughter_Ani.SetBool("Run", false);
        Daughter_Ani.SetBool("Hug", true);
        audio_source.Play();
    }
   


  
}
