using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    public float speed = 80f;
    private Rigidbody bulletRigidbody;
    public Transform explosion_effect;
    private AudioSource audio_source;
    public AudioClip ex;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = ex;
        audio_source.loop = false;
        audio_source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Land"))
        {
            Instantiate(explosion_effect, this.transform.position, this.transform.rotation);
            audio_source.Play();
        }

    }
}
