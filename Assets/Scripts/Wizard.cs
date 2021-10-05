using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public float health = 100;

    Rigidbody2D rb;

    [SerializeField]
    SpriteRenderer[] sRenderer;
    MaterialPropertyBlock[] matBlocks;
    Color origColor;
    public float speed;

    //Collider2D collider1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        matBlocks = new MaterialPropertyBlock[sRenderer.Length];
        for (int i = 0; i < sRenderer.Length; i++)
        {
            matBlocks[i] = new MaterialPropertyBlock();
            sRenderer[i].GetPropertyBlock(matBlocks[i]);
        }        
        origColor = sRenderer[0].material.GetColor("_ColorHDR");
        //collider1 = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateParams();
    }

    void UpdateParams()
    {
        //sRenderer.GetPropertyBlock(matBlock);
        var intensityFactor = Mathf.Lerp(0, 3.5f, health / 100);
        //
        for (int i = 0; i < sRenderer.Length; i++)
        {
            matBlocks[i].SetColor("_ColorHDR", origColor * intensityFactor);
            sRenderer[i].SetPropertyBlock(matBlocks[i]);
        }
    }


    IEnumerator TakeDamage(int damage)
    {
        
        float prev = health;
        float newHealth = health + damage;
        float i = Time.deltaTime * speed;



        //bool g = true;
        while (health !=newHealth)
        {
            health = Mathf.MoveTowards(health, newHealth, i);
            Debug.Log(health);
            yield return null;
        }


    }

    IEnumerator DeathMove()
    {
        float x = this.transform.position.x - 8;

        while(x != transform.position.x)
        {
            float t = 0;
            t += Time.deltaTime;
            this.transform.position = new Vector3 (Mathf.MoveTowards(this.transform.position.x, x, Mathf.SmoothStep(0,1000, t) * Time.deltaTime), transform.position.y, transform.position.z);
            yield return null;
        }

        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Attacker")
        {
            StartCoroutine ( TakeDamage(-10));
            if(health <= -1)
            {
                rb.isKinematic = true;
                StartCoroutine(DeathMove());
            }

        }

        if (collision.transform.tag == "Light")
        {
            StartCoroutine(TakeDamage(10));


            if (health >= 100)
            {
                health = 100;
            }
        }
    }
}
