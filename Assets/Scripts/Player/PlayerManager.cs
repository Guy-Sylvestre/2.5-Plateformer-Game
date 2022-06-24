using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Declaration d'attribut global
    public static int numberOfCOins;
    public static int currentHealth = 100;
    public static bool gameOver;
    public static bool winLevel;

    // Declaration d'objet
    public GameObject gameOverPanel;
    public Slider healthBar;
    public TextMeshProUGUI numberOfCoinsText;

    // Declaration d'objet
    public float timer = 0;

    void Start()
    {
        numberOfCOins = 0;
        gameOver = winLevel = false;
    }

    void Update()
    {

        // Utilisation de TMPro
        numberOfCoinsText.text = "coins: " + numberOfCOins;

        // Update the slider value
        healthBar.value = currentHealth;

        // game over
        if (currentHealth < 0)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
            currentHealth = 100;
        }

        if (FindObjectsOfType<Enemy>().Length == 0)
        {
            // Win Level1
            winLevel = true;
            timer += Time.deltaTime;

            if (timer > 25)
            {
                int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

                if (nextLevel == 4)
                {
                    SceneManager.LoadScene(0);
                }
                PlayerPrefs.SetInt("ReachedLevel", nextLevel);
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
