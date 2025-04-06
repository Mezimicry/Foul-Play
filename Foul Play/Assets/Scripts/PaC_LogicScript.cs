using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaC_LogicScript : MonoBehaviour
{
    public GameObject PacScene;
    public GameObject winScreen;


    string lastTalked = "None";

    string[] basilDayone = { "Basil Original Offer", "Basil Repeated Offer" , "Basil Collection", "Turn In Right", "Turn In Wrong", "Basil Repeat 1", "Basil Repeat 2", "Basil Repeat 3", "Basil Repeat 4", "Basil Repeat 5", "Basil Repeat 6" };
    int basilScriptIndex = 0;
    string[] claytonDayone = { "Clayton Meeting", "Clayton Item", "Ungrateful Clayton", "Grateful Clayton", "Clayton Respeak" };
    int claytonScriptIndex = 0;
    string[] ogumoDayone = { "Ogumo Meeting", "Ogumo Respeak" };
    int ogumoScriptIndex = 0;
    string[] hydraDayone = { "Hydra Meeting", "Hydra Retalk" };
    int hydraScriptIndex = 0;
    string[] foulDayone = { "Foul Enters", "Foul Mentions Clayton", "Foul Mentions Ogumo", "Foul Mentions Basil", "Foul Mentions Hydra" };
    int foulScriptIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.getVN_checkExitCode() == true)
        {
            PacScene.SetActive(true);




            if (lastTalked == "Basil")
            {
                if (gameManager.getVN_exitCode() == "Quest Accepted")
                {
                    basilScriptIndex = 2;
                }

                else if (gameManager.getVN_exitCode() == "Correct Ingredients")
                {
                    gameManager.setBasilIngredientCollected("Correct");
                    basilScriptIndex = 3;
                }

                else if (gameManager.getVN_exitCode() == "Incorrect Ingredients")
                {
                    gameManager.setBasilIngredientCollected("Wrong");
                    basilScriptIndex = 4;
                }

                else if (gameManager.getVN_exitCode() == "Gave Right Ingredients")
                {
                    basilScriptIndex = 5;
                }

                else if (gameManager.getVN_exitCode() == "Gave Wrong Ingredients")
                {
                    basilScriptIndex = 5;
                }
            
            }

            else if (lastTalked == "Clayton")
            {
                if (gameManager.getVN_exitCode() == "Wanted Item")
                {
                    claytonScriptIndex = 3;
                }

                else if (gameManager.getVN_exitCode() == "Unwanted Item")
                {
                    claytonScriptIndex = 2;
                }
            }

            else if (lastTalked == "Foul")
            {
                if (gameManager.getVN_exitCode() == "Day One Ends")
                {
                    winScreen.SetActive(true);
                }
            }
        }
    }








    public void characterInteracted(string characterName)
    {
        if (characterName == "Clayton")
        {
            claytonInteraction();
        }
        else if (characterName == "Basil")
        {
            basilInteraction();
        }
        else if (characterName == "Ogumo")
        {
            ogumoInteraction();
        }
        else if (characterName == "Hydra")
        {
            hydraInteraction();
        }
        else if (characterName == "Foul")
        {
            foulInteraction();
        }



    }

    private void foulInteraction()
    {
        if (lastTalked == "Clayton")
        {
            foulScriptIndex = 1; 
        }
        else if (lastTalked == "Ogumo")
        {
            foulScriptIndex = 2;
        }
        else if (lastTalked == "Basil")
        {
            foulScriptIndex = 3;
        }
        else if (lastTalked == "Hydra")
        {
            foulScriptIndex = 4;
        }

        lastTalked = "Foul";

        gameManager.setMain_wantedMusic("FoulIsTalking");

        PacScene.SetActive(false);
        gameManager.setVN_Script(foulDayone[foulScriptIndex]);
        SceneManager.LoadScene("Visual Novel", LoadSceneMode.Additive);
    }

    private void hydraInteraction()
    {

        lastTalked = "Hydra";

        PacScene.SetActive(false);
        gameManager.setVN_Script(hydraDayone[hydraScriptIndex]);
        SceneManager.LoadScene("Visual Novel", LoadSceneMode.Additive);

        if (!(hydraScriptIndex == 1))
        {
            hydraScriptIndex += 1;
        }
    }

    private void ogumoInteraction()
    {
        lastTalked = "Ogumo";

        PacScene.SetActive(false);
        gameManager.setVN_Script(ogumoDayone[ogumoScriptIndex]);
        SceneManager.LoadScene("Visual Novel", LoadSceneMode.Additive);

        if (!(ogumoScriptIndex == 1))
        {
            ogumoScriptIndex += 1;
        }
    }

    private void basilInteraction()
    {
        lastTalked = "Basil";

        PacScene.SetActive(false);
        gameManager.setVN_Script(basilDayone[basilScriptIndex]);
        SceneManager.LoadScene("Visual Novel", LoadSceneMode.Additive);

        if (!(basilScriptIndex == 1 | basilScriptIndex == 2 | basilScriptIndex == 3 | basilScriptIndex == 4 | basilScriptIndex == 10))
        {
            basilScriptIndex += 1;
        }
    }

    private void claytonInteraction()
    {
        lastTalked = "Clayton";

        PacScene.SetActive(false);
        gameManager.setVN_Script(claytonDayone[claytonScriptIndex]);
        SceneManager.LoadScene("Visual Novel", LoadSceneMode.Additive);

        if (!(claytonScriptIndex == 1 | claytonScriptIndex == 2 | claytonScriptIndex == 4))
        {
            claytonScriptIndex += 1;
        }

        if (claytonScriptIndex == 2)
        {
            claytonScriptIndex = 1;
        }


    }
}
