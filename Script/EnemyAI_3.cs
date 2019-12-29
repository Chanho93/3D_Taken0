using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class EnemyAI_3 : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;
    public GameObject Monster;

    public Animator Monster_Ani;

    private AudioSource audio_source;
    public AudioClip attack;
    // Start is called before the first frame update
    void Start()
    {
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = attack;
        audio_source.loop = false;
        audio_source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            target = GameObject.Find("Player");

            Monster_Ani.SetBool("Attack1", true);
            audio_source.Play();
            Invoke("Attack_Cancel", 2.0f);

        }
      
        if (other.CompareTag("Man_Attack"))
        {
            //  Cavalry.GetComponent<BoxCollider>().enabled = false;

            // Monster.transform.DOMove(new Vector3(0f, 10f, 40f), 10.0f).SetEase(Ease.Linear);
            // Monster.transform.DORotate(new Vector3(-90f, 0f, 0f), 1.0f).SetEase(Ease.Linear);
            // Invoke("Des", 1.1f);


        }

    }


   

  void Attack_Cancel()
    {
        Monster_Ani.SetBool("Attack1", false);
    }

    void Des()
    {
        Destroy(Monster);
    }


  
}
