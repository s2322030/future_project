using UnityEngine;
using System.Collections;

public class HoleTrigger : MonoBehaviour
{
    public GameObject supportCube; // 支える土台のCubeオブジェクト
    public Renderer textureRenderer; // テクスチャを持つオブジェクトのRenderer
    public float initialScrollSpeed = 0.0f; // 初速度
    public float gravity = 9.8f; // 重力加速度

    private bool isScrolling = false;
    private float startTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Playerタグを持つオブジェクトが接触した場合
        {
            BoxCollider cubeCollider = supportCube.GetComponent<BoxCollider>();
            if (cubeCollider != null)
            {
                cubeCollider.enabled = false; // BoxColliderを無効にする
            }

            // テクスチャのスクロール開始を設定
            isScrolling = true;
            startTime = Time.time;

            // 一定時間後にスクロールを停止する
            StartCoroutine(StopScrollingAfterTime(3.0f)); // 例として3秒後に停止
        }
    }

    void Update()
    {
        if (isScrolling && textureRenderer != null)
        {
            // 経過時間を計算
            float elapsedTime = Time.time - startTime;
            
            // 自由落下の速度を計算
            float currentScrollSpeed = initialScrollSpeed + gravity * elapsedTime;

            // テクスチャのオフセットを更新
            float y = Mathf.Repeat(currentScrollSpeed * elapsedTime, 1);
            Vector2 offset = new Vector2(0, y);
            textureRenderer.material.SetTextureOffset("_MainTex", offset);
        }
    }

    private IEnumerator StopScrollingAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        isScrolling = false;
    }
}