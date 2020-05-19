using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class Achievement : MonoBehaviour
{
    public void OpenAchievementPanel()
    {
        Social.ShowAchievementsUI();
    }

    public void UnlockTrueFalseExorcist()
    {
        Social.ReportProgress(GPGSIds.achievement_truefalse_exorcist, 100f, null);
    }

    public void UnlockMoreThanaDistantMemory()
    {
        Social.ReportProgress(GPGSIds.achievement_more_than_a_distant_memory, 100f, null);
    }
}
