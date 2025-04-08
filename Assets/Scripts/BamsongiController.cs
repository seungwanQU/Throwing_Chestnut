using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public GameObject BamsongiGenerator;
    public GameObject HeadPoint;
    public GameObject HPBarController;

    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction);
    }

    void Start()
    {
        this.BamsongiGenerator = GameObject.Find("BamsongiGenerator");
        this.HeadPoint = GameObject.Find("HeadPoint");
        this.HPBarController = GameObject.Find("HPBarController");
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();

        Vector3 p1 = this.transform.position;
        Vector3 p2 = this.HeadPoint.transform.position;

        float d = (p1 - p2).magnitude;         // 벡터의 길이 반환
        int n = Mathf.CeilToInt(10 - d * 5);   // 올림 처리

        if (n <= 0)
        {
            n = Random.Range(1, 3);
        }

        if (other.gameObject.tag == "Monster")
        {
            HPBarController.GetComponent<HPBar>().Damage(n);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
