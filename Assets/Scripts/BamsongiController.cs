using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public GameObject BamsongiGenerator;
    public GameObject MonsterController;
    public GameObject HeadPoint;

    public float delay = 0.5f;

    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction);
    }

    void Start()
    {
        this.BamsongiGenerator = GameObject.Find("BamsongiGenerator");
        this.MonsterController = GameObject.Find("MonsterController");
        this.HeadPoint = GameObject.Find("HeadPoint");
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
            n = Random.Range(5, 10);
        }

        if (other.gameObject.tag == "Monster")
        {
            if (this.MonsterController.GetComponent<MonsterController>().currentHealth > 0)
            {
                MonsterController.GetComponent<MonsterController>().TakeDamage(n);
            }

            Invoke("DestroyWeapon", delay);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}
