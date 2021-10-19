using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("menu");

    }
}
