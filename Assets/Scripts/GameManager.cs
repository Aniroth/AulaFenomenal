using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    GameObject gameManarger = new GameObject("GameManager");
                    _instance = gameManarger.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    public GameObject deathPanel;
    public bool isPlayerDead;

    public void PlayerDead()
    {
        isPlayerDead = true;
        deathPanel.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }

}
