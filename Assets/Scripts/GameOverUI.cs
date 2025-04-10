using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public Image backgroundImage;
    public Image buttonImage;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI buttonText;

    public float fadeDuration = 1f; // 페이드 인 시간

    void Start()
    {
        backgroundImage = backgroundImage.GetComponent<Image>();
        buttonImage = buttonImage.GetComponent<Image>();
        gameOverText = gameOverText.GetComponent<TextMeshProUGUI>();

        backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0f);
        buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0f);
        gameOverText.color = new Color(gameOverText.color.r, gameOverText.color.g, gameOverText.color.b, 0f);
        buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, 0f);
    }

    public void GameOverFadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float backAlpha = Mathf.Lerp(0f, 0.85f, elapsedTime / fadeDuration);
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, backAlpha);
            buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, alpha);
            gameOverText.color = new Color(gameOverText.color.r, gameOverText.color.g, gameOverText.color.b, alpha);
            buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, alpha);

            elapsedTime += Time.deltaTime;
        }
    }

    public void RestartGame()
    {
        // 현재 씬을 다시 로드하여 게임을 재시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
