using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    //CACHED INTERNAL REFERENCES
    TextMeshProUGUI GoldText;

    public void Awake()
    {
        GoldText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDisplay(int gold)
    {
        if(gold < 0)
        {
            GoldText.text = $"Gold: 0";
        }
        else
        {
            GoldText.text = $"Gold: {gold}";
        }
    }
}