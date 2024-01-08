using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TextMeshProUGUI secondsSurvivedUI;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<player>().OnPlayerDeath += OnGameOver;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
