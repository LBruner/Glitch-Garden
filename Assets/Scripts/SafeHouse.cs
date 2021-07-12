using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SafeHouse : MonoBehaviour
{
    [SerializeField] float PlayerHealth;
    [SerializeField] float BaseLife = 100;
    [SerializeField] [Range(0f, 10f)] float LoadingTime = 10f;

    [SerializeField] TextMeshProUGUI  PlayerHealthTxt;
    [SerializeField] GameObject WinLabel;
    [SerializeField] GameObject LoseLabel;
    [SerializeField] float WaitSeconds = 3f;
    [SerializeField] float TimeScale = 0;

    void Start()
    {
        Debug.Log(PlayerPrefsController.GetDifficulty());
        PlayerHealth = BaseLife - 50;
        WinLabel.SetActive(false);
        LoseLabel.SetActive(false);
        Time.timeScale = 1;

    }
    public void Damage(float damage)
    {
        PlayerHealth -= damage;
        if (PlayerHealth <= 0)
        {
            PlayerHealth = 0;
            LoseCondition();
        }
    }

    public IEnumerator HandleWinCondition()
    {
        if (WinLabel)
        {
            WinLabel.SetActive(true);
        }
        yield return new WaitForSeconds(WaitSeconds);
        SceneManager.LoadScene("Level Two");
    }

    public void LoseCondition()
    {
        LoseLabel.SetActive(true);
        StartCoroutine(DramaticLoadingScreen());
    }


    IEnumerator DramaticLoadingScreen()
    {
        yield return new WaitForSeconds(LoadingTime);
        SceneManager.LoadScene("Game Over");
    }   

    void Update()
    {
        PlayerHealthTxt.text = PlayerHealth.ToString();
        
    }
}
