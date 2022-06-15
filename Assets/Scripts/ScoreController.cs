using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text leftScore;
    public Text rightScore;

    public ScoreManager manager;

    void Update()
    {
        leftScore.text = manager.leftScore.ToString();
        rightScore.text = manager.rightScore.ToString();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
