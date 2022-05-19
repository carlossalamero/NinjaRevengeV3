using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private SFXmanager sfxmanager;
    private BGMmanager bgmmanager;
    public bool misplaying = true;
    public Text enemiestext;
    public Text lifetext;
    int Contenemies;
    //int Contlife;
    // int Vidas;
    

    // Start is called before the first frame update
    void Awake()
    {
        
        sfxmanager = GameObject.Find("SFXmanager").GetComponent<SFXmanager>();
        bgmmanager = GameObject.Find("BGMmanager").GetComponent<BGMmanager>();

    }

    // Update is called once per frame
    public void Muerte()
    {        
        misplaying = false;
        bgmmanager.STOPBGM();
        sfxmanager.DeathSound();
        SceneManager.LoadScene(2);
        
        /*Contlife--;
        Debug.Log("Tienes "+Contlife+" vidas");
        lifetext.text = "Enemies: " + Vidas;
        
        
        if(Contlife > 0)
        {

          SceneManager.LoadScene(2);  


        }
        else{

          SceneManager.LoadScene(0); 

        }*/
    }

    public void Muerteninja()
    {        
        bgmmanager.STOPBGM();
        sfxmanager.NinjaSound();
        bgmmanager.StartBGM();
        Contenemies++;
        Debug.Log("Tienes "+Contenemies+" bajas confirmadas");
        enemiestext.text = "Enemies: " + Contenemies;
    }

    public void Cogerantorcha(GameObject Antorcha)
    {

         BoxCollider2D AntorchaCollider;
        
        AntorchaCollider = Antorcha.GetComponent<BoxCollider2D>();
        
        SceneManager.LoadScene(0);
        

    }   

    public void Win()
    {

        sfxmanager.levelSound();

    } 

    
}


