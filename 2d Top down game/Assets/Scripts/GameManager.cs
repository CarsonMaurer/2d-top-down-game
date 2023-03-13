using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int _coinCount = 0;
    [SerializeField] private float _bestDistance = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCoinCount(int amount)
    {
        _coinCount += amount;
    }
    public int GetCoinCount()
    {
        return _coinCount;
    }
    public void SetBestDistanceTraveled(float amount)
    {
        if(_bestDistance < amount)
        {
            _bestDistance = amount;
        }
    }
    public float GetBestDistanceTraveled()
    {
        return _bestDistance;
    }
    public void RaceButtonPressed()
    {
        SceneManager.LoadScene("Game Mode");
    }
}
