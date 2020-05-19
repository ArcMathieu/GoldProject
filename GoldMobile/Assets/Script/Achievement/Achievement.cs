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
        Social.ReportProgress(GPGSIds.achievement_notsofake_exorcist, 100f, null);
    }

    public void UnlockJustaDistantMemory()
    {
        Social.ReportProgress(GPGSIds.achievement_just_a_distant_memory, 100f, null);
    }

    public void UnlockSyllogomania()
    {
        Social.ReportProgress(GPGSIds.achievement_syllogomania, 100f, null);
    }

    public void UnlockJillWouldBeProud()
    {
        Social.ReportProgress(GPGSIds.achievement_jill_would_be_proud, 100f, null);
    }
    
    public void UnlockLumosMaxima()
    {
        Social.ReportProgress(GPGSIds.achievement_lumos_maxima, 100f, null);
    }

    public void UnlockWhatinTheBox()
    {
        Social.ReportProgress(GPGSIds.achievement_whats_in_the_box, 100f, null);
    }

    public void UnlockReconstructedMemory()
    {
        Social.ReportProgress(GPGSIds.achievement_reconstructed_memory, 100f, null);
    }

    public void UnlockApromiseMadeIsApromiseKept()
    {
        Social.ReportProgress(GPGSIds.achievement_a_promise_made_is_a_promise_kept, 100f, null);
    }

    public void UnlockNeverSayDieKindaGuy()
    {
        Social.ReportProgress(GPGSIds.achievement_neversaydie_kinda_guy, 100f, null);
    }

    public void UnlockTripleParked()
    {
        Social.ReportProgress(GPGSIds.achievement_triple_parked, 100f, null);
    }



}
