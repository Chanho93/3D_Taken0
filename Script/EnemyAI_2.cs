using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class EnemyAI_2 : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;
    public GameObject Cavalry;
   
    public Animator Cavalry_Ani;

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
            Cavalry_Ani.SetBool("Attack", true);
            Invoke("Attack_Cancel", 1.0f);
        }
        if (other.CompareTag("Man_Attack"))
        {
            Cavalry.GetComponent<BoxCollider>().enabled = false;
            audio_source.Play();
            Cavalry.transform.DOMove(new Vector3(0f, 10f, 40f), 10.0f).SetEase(Ease.Linear);
            Cavalry.transform.DORotate(new Vector3(-90f, 0f, 0f), 1.0f).SetEase(Ease.Linear);
            Invoke("Des", 1.1f);

           
        }

    }

    void Des()
    {
        Destroy(Cavalry);
    }


    void Attack_Cancel()
    {
        Cavalry_Ani.SetBool("Attack", false);
    }
}
