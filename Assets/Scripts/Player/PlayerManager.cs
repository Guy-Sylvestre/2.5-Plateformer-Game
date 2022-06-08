using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Declaration d'une variable global
    public static int numberOfCOins;

    // Declaration pour acceder au composant d'unity
    public TextMeshProUGUI numberOfCoinsText;

    void Start()
    {
        numberOfCOins = 0;
    }

    void Update()
    {
        // Utilisation de TMPro
        numberOfCoinsText.text = "coins: " + numberOfCOins;
    }
}
