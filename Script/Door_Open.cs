using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door_Open : MonoBehaviour
{
    public  GameObject Door;
    public GameObject Door2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            Door.transform.DORotate(new Vector3(0f, 90f, 0f), 2.0f).SetEase(Ease.Linear);
            Door.SetActive(false);
        }
    }
    */
}
