using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerak : MonoBehaviour
{
    public int kecepatan,kekuatanLompat;
    public bool balik;
    public int pindah;

    Rigidbody2D lompat;

    public bool tanah;
    public LayerMask targetPlayer;
    public Transform deteksiTanah; // untuk mendeteksi posisi
    public float jangkuan;

    Animator anim;

    public int nyawa;
    public int koin;

    Vector2 mulai;
    public bool ulang;

    Text infoKoin;

    public bool tombolKiri,tombolKanan;


    public GameObject menang, kalah;

    //public Button btnNextLevel,restart;

    public Button btnNextLevel;

    public AudioSource loncatMogu,moguMati,timerCountDown;

    // Tambahan

    public GameObject heart1, heart2, heart3, gameOver, restart;

    //public bool tombolLoncat;

    // Time
    public int timeleft = 30;
    public Text countdownText;

    public GameObject Timeup;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoseTime");

        infoKoin = GameObject.Find("UIkoin").GetComponent<Text>();
        lompat = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mulai = transform.position;
        //btnNextLevel = GameObject.Find("Button");

        nyawa = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        kalah.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Time
        countdownText.text = (""+timeleft);

        if ( timeleft == 4 && timeleft > 0)
        {
            timerCountDown.Play();
        }
        else if ( timeleft == 0)
        {
            StopCoroutine("LoseTime");
            Destroy(gameObject);
            Timeup.SetActive(true);
            restart.gameObject.SetActive(true);
            timerCountDown.Stop();
            moguMati.Play();
        } 



         if ( nyawa > 3)
         {
             nyawa = 3;
         }

         if ( nyawa == 3 )
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);

           // Debug.Log(transform.position.y);
        }
         else if ( nyawa == 2 )
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(false);

           // Debug.Log(transform.position.y);
        }
         else if ( nyawa == 1 )
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);

           // Debug.Log(transform.position.y);
        }
         else if ( nyawa == 0 )
        {
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);

            Destroy(gameObject);

            //Debug.Log(transform.position.y);
          
            kalah.SetActive(true);
            restart.gameObject.SetActive(true);
            moguMati.Play();
        }

         if ( transform.position.y < -40f)
        {
           // Destroy(gameObject);
           // kalah.SetActive(true);
           // restart.gameObject.SetActive(true);
           // moguMati.Play();

            if (nyawa > 3)
            {
                nyawa = 3;  
            }

            if (nyawa == 3)
            {
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);

                // Debug.Log(transform.position.y);
            }
            else if (nyawa == 2)
            {
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);

                // Debug.Log(transform.position.y);
            }
            else if (nyawa == 1)
            {
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);

                // Debug.Log(transform.position.y);
            }
            else if (nyawa == 0)
            {
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);

                Destroy(gameObject);

                //Debug.Log(transform.position.y);

                kalah.SetActive(true);
                restart.gameObject.SetActive(true);
                moguMati.Play();
            }
        }

        /* switch(nyawa)
         {
             case 3:
                 heart1.gameObject.SetActive(true);
                 heart2.gameObject.SetActive(true);
                 heart3.gameObject.SetActive(true);
                 break;

             case 2:
                 heart1.gameObject.SetActive(true);
                 heart2.gameObject.SetActive(true);
                 heart3.gameObject.SetActive(false);
                 break;

             case 1:
                 heart1.gameObject.SetActive(true);
                 heart2.gameObject.SetActive(false);
                 heart3.gameObject.SetActive(false);
                 break;

             case 0:
                 heart1.gameObject.SetActive(false);
                 heart2.gameObject.SetActive(false);
                 heart3.gameObject.SetActive(false);

                 Destroy(gameObject);

                 kalah.SetActive(true);
                 restart.gameObject.SetActive(true);
                 break;

         } */
        
         infoKoin.text = " " + koin.ToString();

         if (ulang == true)
         {
             transform.position = mulai;
             ulang = false;
         }

       /*  if ( nyawa <= 0)
         {
             Destroy(gameObject);

             kalah.SetActive(true);
             restart.gameObject.SetActive(true);
         } */
         if (koin >= 10)
         {
             menang.SetActive(true);
             //Time.timeScale = 0;
             btnNextLevel.gameObject.SetActive(true);
             Destroy(gameObject);
             
         } 



        tanah = Physics2D.OverlapCircle(deteksiTanah.position, jangkuan
            , targetPlayer);
        /*
        if ( tanah == false)
        {
           anim.SetBool("Terbang", true);
        }
        else
        {
         anim.SetBool("Terbang", false);
        } */

        if ( tanah == true)
        {
            anim.SetBool("lompat", false);
        }
        else
        {
            anim.SetBool("lompat", true);
            //loncatMogu.Play();
        }
        

        if (Input.GetKey(KeyCode.D) || tombolKanan == true)
        {
            anim.SetBool("lari", true);
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah = 1;
            

        }
        else if (Input.GetKey(KeyCode.A) || tombolKiri == true)
        {
            anim.SetBool("lari", true);
            transform.Translate(Vector2.left * kecepatan * Time.deltaTime);
            pindah = -1;
            
        }
        else
        {
            anim.SetBool("lari", false);
        }

      /*  if ( tanah == true && (Input.GetKey(KeyCode.Space)))
        {
            lompat.AddForce(new Vector2(0, kekuatanLompat));
        }*/

        if ( pindah > 0 && !balik)
        {
            balikBadan();
        }
        else if ( pindah < 0 && balik)
        {
            balikBadan();
        }

    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeleft--;
        }
        
    }

    



    void balikBadan()
    {
        balik = !balik;
        Vector3 karakter = transform.localScale;
        karakter.x *= -1;
        transform.localScale = karakter;
    }

    public void tekanKiri()
    {
        tombolKiri = true;
        //jalanMogu.Play();
    }

    public void lepasKiri()
    {
        tombolKiri = false;
        
    }

    public void tekanKanan()
    {
        tombolKanan = true;
        //jalanMogu.Play();
    }

    public void lepasKanan()
    {
        tombolKanan = false;
        
    }

    public void loncat()
    {
        if (tanah == true )
        {
            lompat.AddForce(new Vector2(0, kekuatanLompat));
            loncatMogu.Play();
        }
    }

}
