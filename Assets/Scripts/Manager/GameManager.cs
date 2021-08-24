using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    
    [SerializeField] private GameObject heart1,heart2,heart3,heart4,heart5;

    [Header("LevelProgress")] 
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI nextLevelText;
    [SerializeField] private Image progressFillImage;
    [SerializeField] private int sceneOffset;
    
    
    private float health;

    public float MyHealth
    {
        get => health;
        set => health = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(true);
        heart5.SetActive(true);
        
        progressFillImage.fillAmount = 0f;
        SetLevelProgressText();
    }

    private void SetLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level + 1).ToString();
    }

    public void UpdateLevelProgress()
    {
         float val = 1f - ((float) LevelScript.Instance.EnemyInScene / LevelScript.Instance.TotalEnemies);
         progressFillImage.fillAmount = val;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (health == 5)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(true);
        }
        else if (health == 4)
        {
            heart5.SetActive(false);
        }else if (health == 3)
        {
            heart4.SetActive(false);
            heart5.SetActive(false);
        }else if (health == 2)
        {
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }else if (health == 1)
        {
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (health < 1)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
    }
    
  
}
