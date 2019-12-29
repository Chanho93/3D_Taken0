using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;
    public GameObject Warrior;
    public Animator Warrior_Ani;

    private AudioSource audio_source;
    public AudioClip beat;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");

        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = beat;
        audio_source.loop = false;
        audio_source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.destination !=target.transform.position)
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
        if(other.CompareTag("Player_Round"))
        {
           

            Warrior_Ani.SetBool("Attack", true);
            Invoke("Attack_Cancel", 1.0f);
           

        }
        if (other.CompareTag("Man_Attack"))
        {
            Warrior_Ani.SetBool("Die", true);
            audio_source.Play();
            Warrior.GetComponent<BoxCollider>().enabled = false;
            Invoke("Des", 1.1f);
           
        }
       
    }
     void Des()
    {
        Destroy(Warrior);
    }


    void Attack_Cancel()
    {
        Warrior_Ani.SetBool("Attack", false);
    }
}
