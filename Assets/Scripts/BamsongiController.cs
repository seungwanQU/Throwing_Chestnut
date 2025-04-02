using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    private GameObject BamsongiGenerator;

    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction);
    }

    void Start()
    {
        this.BamsongiGenerator = GameObject.Find("BamsongiGenerator");
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;

        if (other.gameObject.tag == "Target")
        {
            this.BamsongiGenerator.GetComponent<BamsongiGenerator>().ScorePlus();
        }
    }
}
