using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class KarakterKontrol : MonoBehaviour

{
    // Ad Soyad: YUSUF SAY
    // Öğrenci Numarası: 232011036


    // Soru 1: Karakteri yön tuşları ile hareket ettiren kodu, HareketEt fonksiyonu içerisine yazınız.
    // Soru 2: Karakterin zıplamasını sağlaması beklenen Zipla metodu doğru bir şekilde çalışmıyor, koddaki hatayı düzeltin.
    // Soru 3: Karakterin 'Engel' tag'ine sahip objeye temas ettiğinde metin objesine "Oyun Bitti!" yazısını yazdırınız.
    // Soru 4: Karakterin 'Puan' tag'ine sahip objeye temas ettiğinde skoru 1 arttırınız ve metin objesine yazdırınız.

    // Not: Engel ve Puan nesnelerinin isTrigger özelliği aktiftir.


    public TMP_Text metin;
    private Rigidbody2D karakterRb;

    public float hiz = 5f;
    public float ziplamaGucu = 5f;

    public int skor = 0;

    void Start()
    {
        karakterRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HareketEt();
        Zipla();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Engel"))
        {
            metin.text = "Oyun Bitti!";
        }
        if (other.gameObject.CompareTag("Puan"))
        {
            skor++;
            metin.text = "Skor: " + skor;
        }
    }

    void HareketEt()
    {
        if (Input.GetKey(KeyCode.A))
        {
            karakterRb.AddForce(Vector2.left * (hiz * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            karakterRb.AddForce(Vector2.right * (hiz * Time.deltaTime));
        }
    }

    void Zipla()
    {
        // Space tuşuna basınca karakter zıplamalı ancak aşağıdaki kod hatalı.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            karakterRb.AddForce(Vector2.up * (ziplamaGucu / 2), ForceMode2D.Impulse);
        }
    }
}