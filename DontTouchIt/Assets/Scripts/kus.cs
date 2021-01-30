using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kus : MonoBehaviour
{
        public AudioSource kussesyonetim;
    public GameObject cha;
    bool gg = false;
    void Start()
    {
        kussesyonetim = GetComponent<AudioSource>();
        kussesyonetim.Pause();
        InvokeRepeating("konumhesapla",30f,15f);

    }


    void Update()
    {
        transform.Translate(Vector2.right * 3f * Time.deltaTime);
        if (gameObject.transform.position.x - cha.gameObject.transform.position.x <= 25 && gg==false && gameObject.transform.position.x-cha.gameObject.transform.position.x>=-10 )
        {
            kussesyonetim.Play();
            gg = true;
            Invoke("sustur",4f);
        } 

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="cha")
        {
            KarakterKontrol.gameover = true;
            
        }
       
    }
    void konumhesapla()
    {
        gameObject.transform.position = cha.gameObject.transform.position + new Vector3(40f, 1.5f, 0);
    }
    void sustur()
    {
        kussesyonetim.Pause();
        gg = false;
    } 
    
        
    
}
