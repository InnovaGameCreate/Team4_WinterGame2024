using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Image endingIllustration;
    public Sprite normalSprite; 
    public Sprite goodSprite;   
    public Sprite badSprite;    
    public Sprite completeSprite; 

    private void Start()
    {
        UpdateEndingIllustration();
    }

    private void UpdateEndingIllustration()
    {
        int score = ScoreManager.Instance.score; 

        if (score >= 300)
        {
            endingIllustration.sprite = completeSprite;
            Debug.Log("Complete Ending!");
        }
        else if (score >= 200)
        {
            endingIllustration.sprite = goodSprite;
            Debug.Log("Good Ending!");
        }
        else if (score >= 100)
        {
            endingIllustration.sprite = normalSprite;
            Debug.Log("Normal Ending!");
        }
        else
        {
            endingIllustration.sprite = badSprite;
            Debug.Log("Bad Ending!");
        }
    }
}
