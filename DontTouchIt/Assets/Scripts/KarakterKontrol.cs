using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarakterKontrol : MonoBehaviour
{
    public GameObject kus;
    public GameObject ucak;
    Rigidbody2D r;
    Rigidbody r2;
    bool zipla;
    bool zipla2x;
    bool SonEkle = true;
    bool BasEkle = false;
    //bool hava;
    public GameObject[] bulutlar = new GameObject[12];
    int sayac;
   int sayac2 = 0;
    public float jumpHeight;
    Animator a;
   public static bool gameover;
   public static float sayac3 = 1;
    bool bulut3 = false;
    bool bulut8 = false;
    public GameObject bitisanim;
    public GameObject menubutton;
    public GameObject tryagainbutton;
    public AudioSource backgroudsound;
    public AudioClip bitisses;
    public AudioClip Ziplamasesi;
    float skor = 0;
    float topskor = 0;
    public Text t;
    public Text t2;
    public Text t3;


    void Start()
    {
      topskor= PlayerPrefs.GetFloat("topskor");
        r = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
        gameover = false;
        kus.gameObject.SetActive(false);
        ucak.gameObject.SetActive(false);
        kusolustur();
        ucakolustur();
        backgroudsound = GetComponent<AudioSource>();
        t2.gameObject.SetActive(false);
        t3.gameObject.SetActive(false);
        sayac3 = 1;
        //hava = false; 

    }
    void zıpla()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && zipla == true)
        {
            a.SetTrigger("Zıpla");
          //  hava = true;
            r.AddForce(Vector2.up * jumpHeight);
            backgroudsound.PlayOneShot(Ziplamasesi);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && zipla2x == true)
        {
            r.velocity = Vector3.zero;
        r.AddForce(Vector2.up *200f);
            zipla2x = false;
            // backgroudsound.PlayOneShot(Ziplamasesi);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bulut")
        {
           //   Debug.Log("zıplayabilir");
            zipla = true;
            zipla2x = false;
        }
        if (collision.gameObject.name == "Bulut3")
        {
            SonEkle = true;
            BasEkle = false;
            Invoke("BulutDizayn", 0.4f);
            bulut3 = true;
            bulut8 = false;
        }
        if (collision.gameObject.name == "Bulut4" && bulut3==false)
        {
            SonEkle = true;
            BasEkle = false;
            Invoke("BulutDizayn", 0.4f);
            bulut8 = false;
        }
        if (collision.gameObject.name == "Bulut8")
        {
            SonEkle = false;
            BasEkle = true;
            Invoke("BulutDizayn", 0.4f);
            bulut8 = true;
            bulut3 = false;

        }
        if (collision.gameObject.name == "Bulut9" && bulut8==false)
        {
            SonEkle = false;
            BasEkle = true;
            Invoke("BulutDizayn", 0.4f);
            bulut3 = false;
        }
        if (collision.gameObject.name == "yanma")
        {
            gameover = true;
            
            
       //     Debug.Log("gg");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bulut")
        {
           //   Debug.Log("zıplayamaz");
            zipla = false;
            zipla2x = true;
        }
    }

    [System.Obsolete]
    void BulutDizayn()
    {
        if (SonEkle == true)
        {
            sayac = 6;
            while (sayac < 12)
            {
                int durum = Random.RandomRange(0, 100);
                if (durum % 2 == 0)//Zıpla
                {
                    if (bulutlar[sayac-1].gameObject.transform.position.y +1>= -0.5f)
                    {
                        bulutlar[sayac].gameObject.transform.position = bulutlar[sayac - 1].gameObject.transform.position + new Vector3(7.5f, 0, 0);
                    }
                    else
                    {
                        bulutlar[sayac].gameObject.transform.position = bulutlar[sayac - 1].gameObject.transform.position + new Vector3(7.5f, 1f, 0);
                    }
                
                }
                else
                {
                    if(bulutlar[sayac-1].gameObject.transform.position.y-1f<= -4f)
                    {
                        bulutlar[sayac].gameObject.transform.position = bulutlar[sayac - 1].gameObject.transform.position + new Vector3(7.5f, 0, 0);
                    }
                    else
                    {
                        bulutlar[sayac].gameObject.transform.position = bulutlar[sayac - 1].gameObject.transform.position + new Vector3(7.5f, -1f, 0);
                    }
         
                }
                sayac++;
            }
        }
        if (BasEkle == true)
        {
            sayac2 = 1;
            int durum = Random.RandomRange(0, 100);
            if (durum % 2 == 0)//Zıpla
            {
                if (bulutlar[11].gameObject.transform.position.y +1f >= -0.5f)
                {
                    bulutlar[0].gameObject.transform.position = bulutlar[11].gameObject.transform.position + new Vector3(7.5f, 0f, 0);
                }
                else
                {
                    bulutlar[0].gameObject.transform.position = bulutlar[11].gameObject.transform.position + new Vector3(7.5f, 1f, 0);
                }       
            }
            else
            {
                if (bulutlar[11].gameObject.transform.position.y -1f <= -4f)
                {
                    bulutlar[0].gameObject.transform.position = bulutlar[11].gameObject.transform.position + new Vector3(7.5f, 0, 0);
                }
                else
                {
                    bulutlar[0].gameObject.transform.position = bulutlar[11].gameObject.transform.position + new Vector3(7.5f, -1f, 0);
                }
                
            }
            while (sayac2 < 7)
            {
                durum = Random.RandomRange(0, 100);
                if (durum % 2 == 0)//Zıpla
                {
                    if (bulutlar[sayac2-1].gameObject.transform.position.y+ 1f>=-0.5f)
                    {
                        bulutlar[sayac2].gameObject.transform.position = bulutlar[sayac2 - 1].gameObject.transform.position + new Vector3(7.5f, 0f, 0);
                    }
                    else
                    {
                        bulutlar[sayac2].gameObject.transform.position = bulutlar[sayac2 - 1].gameObject.transform.position + new Vector3(7.5f, 1f, 0);
                    }
   
                }
                else
                {
                    if (bulutlar[sayac2-1].gameObject.transform.position.y-1f<= -4f)
                    {
                        bulutlar[sayac2].gameObject.transform.position = bulutlar[sayac2 - 1].gameObject.transform.position + new Vector3(7.5f, 0f, 0);
                    }
                    else
                    {
                        bulutlar[sayac2].gameObject.transform.position = bulutlar[sayac2 - 1].gameObject.transform.position + new Vector3(7.5f, -1f, 0);
                    }
         
                }
                sayac2++;
            }
        }
        sayac3 += 0.05f;

    }
    // Update is called once per frame
    void Update()
    {
        zıpla();
        transform.Translate(Vector2.right * 3f * Time.deltaTime*sayac3);
        skor += sayac3 * 3f * Time.deltaTime;
       // skor= Mathf.Round(skor);
       // Debug.Log(skor);
        bitir();
        t.text = "" + skor;
       
    }
    void kusolustur()
    {
        kus.gameObject.SetActive(true);
    }
    void ucakolustur()
    {
        ucak.gameObject.SetActive(true);
    }
    void bitir()
    {
        if (gameover == true)
        {
            kus.SetActive(false);
            ucak.SetActive(false);
            bitisanim.SetActive(true);
            menubutton.SetActive(true);
            tryagainbutton.SetActive(true);
            t2.gameObject.SetActive(true);
            t3.gameObject.SetActive(true);
            backgroudsound.Pause();
            AudioSource.PlayClipAtPoint(bitisses, gameObject.transform.position);
            if (topskor < skor)
            {
                topskor = skor;
                PlayerPrefs.SetFloat("topskor", topskor);
            }
            t2.text = "" + PlayerPrefs.GetFloat("topskor"); 
            gameObject.SetActive(false);
        }
    }
}
