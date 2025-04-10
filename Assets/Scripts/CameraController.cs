using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPrefab;
    // public Transform targetPrefab;

    public float angle = 0.0f;
    public float radius = 20.0f;
    public float speed = 20.0f;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    private void Update()
    {
        if (Input.GetKey(leftKey))
        {
            angle -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(rightKey))
        {
            angle += speed * Time.deltaTime;
        }

        GameObject activeMonster = GameObject.FindGameObjectWithTag("Monster");

        if (activeMonster != null)
        {
            // 각도를 라디안으로 변환하여 카메라 위치 계산
            float radian = angle * Mathf.Deg2Rad;
            float x = activeMonster.transform.position.x + Mathf.Cos(radian) * radius;
            float z = activeMonster.transform.position.z + Mathf.Sin(radian) * radius;

            cameraPrefab.position = new Vector3(x, cameraPrefab.position.y, z);
            cameraPrefab.LookAt(activeMonster.transform);
        }
    }
}
