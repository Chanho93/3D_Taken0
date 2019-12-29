using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;

    Rigidbody rigidbody;

    Vector3 movement;


     void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

     void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Run(h, v);
    }

    void Run(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movement);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
