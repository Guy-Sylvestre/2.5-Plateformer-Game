using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Declaration d'une variable global
    public static int numberOfCOins;
    public TextMeshProUGUI numberOfCoinsText;

    void Start()
    {
        numberOfCOins = 0;
    }

    void Update()
    {
        numberOfCoinsText.text = "coins: " + numberOfCOins;
    }
}
