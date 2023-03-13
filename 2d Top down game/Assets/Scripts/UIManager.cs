using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI GlobalCoinCountText;
    // Start is called before the first frame update
    void Start()
    {
        
        if(GameObject.Find("CoinText") != null)
        {
            GlobalCoinCountText.text = GameManager.Instance.GetCoinCount().ToString();
        }
       else
       {
           Debug.Log("This object does not exist");
       }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RaceButtonPressed()
    {
        SceneManager.LoadScene("Game Mode");
    }
    public void SingleRaceButtonPressed()
    {
        SceneManager.LoadScene("single race");
    }
    public void CupRaceButtonPressed()
    {
        SceneManager.LoadScene("Course 1");
    }
}

