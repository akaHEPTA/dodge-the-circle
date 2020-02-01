using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloudOnce;

public class GooglePlayManager : MonoBehaviour
{

    public static GooglePlayManager instance;
    static int currentScore = 0;

    void Awake() {
        if (instance != null) {
            instance.resetScore();
            Destroy(gameObject);
        }else {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cloud.Initialize(false, true, true);
        Cloud.OnInitializeComplete += OnInitFinish;
    }

    void OnInitFinish() {
        Cloud.OnInitializeComplete -= OnInitFinish;
    }

    public void resetScore() {
        currentScore = 0;
    }

    public void addScore() {
    	currentScore += 1;

        if (currentScore >= 5 && !Achievements.Dodge5.IsUnlocked) {
            Achievements.Dodge5.Unlock();
        }else if (currentScore >= 15 && !Achievements.Dodge15.IsUnlocked) {
            Achievements.Dodge15.Unlock();
        }else if (currentScore >= 30 && !Achievements.Dodge30.IsUnlocked) {
            Achievements.Dodge30.Unlock();
        }else if (currentScore >= 50 && !Achievements.Dodge50.IsUnlocked) {
            Achievements.Dodge50.Unlock();
        }else if (currentScore >= 100 && !Achievements.Dodge100.IsUnlocked) {
            Achievements.Dodge100.Unlock();
        }

    }

    public void submitScore() {
        Leaderboards.HighScore.SubmitScore(currentScore);
    }



}
