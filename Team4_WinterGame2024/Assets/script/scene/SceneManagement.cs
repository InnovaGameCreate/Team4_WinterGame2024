using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnClick : MonoBehaviour
{
    [SerializeField] public string targetScene;

    void OnMouseDown()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            // シーン遷移前にスコアをリセット
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.score = 0;  // スコアを0に設定
                ScoreManager.Instance.UpdateScoreDisplay(); // スコア表示を更新
            }
            else
            {
                Debug.LogError("ScoreManager.Instance is null! Cannot reset score.");
            }

            // シーン遷移
            SceneManager.LoadScene(targetScene);
        }
    }
}
