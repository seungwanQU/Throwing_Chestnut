using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public GameObject BamsongiGenerator;
    public GameObject Distance;

    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction);
    }

    void Start()
    {
        this.BamsongiGenerator = GameObject.Find("BamsongiGenerator");
        this.Distance = GameObject.Find("Distance");
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();

        Vector2 p1 = this.transform.position;
        Vector2 p2 = this.Distance.transform.position;

        float d = (p1 - p2).magnitude;         // 벡터의 길이 반환
        int n = Mathf.CeilToInt(10 - d * 5);   // 올림 처리

        if (other.gameObject.tag == "Monster")
        {
            this.BamsongiGenerator.GetComponent<BamsongiGenerator>().ScorePlus(n);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
