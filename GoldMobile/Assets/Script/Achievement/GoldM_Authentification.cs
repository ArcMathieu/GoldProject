using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GoldM_Authentification : MonoBehaviour
{
    public static PlayGamesPlatform platform;

    void Start()
    {
        login();
    }

    public void login()
    {
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Logged successfuly");
            }
            else
            {
                Debug.Log("Failled");
            }
        });
    }
    
}
