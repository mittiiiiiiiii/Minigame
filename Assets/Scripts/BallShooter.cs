using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab; // 発射する球体のPrefab
    public float shootingSpeed = 20.0f; // 球体の発射速度
    public Transform shootingPoint; // 球体を発射する位置

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリックを検出
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        if (ballPrefab != null && shootingPoint != null)
        {
            // 球体のインスタンスを生成し、発射点の位置と向きに設定
            GameObject ball = Instantiate(ballPrefab, shootingPoint.position, shootingPoint.rotation);

            // Rigidbodyを取得し、前方に力を加える
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(shootingPoint.forward * shootingSpeed, ForceMode.Impulse);
            }
        }
    }
}