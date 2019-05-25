using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStat : MonoBehaviour {
    private MainPlayer player;
    private Slider HealthBar;
    private Slider StaminaBar;
    private Slider EnergyBar;
    private Slider PowBar;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
        HealthBar = GameObject.FindGameObjectWithTag("HP").GetComponent<Slider>();
        StaminaBar = GameObject.FindGameObjectWithTag("Stamina").GetComponent<Slider>();
        EnergyBar = GameObject.FindGameObjectWithTag("Energy").GetComponent<Slider>();
        PowBar = GameObject.FindGameObjectWithTag("Pow").GetComponent<Slider>();       
    }
    private void Update()
    {
        HealthBar.value = player.CurrentHP;
        StaminaBar.value = player.CurrentStamina;
        EnergyBar.value = player.CurrentEnergy;
        PowBar.value = player.CurrentPow;
    }


}
    