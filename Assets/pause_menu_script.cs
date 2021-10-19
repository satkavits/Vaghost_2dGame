using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu_script : MonoBehaviour
{
    public Transform Boss;
    Scene cScene;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject finishLevel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private bool isPaused;
    [SerializeField] private bool isFinished;

    public void BackToMain()
    {
        SceneManager.LoadScene("menu");
        
    }

    public void RestartLevel1()
    {
        SceneManager.LoadScene("Level1");

    }

    public void RestartLevel2()
    {
        SceneManager.LoadScene("Level2");

    }
    


    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            isPaused = !isPaused;
            
        }

        if (isPaused)
        {
            
            ActivateMenu();
        }
        else 
        {

            DeactivateMenu();
        }
        if (Boss.GetComponent<BossHealth>().health<=0)
        {
            
            StartCoroutine(Finishlevel());

        }
        if (isFinished)
        {
            AudioListener.pause = true;
            Time.timeScale = 0;
        }
    
    
    }

    public void resume() 
    {
        isPaused = false;
    
    }

    void ActivateMenu() 
    {
        pauseMenuUI.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;

    }

    void DeactivateMenu()
    {
        pauseMenuUI.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1;
    }

    IEnumerator Finishlevel()
    {

        cScene = SceneManager.GetActiveScene();
        yield return new WaitForSeconds(4);
        if (cScene.name=="Level1")
            SceneManager.LoadScene("intro3");
        else if (cScene.name=="Level2")
            SceneManager.LoadScene("ending");


    }

    void endmenu()
    {
        finishLevel.SetActive(true);
        isFinished = true;
    }

    public void controls()
    {
        controlsPanel.SetActive(true);

    }

    public void nocontrols()
    {
        controlsPanel.SetActive(false);
    }
   

}
