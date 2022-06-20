using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Declaration d'une variable global
    public static int numberOfCOins;
    public static int currentHealth = 100;
    public static bool gameOver;

    public Slider healthBar;

    // Declaration d'intance pour acceder au composant d'unity
    public TextMeshProUGUI numberOfCoinsText;

    void Start()
    {
        numberOfCOins = 0;
        gameOver = false;
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
        }
    }
}
