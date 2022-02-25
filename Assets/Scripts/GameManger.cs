using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    #region
    private static GameManger _instance;
    public static GameManger Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManger>();
            }
            return _instance;
        }
    }
    #endregion
    public int Score;
    [SerializeField] private Text _scoreTxt;
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        _scoreTxt.text = "Score: " + Score.ToString();
    }
}
