using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    public void GameOver()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void ReloadGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
