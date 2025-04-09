using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MonsterController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float delay = 3f;   // 몬스터 destroy 후 대기 시간

    public Slider healthSlider;
    public Slider healthSliderCopy;
    public TextMeshProUGUI textHP;
    public TextMeshProUGUI textHPCopy;

    public GameObject monsterPosition;
    public GameObject currentMonsterPrefab;
    public GameObject nextMonsterPrefab;

    private Animator animator;

    void Start()
    {
        healthSliderCopy = this.healthSlider;
        textHPCopy = this.textHP;

        UpdateHealthSlider();
    }

    void Update()
    {
        animator = currentMonsterPrefab.activeSelf == true
                 ? currentMonsterPrefab.GetComponent<Animator>()
                 : nextMonsterPrefab.GetComponent<Animator>();
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
        if (nextMonsterPrefab.activeSelf == false)
        {
            // Instantiate(nextMonsterPrefab, monsterPosition.transform.position, monsterPosition.transform.rotation);
            nextMonsterPrefab.SetActive(true);
            this.GetComponent<MonsterController>().healthSlider = this.healthSliderCopy;
            this.GetComponent<MonsterController>().textHP = this.textHPCopy;
            this.GetComponent<MonsterController>().maxHealth = this.maxHealth;
            this.GetComponent<MonsterController>().currentHealth = this.currentHealth;
            this.GetComponent<MonsterController>().UpdateHealthSlider();
            this.GetComponent<MonsterController>().IncreaseHealth();
        }

        currentMonsterPrefab.SetActive(false);
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
