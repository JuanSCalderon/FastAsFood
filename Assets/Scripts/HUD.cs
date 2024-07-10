using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI candyText;
    public static int candyTotal = 0;

    void Update()
    {
        candyText.text = "Candy: " ;
    }
    public static void ResetCandyCount()
    {
        candyTotal = 0;
    }
}