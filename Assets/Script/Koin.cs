using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koin : MonoBehaviour
{
    gerak komponenGerak;
    public AudioSource ambilTelur;
    void Start()
    {
        komponenGerak = GameObject.Find("burung").GetComponent<gerak>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            //Destroy(komponenGerak.gameObject);
            komponenGerak.koin++;

            Destroy(gameObject);

            ambilTelur.Play();
           
        }
    }
}
