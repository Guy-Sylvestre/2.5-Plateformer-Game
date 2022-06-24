using UnityEngine.UI;
using UnityEngine;

public class LevelsUnlock : MonoBehaviour
{
    // Declaration d'attribut
    public Button[] leveButtons;

    void Start()
    {
        foreach (Button b in leveButtons)
        {
            b.interactable = false;

            int reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);

            for (int i = 0; i < reachedLevel; i++)
            {
                leveButtons[i].interactable = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
