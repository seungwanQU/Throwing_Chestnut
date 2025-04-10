using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // MovementCharactor movementCharactor;
    // KeyCode jumpKeyCode = KeyCode.Space;

    // void Start()
    // {
    //     movementCharactor = GetComponent<MovementCharactor>();
    // }

    // void Update()
    // {
    //     float x = Input.GetAxisRaw("Horizontal");
    //     float z = Input.GetAxisRaw("Vertical");

    //     movementCharactor.MoveTo(new Vector3(x, 0, z).normalized);

    //     if (Input.GetKeyDown(jumpKeyCode))
    //     {
    //         movementCharactor.JumpTo();
    //     }
    // }

    public Slider PlayerhealthSlider;    // 체력바 슬라이더
    public TextMeshProUGUI PlayerHPText; // 체력바 텍스트

    private float PlayerMaxHealth = 100f;     // 최대 체력
    private float PlayerCurrentHealth = 100f; // 현재 체력

    void Start()
    {
        PlayerhealthSlider = PlayerhealthSlider.GetComponent<Slider>();
        UpdateHealthSlider();
    }

    public void TakeDamage(float monsterPower)
    {
        PlayerCurrentHealth -= monsterPower;
        PlayerCurrentHealth = Mathf.Clamp(PlayerCurrentHealth, 0f, PlayerMaxHealth); // 체력이 음수가 되지 않도록 클램핑

        UpdateHealthSlider();

        if (PlayerCurrentHealth <= 0f)
        {
            // 플레이어가 사망한 경우 처리할 내용 추가
        }
    }

    public void UpdateHealthSlider()
    {
        float decreaseHP = PlayerCurrentHealth / PlayerMaxHealth;

        PlayerhealthSlider.value = decreaseHP;
        PlayerHPText.text = $"{PlayerCurrentHealth} / {PlayerMaxHealth}";
    }
}
