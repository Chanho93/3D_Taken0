using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Monster_Damaged : MonoBehaviour
{
    public float m_StartingHealth = 100f;
    public float m_CurrentHealth;
    public GameObject Monster;
    public GameObject Hammer;
    public Animator Monster_Ani;
    public bool living = true;

    private AudioSource audio_source;
    public AudioClip beat;
    public AudioClip Die;
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
        if (other.CompareTag("Man_Attack"))
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
                m_FillImage1.color = Color.Lerp(Color.red, Color.white, 1f);
                  Monster.GetComponent<BoxCollider>().enabled = false;
                audio_source.clip = Die;
                audio_source.Play();
                 Monster.transform.DOMove(new Vector3(-2.39f, 1.9f, 112.44f), 10.0f).SetEase(Ease.Linear);
                 Monster.transform.DORotate(new Vector3(-90f, 0f,73.12f), 1.0f).SetEase(Ease.Linear);
                 Invoke("Des", 1.5f);
                living = false;
                Hammer.GetComponent<BoxCollider>().enabled = false;


            }

        }
      

    }
     void Des()
    {
        Monster.SetActive(false);
    }


}
