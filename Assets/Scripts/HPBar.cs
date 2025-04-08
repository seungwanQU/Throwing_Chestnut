using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider HPBarSlider;

    public float MaxHP = 100f;
    public float currentHP = 100f;

    private float decreaseHP;

    void Start()
    {
        decreaseHP = (float)currentHP / (float)MaxHP;
    }


    void Update()
    {
        decreaseHP = (float)currentHP / (float)MaxHP;
        HandleHP();
    }

    public void HandleHP()
    {
        this.HPBarSlider.GetComponent<Slider>().value = Mathf.Lerp(this.HPBarSlider.GetComponent<Slider>().value, decreaseHP, Time.deltaTime * 10f);
    }

    public void Damage(int n)
    {
        currentHP -= n;
        if (currentHP <= 0)
        {
            currentHP = 0;
        }
    }
}
