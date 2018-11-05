using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathStarHPController : MonoBehaviour
{
    public Text HPText;
    private int HPvalue;

    private void Start() {
        HPText.text = "";    
        HPvalue = 15;
    }

    public void DamageTaken(int dmg) {
        HPvalue -= dmg;
        UpdateHealth();
    }

    public void UpdateHealth() {
        HPText.text = "boss hp: " + HPvalue;
    }

    public int GetHP() {
        return HPvalue;
    }
}
