using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectTile : MonoBehaviour
{
    private float deleteTimer;
    // Start is called before the first frame update
    void Start()
    {
        deleteTimer = Time.time + 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(deleteTimer < Time.time) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
