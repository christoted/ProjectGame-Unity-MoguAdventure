using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musuh : MonoBehaviour
{
    // Start is called before the first frame update
    gerak komponenGerak;
    public AudioSource kenaKaktus;
    void Start()
    {
        komponenGerak = GameObject.Find("burung").GetComponent<gerak>();
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.transform.tag == "Player")
        {
            //Destroy(komponenGerak.gameObject);
             komponenGerak.nyawa--;
             komponenGerak.ulang = true;
             kenaKaktus.Play();
        }
    }
}
