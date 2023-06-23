using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboUI : MonoBehaviour
{
    public TextMeshProUGUI comboText;
    
    void Start()
    {
        Score.instance.OnCombo.AddListener(UpdateCombo);
    }

    void UpdateCombo(int combo)
    {
        if (combo > 1)
        {
            comboText.text = "Combo x" + combo;
        }
        else
        {
            comboText.text = "";
        }
    }
}
