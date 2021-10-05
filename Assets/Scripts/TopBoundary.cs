using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBoundary : MonoBehaviour
{
    Collider2D otherCollider;

    [SerializeField]
    GameObject topGameObject, botGameObject;
    Collider2D topCollider, botCollider;
    float top, bot, range;
    // Start is called before the first frame update
    void Start()
    {
        top = topGameObject.transform.position.y;
        bot = botGameObject.transform.position.y;

        range = top - bot;

        topCollider = topGameObject.GetComponent<Collider2D>();
        botCollider = botGameObject.GetComponent<Collider2D>();


    }


        private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform t = collision.transform;
            t.position = new Vector3(t.position.x, -3, t.position.z);
        }
        }


    // Update is called once per frame
    void Update()
    {
        
    }
}
