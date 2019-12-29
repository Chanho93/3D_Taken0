using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Damaged : MonoBehaviour
{
    public float m_StartingHealth = 100f;
    public float m_CurrentHealth;
    public GameObject Player;
    public GameObject Hammer;
    public GameObject Eliya;
    public Animator Player_Ani;

    private AudioSource audio_source;
    public AudioClip beat;
    public AudioClip die;


    public Image m_FillImage1;
    public Image m_FillImage2;
    public Image m_FillImage3;
    public Image m_FillImage4;
    public Image m_FillImage5;
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_StartingHealth;

        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = beat;
        audio_source.loop = false;
        audio_source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy_Sword"))
        {
            audio_source.Play();
            m_CurrentHealth -= 5;


            if (m_CurrentHealth > 80)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 0f);
            if (m_CurrentHealth <= 80 && m_CurrentHealth > 60)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 60 && m_CurrentHealth > 40)
                m_FillImage4.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 40 && m_CurrentHealth > 20)
                m_FillImage3.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 20 && m_CurrentHealth > 0)
                m_FillImage2.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 0)
            {
                m_FillImage1.color = Color.Lerp(Color.red, Color.white, 1f);
                Player_Ani.SetBool("Die", true);
                audio_source.clip = die;
                audio_source.Play();

                Hammer.GetComponent<BoxCollider>().enabled = false;
            }

        }
        else if (other.CompareTag("Bullet"))
        {
            audio_source.Play();
            m_CurrentHealth -= 5;

            if (m_CurrentHealth > 80)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 0f);
            if (m_CurrentHealth <= 80 && m_CurrentHealth > 60)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 60 && m_CurrentHealth > 40)
                m_FillImage4.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 40 && m_CurrentHealth > 20)
                m_FillImage3.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 20 && m_CurrentHealth > 0)
                m_FillImage2.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 0)
            {
                m_FillImage1.color = Color.Lerp(Color.red, Color.white, 1f);
                audio_source.clip = die;
                audio_source.Play();
                Player_Ani.SetBool("Die", true);
                Hammer.GetComponent<BoxCollider>().enabled = false;
            }
        }
        else if (other.CompareTag("Enemy_Body"))
        {
            audio_source.Play();
            m_CurrentHealth -= 5;

            if (m_CurrentHealth > 80)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 0f);
            if (m_CurrentHealth <= 80 && m_CurrentHealth > 60)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 60 && m_CurrentHealth > 40)
                m_FillImage4.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 40 && m_CurrentHealth > 20)
                m_FillImage3.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 20 && m_CurrentHealth > 0)
                m_FillImage2.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 0)
            {
                m_FillImage1.color = Color.Lerp(Color.red, Color.white, 1f);
                audio_source.clip = die;
                audio_source.Play();
                Player_Ani.SetBool("Die", true);
                Hammer.GetComponent<BoxCollider>().enabled = false;
            }
        }
        else if (other.CompareTag("Monster"))
        {

            m_CurrentHealth -= 10;
            audio_source.Play();
            if (m_CurrentHealth > 80)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 0f);
            if (m_CurrentHealth <= 80 && m_CurrentHealth > 60)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 60 && m_CurrentHealth > 40)
                m_FillImage4.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 40 && m_CurrentHealth > 20)
                m_FillImage3.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 20 && m_CurrentHealth > 0)
                m_FillImage2.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 0)
            {
                audio_source.clip = die;
                audio_source.Play();
                m_FillImage1.color = Color.Lerp(Color.red, Color.white, 1f);
                Player_Ani.SetBool("Die", true);
                Hammer.GetComponent<BoxCollider>().enabled = false;
            }
        }
        else if (other.CompareTag("Eliya"))
        {
            Eliya.SetActive(true);
            Invoke("Eliya_set", 3.0f);
        }

        }
    void Eliya_set()
    {
        Eliya.SetActive(false);
    }

   
}
