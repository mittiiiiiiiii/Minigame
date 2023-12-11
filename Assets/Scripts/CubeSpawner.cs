using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // 落とすキューブのPrefab
    public float spawnInterval = 1.0f; // キューブを生成する間隔（秒）
    public float spawnAreaSize = 10.0f; // キューブを生成する範囲のサイズ

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCube();
            timer = 0;
        }
    }

    void SpawnCube()
    {
        if (cubePrefab != null)
        {
            // ランダムな位置を計算
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnAreaSize / 2, spawnAreaSize / 2),
                transform.position.y,
                Random.Range(-spawnAreaSize / 2, spawnAreaSize / 2)
            );

            // キューブのインスタンスを生成
            Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
        }
    }
}