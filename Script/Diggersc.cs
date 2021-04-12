using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Diggersc : MonoBehaviour
{
    public static Diggersc intance;
    public GameObject Digger;
    public bool down = false;
    public int greywallvalue = 416;
    public int endgreyvalue;
    public bool gameover = false;
    public Vector3 startpos;


    public void Start()
    {
        startpos = transform.position;
        endgreyvalue = greywallvalue;
        gameover = false;
    }
    public void Awake()
    {
        if (intance == null)
        {
            intance = this;
        }
    }
    #region Region DiggerMove
    public void DiggerDown()
    {
        
        Digger.transform.Translate(0, -0.1f, 0 * Time.deltaTime);
        
        
    }
    #endregion
    #region Region DiggerUp
    /*public void DiggerUp()
    {
        Digger.transform.Translate(0, 0.01f, 0 * Time.deltaTime);
    }*/
    #endregion
    #region Region Startposition
    public void Startposition()
    {
        transform.position = startpos;
    }
    #endregion

    void Update()
    {
        DiggerDown();
        if (endgreyvalue < greywallvalue)
        {
            Debug.Log("rs");
            gameover = true;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "greywall")
        {
            
            Destroy(collision.gameObject);
            endgreyvalue = greywallvalue - 1;
        }
        else if (collision.gameObject.tag == "plane")
        {
            Digger.transform.Translate(0, 3.5f, 0 * Time.deltaTime);
        }
    }
}
