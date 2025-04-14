using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPrefab;
    // public Transform targetPrefab;

    // public float angle = 0.0f;
    // public float radius = 20.0f;
    // public float speed = 20.0f;

    // public KeyCode leftKey = KeyCode.A;
    // public KeyCode rightKey = KeyCode.D;

    [SerializeField]
    float _inputSpeed = 0.1f;
    [SerializeField]
    float totalRun = 1.0f;

    private void Update()
    {
        // if (Input.GetKey(leftKey))
        // {
        //     angle -= speed * Time.deltaTime;
        // }
        // else if (Input.GetKey(rightKey))
        // {
        //     angle += speed * Time.deltaTime;
        // }

        // GameObject activeMonster = GameObject.FindGameObjectWithTag("Monster");

        // if (activeMonster != null)
        // {
        //     // 각도를 라디안으로 변환하여 카메라 위치 계산
        //     float radian = angle * Mathf.Deg2Rad;
        //     float x = activeMonster.transform.position.x + Mathf.Cos(radian) * radius;
        //     float z = activeMonster.transform.position.z + Mathf.Sin(radian) * radius;

        //     cameraPrefab.position = new Vector3(x, cameraPrefab.position.y, z);
        //     cameraPrefab.LookAt(activeMonster.transform);
        // }

        CameraInput();
    }

    private void CameraInput()
    {
        Vector3 p_Velocity = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1f, 0, 0);
        }

        Vector3 p = p_Velocity;

        if (p.sqrMagnitude > 0)
        {
            totalRun += Time.deltaTime;
            p = p * totalRun * 1.0f;

            p.x = Mathf.Clamp(p.x, -_inputSpeed, _inputSpeed);
            p.y = Mathf.Clamp(p.y, -_inputSpeed, _inputSpeed);
            p.z = Mathf.Clamp(p.z, -_inputSpeed, _inputSpeed);

            cameraPrefab.transform.Translate(p);
        }
    }
}
