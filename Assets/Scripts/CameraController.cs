using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPrefab;
    public Transform targetPrefab;

    public float radius = 20.0f;
    public float speed = 20.0f;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    private float angle = 0.0f;

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

        // 각도를 라디안으로 변환하여 카메라 위치 계산
        float radian = angle * Mathf.Deg2Rad;
        float x = targetPrefab.position.x + radius * Mathf.Cos(radian);
        float z = targetPrefab.position.z + radius * Mathf.Sin(radian);

        // 카메라 위치 설정
        cameraPrefab.position = new Vector3(x, cameraPrefab.position.y, z);

        cameraPrefab.LookAt(targetPrefab);
    }
}
