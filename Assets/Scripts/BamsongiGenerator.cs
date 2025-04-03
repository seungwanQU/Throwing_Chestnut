using TMPro;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;

    private GameObject ScoreText;
    private int score = 0;

    void Start()
    {
        this.ScoreText = GameObject.Find("ScoreText");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDirection = ray.direction;
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDirection.normalized * 2000);
        }
    }

    public void ScorePlus(int n)
    {
        score += n;
        this.ScoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score;
    }
}
