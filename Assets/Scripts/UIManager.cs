using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    private GameObject gameOverScreen;
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
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("Scene");
    }
}
