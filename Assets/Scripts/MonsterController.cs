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

    public float MonsterPower = 5f;
    public float attackInterval = 5f;

    public Slider healthSlider;
    public Slider StageBar;
    public TextMeshProUGUI textHP;

    public List<GameObject> monsterPrefabs = new List<GameObject>();

    private Animator animator;

    void Start()
    {
        UpdateHealthSlider();

        InvokeRepeating("MonsterAttack", attackInterval, attackInterval);
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

    public void MonsterAttack()
    {
        PlayerController playerController = FindFirstObjectByType<PlayerController>();

        if (playerController && currentHealth != 0)
        {
            if (animator.GetBool("Move") == true)
            {
                animator.SetBool("Move", false);
            }

            animator.SetTrigger("Attack");
            playerController.TakeDamage(MonsterPower);
        }

        animator.SetTrigger("Attack");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            currentHealth = maxHealth;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            if (animator.GetBool("Move") == true)
            {
                animator.SetBool("Move", false);
            }

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

                    this.MonsterPower += 5f;

                    UpdateHealthSlider();
                    IncreaseHealth();
                }
                break;
            }
        }

        StageBar.value += 0.35f;
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
