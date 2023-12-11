using UnityEngine;

public class BallExplosion : MonoBehaviour
{
    public GameObject explosionPrefab; // 爆発エフェクトのPrefab
    public float explosionRadius = 1000000.0f; // 爆発の半径
    public float explosionForce = 1000000000000.0f; // 爆発による力

    void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.CompareTag("Cube"))
        {
            // 爆発エフェクトを生成
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // 衝撃波を生成
            CreateShockwave();

            // ボールを破壊
            Destroy(gameObject);
        }
    }

    void CreateShockwave()
    {
        // 爆発の位置を中心に範囲内のすべてのコライダーを検出
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // コライダーに力を加える
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}
