using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform t= collision.transform;
            t.position = new Vector3(t.position.x, 3, t.position.z);
        }
    }
}
