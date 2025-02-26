using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Main_LogicScript : MonoBehaviour
{
    public GameObject titleScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public void openVisualNovel(string wantedScript)
    {
        gameManager.setVN_Script(wantedScript);
        SceneManager.LoadScene("Visual Novel", LoadSceneMode.Additive);
        titleScreen.SetActive(false);
    }



}


