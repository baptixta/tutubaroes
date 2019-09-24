using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public float oceanHealth = 100.0f;
    public float oceanHealthDecrease = 1.0f;
    //A velocidade que o slider atualizar o valor (transição usando intepolação)
    public float healthUpdateSpeed = 3.0f;
    public Slider healthSlider;
    //Score
    public int score;
    public Text scoreText;
    //Instáncia estática
    public static UI instance;

    private void Awake()
    {
        //Referenciando instância estática
        instance = this;
    }

    void Update ()
    {
        //Atualizando valor do slider
        healthSlider.value = Mathf.Lerp(healthSlider.value, oceanHealth, healthUpdateSpeed * Time.deltaTime);
        //Diminuindo o valor da saúde automaticamente
        oceanHealth -= Time.deltaTime * oceanHealthDecrease;
        //Atualizando o valor do scoreText
        scoreText.text = score.ToString();
        Death();
    }

    public void AddHealth (float amount)
    {
        oceanHealth += amount;
    }

    public void AddScore (int amount)
    {
        score += amount;
    }

    public void Death()
    {
        if (oceanHealth <= -12)
        {
            SceneManager.LoadScene("Game");
        }
    }
}