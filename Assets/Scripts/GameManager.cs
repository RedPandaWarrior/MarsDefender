using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Canvas m_canvas_OnPlay;
    public Canvas m_canvas_GameOver;

    private TextMeshProUGUI _text_score;
    private TextMeshProUGUI _text_bestScore;
    private TextMeshProUGUI _text_life;

    private int _score = 0;
    private int _bestScore = 0;
    private int _life = 0;

    private Button _btn_restart;

    public AudioClip m_bgm;
    private AudioSource _audioSource;

    private void Awake()
    {
        Instance = this;

        _audioSource = this.gameObject.AddComponent<AudioSource>(); // Add audio sorce, choose bgm, set loop option true
        _audioSource.clip = m_bgm;
        _audioSource.loop = true;

        m_canvas_GameOver.gameObject.SetActive(false); // Set game-over canvas deactive
        _btn_restart = m_canvas_GameOver.transform.Find("Button_Restart").GetComponent<Button>(); // Get restart btn, add listener "loading scene Levle1" to it
        _btn_restart.onClick.AddListener(delegate (){ SceneManager.LoadScene("Level1"); });
        
        _text_score = m_canvas_OnPlay.transform.Find("Text_Score").GetComponent<TextMeshProUGUI>(); // Get text components on OnGame canvas
        _text_bestScore = m_canvas_OnPlay.transform.Find("Text_BestScore").GetComponent<TextMeshProUGUI>();
        _text_life = m_canvas_OnPlay.transform.Find("Text_Life").GetComponent<TextMeshProUGUI>();

        _life = Player.Instance.m_life; // Initilize values
        _bestScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        _audioSource.Play();
    }

    private void Update()
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        _text_score.text = $"Score : {_score}";
        _text_bestScore.text = $"Best Score : {_bestScore}";
        _text_life.text = $"Life : {_life}";
    }
    public void ChangeScore(int point)
    {
        _score += point;
        if  (_score > _bestScore) {
            _bestScore = _score;
            PlayerPrefs.SetInt("HighScore", _bestScore);
        } 
    }
    public void ChangeLife(int life)
    {
        _life = life;
        if (_life <= 0) {
            m_canvas_GameOver.gameObject.SetActive(true);
        }
    }

}
