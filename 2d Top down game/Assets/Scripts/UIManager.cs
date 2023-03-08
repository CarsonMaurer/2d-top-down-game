using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("CoinText") != null)
        {
            Debug.Log(" I found the CoinText");
            GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>;
        }
        else
        {
            Debug.Log("I can't find the CoinText");
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

