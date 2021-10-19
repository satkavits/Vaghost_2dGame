using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLvl1 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level1");

    }
}
