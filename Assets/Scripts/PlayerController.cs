using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float strength = 1;
    public AudioSource wingAudioSource;
    public AudioSource hitAudioSource;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(new Vector2(0, strength), ForceMode2D.Impulse);
            rb.velocity = Vector2.up * strength;
            if(Time.timeScale != 0)
            {
                wingAudioSource.Play();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        hitAudioSource.Play();
        GameManager.Instance.OnGameOver();
    }

    private void xd(Collider2D col)
    {
        if(col.gameObject.name == "coin")
        {
            GameManager.Instance.UpdateScore();
            Destroy(col.gameObject);
        }
    }
}
