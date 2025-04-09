using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MonsterController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float delay = 1f;   // 몬스터 destroy 후 대기 시간

    public Slider healthSlider;
    public Slider healthSliderCopy;
    public Slider StageBar;
    public Slider StageBarCopy;
    public TextMeshProUGUI textHP;
    public TextMeshProUGUI textHPCopy;

    public GameObject monsterPosition;
    public List<GameObject> monsterPrefabs = new List<GameObject>();

    private Animator animator;

    void Start()
    {
        healthSliderCopy = this.healthSlider;
        StageBarCopy = this.StageBar;
        textHPCopy = this.textHP;

        UpdateHealthSlider();
    }

    void Update()
    {
        foreach (var monster in monsterPrefabs)
        {
            if (monster.activeSelf == true)
            {
                animator = monster.GetComponent<Animator>();
                break;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            currentHealth = maxHealth;

            animator.SetBool("Death", true);

            Invoke("SpawnNextMonster", delay);
        }

        UpdateHealthSlider();
    }

    private void SpawnNextMonster()
    {
        for (int i = 0; i < monsterPrefabs.Count; i++)
        {
            if (monsterPrefabs[i].activeSelf == true)
            {
                monsterPrefabs[i].SetActive(false);

                if (i + 1 < monsterPrefabs.Count)
                {
                    monsterPrefabs[i + 1].SetActive(true);

                    this.healthSlider = this.healthSliderCopy;
                    this.StageBar = this.StageBarCopy;
                    this.textHP = this.textHPCopy;

                    UpdateHealthSlider();
                    IncreaseHealth();
                }
                break;
            }
        }

        StageBar.value += 0.33f;
        if (StageBarCopy.value >= 1f)
        {
            StageBarCopy.value = 0f;
        }
    }

    public void UpdateHealthSlider()
    {
        float decreaseHp = (float)currentHealth / (float)maxHealth;

        healthSlider.value = decreaseHp;
        textHP.text = $"{currentHealth} / {maxHealth}";
    }

    public void IncreaseHealth()
    {
        maxHealth = maxHealth * 2.0f;

        if (currentHealth != maxHealth)
        {
            currentHealth = maxHealth;
            UpdateHealthSlider();
        }
    }
}
