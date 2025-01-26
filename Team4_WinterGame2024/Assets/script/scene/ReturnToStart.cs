using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToStart : MonoBehaviour
{
    [SerializeField] private string startSceneName = "Start";

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            SceneManager.LoadScene(startSceneName);
        }
    }
}
