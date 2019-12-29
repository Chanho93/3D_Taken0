using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character_Moving : MonoBehaviour
{
    private float FootMan_speed = 5.0f;
    private float rot_speed = 120.0f;
    public GameObject Player;
    public GameObject Player_Body;
    public GameObject Hammer;
    public Animator Player_Ani;
    public GameObject UI1;
    // Start is called before the first frame update
    void Start()
    {
        UI1.SetActive(true);
        Invoke("UI1_set", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Player_Ani.SetBool("Attack", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Player_Ani.SetBool("Attack", false);
        }
        if (Input.GetKeyDown("space")) {
            Player_Body.GetComponent<CapsuleCollider>().enabled = false;
            Hammer.GetComponent<BoxCollider>().enabled = false;
            Player_Ani.SetBool("Guard", true);
        }
        if (Input.GetKeyUp("space"))
        {
            Player_Body.GetComponent<CapsuleCollider>().enabled = true;
            Hammer.GetComponent<BoxCollider>().enabled = true;
            Player_Ani.SetBool("Guard", false);
        }

        float distance_per_frame = FootMan_speed * Time.deltaTime;
        float degrees_per_frame = rot_speed * Time.deltaTime;

        float moving_velocity = Input.GetAxis("Vertical");
        float FootMan_angle = Input.GetAxis("Horizontal");

        

        if(-1 <= moving_velocity && moving_velocity <0 )
        {
            Player_Ani.SetBool("Run", true);
        }
        else if(0 < moving_velocity && moving_velocity <= 1)
        {
            Player_Ani.SetBool("Run", true);
        }
        else
        {
            Player_Ani.SetBool("Run", false);
        }

        this.transform.Translate(Vector3.forward * moving_velocity * distance_per_frame);
        this.transform.Rotate(0.0f, FootMan_angle * degrees_per_frame, 0.0f);
    }

    public void UI1_set()
    {
        UI1.SetActive(false);
    }
}
