using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class Joystickmove : MonoBehaviour
{
    public static Joystickmove instance;
    public bool sag, sol; //down(digger ın aşağı inmesini sağlayan diğer yol için değişken);
    public float turnSpeed = 30f; //apk da joystick hareketinde bu değeri 50 aldığım için daha çok dönme hareketi yapıyor
    public GameObject Digger, btn1, btn2, restartbtn, lvlendwall, gameoverImg;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Update()
    {

        Swerwe();
    }
    #region Region Swerwe
    public void Swerwe()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
            Digger.transform.Translate(-0.1f, 0, 0 * 1);
            //transform.position = Vector3.Lerp(transform.position, solgit, 20 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Digger.transform.Translate(0.1f, 0, 0 * Time.deltaTime);
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position, saggit, 20 * Time.deltaTime);
        }
        
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
            if (parmak.deltaPosition.x > 0)
            {
                sag = true;
                sol = false;
            }

            else if (parmak.deltaPosition.x < 0)
            {
                sag = false;
                sol = true;
            }

            


            if (sag == true)
            {
                transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
                Digger.transform.Translate(0.01f, 0, 0 * Time.deltaTime);
            }
            else if (sol == true)
            {
                Digger.transform.Translate(-0.01f, 0, 0 * Time.deltaTime);
                transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
            }
            
        }
    }
    #endregion

    #region Region Buttons
    public void Buttons()
    {
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);
        lvlendwall.gameObject.SetActive(true);
        //Digger.gameObject.SetActive(false);
        if (Diggersc.intance.gameover == true)
        {
            Debug.Log("girdi");
            gameoverImg.gameObject.SetActive(true);
            restartbtn.gameObject.SetActive(true);
        }
    }
    #endregion

    #region Region Restart
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    #endregion

    

}
