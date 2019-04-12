using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belajar : MonoBehaviour
{
    public string pesan;
    public int kecepatan;
    public float waktu;
    public bool aktif;
    // Start is called before the first frame update
    void Start()
    {
    
         
    }

    // Update is called once per frame
    void Update()
    {
        waktu = waktu + Time.deltaTime;

        if ( waktu >= 3)
        {
            aktif = true;
        }

        if ( aktif == true)
        {
            print(pesan);
            kecepatan = 5;
        }
    }
}
