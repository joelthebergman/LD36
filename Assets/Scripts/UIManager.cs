using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using joelthebergman;
public class UIManager : MonoBehaviour 
{
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Slider staminaBar;
    [SerializeField]
    private Slider hungerBar;
    [SerializeField]
    private Slider coldBar;
    [SerializeField]
    private AtlatlBoyController atlatlBoyController;

    void Update()
    {
        healthBar.value = atlatlBoyController.CurrentHealth;
        staminaBar.value = atlatlBoyController.CurrentStamina;
        hungerBar.value = atlatlBoyController.CurrentHunger;
        coldBar.value = atlatlBoyController.CurrentCold;
    }

    public void Setup()
    {
        healthBar.maxValue = atlatlBoyController.CurrentHealth;
        staminaBar.maxValue = atlatlBoyController.CurrentStamina;
        hungerBar.maxValue = atlatlBoyController.CurrentHunger;
        coldBar.maxValue = atlatlBoyController.CurrentCold;
    }

}
