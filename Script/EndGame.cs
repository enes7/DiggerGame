using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject finisİmg;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "plane")
        {
            if (Diggersc.intance.gameover == false)
            {
                finisİmg.gameObject.SetActive(true);
                Debug.Log("bitti");
            }
            
        }
    }
}
