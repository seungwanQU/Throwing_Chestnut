using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

    private GameOverUI gameOverUI;

    void Start()
    {
        PlayerhealthSlider = PlayerhealthSlider.GetComponent<Slider>();
        gameOverUI = this.GetComponent<GameOverUI>();

        UpdateHealthSlider();
    }

    public IEnumerator TakeDamage(float monsterPower)
    {
        yield return new WaitForSeconds(2f); // 대기 시간

        PlayerCurrentHealth -= monsterPower;
        PlayerCurrentHealth = Mathf.Clamp(PlayerCurrentHealth, 0f, PlayerMaxHealth); // 체력이 음수가 되지 않도록 클램핑

        UpdateHealthSlider();

        if (PlayerCurrentHealth <= 0f)
        {
            gameOverUI.GameOverFadeIn();
        }
    }

    public void UpdateHealthSlider()
    {
        float decreaseHP = PlayerCurrentHealth / PlayerMaxHealth;

        PlayerhealthSlider.value = decreaseHP;
        PlayerHPText.text = $"{PlayerCurrentHealth} / {PlayerMaxHealth}";
    }
}
