using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject PausePanel;
    public TextMeshProUGUI CurrentDistanceWon, CurrentDistanceLost;
    public TextMeshProUGUI BestDistanceWon, BestDistanceLost;
    public GameObject GameOverPanel;
    public TextMeshProUGUI CoinCountText;
    public TextMeshProUGUI GasAmountText;
    public GameObject YouWonPanel;
    public TextMeshProUGUI CountdownTimerText;
    public Slider GasMeterSlider;

    [SerializeField] private int _coinsCollected = 0;
    [SerializeField] private int _gasAmount = 10;
    private int _countdownTimer = 3;
    [SerializeField] private int _currentGasAmount = 10;
    [SerializeField] private bool _isGameActive = false;
    
    public Transform PlayerCar;
    [SerializeField] private Vector2 _startPos, _endPos;
    private float _distanceTravelled;
    


    void Awake()
    {
        Instance = this;

        
    }
    
    void Start()
    {
        _startPos = PlayerCar.position;
        Time.timeScale = 1;
        CoinCountText.text = _coinsCollected.ToString();
        GasAmountText.text = _gasAmount.ToString();
        SetMaxGasFillAmount(_gasAmount);
        StartCoroutine(StartCountdownTimer());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool StartGame()
    {
       // _isGameActive = true;
        return _isGameActive;
    }
    public void GameOver()
    {
        _endPos = PlayerCar.position;
        CalculateDistanceTraveled();
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        GameManager.Instance.SetCoinCount(_coinsCollected);
    }
    public void CalculateDistanceTraveled()
    {
        float totalDistance = _endPos.y - _startPos.y;
        GameManager.Instance.SetBestDistanceTraveled(totalDistance);
        float bestDistance = GameManager.Instance.GetBestDistanceTraveled();
        CurrentDistanceLost.text = ((int)totalDistance).ToString();
        CurrentDistanceWon.text = ((int)totalDistance).ToString();
        BestDistanceLost.text = ((int)bestDistance).ToString();
        BestDistanceWon.text = ((int)bestDistance).ToString();

    }
    public void YouWon()
    {
        Time.timeScale = 0;
        YouWonPanel.SetActive(true);
    }
    public void ReplayButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToNextCourse()
    {
       int currentSceneIndex;
       currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void CupComplete()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void HomeButtonPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void PauseButtonPressed()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void PlayButtonPressed()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void UpdateLevelCoinCount(int amount)
    {
        _coinsCollected += amount;
        CoinCountText.text = _coinsCollected.ToString();
        
    }
    public void SetMaxGasFillAmount(int amount)
    {
        GasMeterSlider.maxValue = amount;
        GasMeterSlider.value = amount;
    }
    public void SetGasFillAmount(int amount) //slide value
    {
        if(_currentGasAmount < _gasAmount)
        {
            _currentGasAmount += amount;
            GasMeterSlider.value = _currentGasAmount;
        }
        
    }
    public void UpdateGasAmount(int amount) //text value
    {
        if(_currentGasAmount < _gasAmount)
        {
            _currentGasAmount += amount;
            GasAmountText.text = _currentGasAmount.ToString();
        }
      
    }

    IEnumerator StartCountdownTimer()
    {
        yield return new WaitForSeconds(0.25f);
        CountdownTimerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        

        while(_countdownTimer > 0)
        {
            CountdownTimerText.text = _countdownTimer.ToString(   );
            yield return new WaitForSeconds(1f);
            _countdownTimer--;
        }
        CountdownTimerText.text = "    GO!";
        _isGameActive = true;
        yield return new WaitForSeconds(1f);
        CountdownTimerText.gameObject.SetActive(false);
    }
    IEnumerator UpdateGasMeter()
    {
        while(_currentGasAmount > 0)
        {
            yield return new WaitForSeconds(2.5f);
            _currentGasAmount--;
            GasAmountText.text = _currentGasAmount.ToString();
            GasMeterSlider.value = _currentGasAmount;
        }

        GameOver();
    }
    public void StartGasMeter()
    {
        StartCoroutine(UpdateGasMeter());
    }
}
