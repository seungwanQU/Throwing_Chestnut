using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public Animator animator;
    public Slider healthSlider;
    public TextMeshProUGUI textHP;

    void Start()
    {
        UpdateHealthSlider();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            animator.SetBool("Death", true);
        }

        UpdateHealthSlider();
    }

    public void UpdateHealthSlider()
    {
        float decreaseHp = (float)currentHealth / (float)maxHealth;

        healthSlider.value = decreaseHp;

        if (currentHealth <= 0f)
        {
            textHP.text = $"0 / {maxHealth}";
        }
        else
        {
            textHP.text = $"{currentHealth} / {maxHealth}";
        }
    }
}
