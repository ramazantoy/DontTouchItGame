using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ucak : MonoBehaviour
{
    public AudioSource ucaksesyonetim;
    public GameObject cha;
    bool gg = false;
    void Start()
    {
     ucaksesyonetim = GetComponent<AudioSource>();
        ucaksesyonetim.Pause();
        InvokeRepeating("konumhesapla", 120f, 40f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 5f * Time.deltaTime*KarakterKontrol.sayac3);
        if (gameObject.transform.position.x - cha.gameObject.transform.position.x <= 25 && gg == false && gameObject.transform.position.x - cha.gameObject.transform.position.x >= -10)
        {
            ucaksesyonetim.Play();
            gg = true;
            Invoke("sustur", 6f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cha")
        {
            KarakterKontrol.gameover = true;

        }
    }
    void konumhesapla()
    {
        gameObject.transform.position = cha.gameObject.transform.position + new Vector3(40f, 2f, 0);
    }
    void sustur()
    {
        ucaksesyonetim.Pause();
        gg = false;
    }
}
