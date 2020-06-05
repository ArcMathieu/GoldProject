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
        Debug.Log("is ok notsofake_exorcist");
    }

    public void UnlockSyllogomania()
    {
        Social.ReportProgress(GPGSIds.achievement_syllogomania, 100f, null);
        Debug.Log("is ok Syllogomania" );
    }

    public void UnlockJillWouldBeProud()
    {
        Social.ReportProgress(GPGSIds.achievement_jill_would_be_proud, 100f, null);
        Debug.Log("is ok JillWouldBeProud");
    }
    
    public void UnlockLumosMaxima()
    {
        Social.ReportProgress(GPGSIds.achievement_lumos_maxima, 100f, null);
        Debug.Log("is ok LumosMaxima");
    }

    public void UnlockWhatinTheBox()
    {
        Social.ReportProgress(GPGSIds.achievement_whats_in_the_box, 100f, null);
        Debug.Log("is ok WhatinTheBox");
    }

    public void UnlockReconstructedMemory()
    {
        Social.ReportProgress(GPGSIds.achievement_reconstructed_memory, 100f, null);
        Debug.Log("is ok ReconstructedMemory");
    }

    public void Unlockhoardingt()
    {
        Social.ReportProgress(GPGSIds.achievement_hoarding, 100f, null);
        Debug.Log("is ok ApromiseMadeIsApromiseKept");
    }

    public void UnlockNeverSayDieKindaGuy()
    {
        Social.ReportProgress(GPGSIds.achievement_neversaydie_kinda_guy, 100f, null);
        Debug.Log("is ok lockNeverSayDieKindaGuy");
    }

    public void UnlockTripleParked()
    {
        Social.ReportProgress(GPGSIds.achievement_triple_parked, 100f, null);
        Debug.Log("is ok WhatinTheBox TripleParked");
    }

    public void UnlockCreature()
    {
        Social.ReportProgress(GPGSIds.achievement_the_boys_are_back_in_town, 100f, null);
        Debug.Log("is ok creature");
    }   
    public void UnlockShadows()
    {
        Social.ReportProgress(GPGSIds.achievement_light_em_up, 100f, null);
        Debug.Log("is ok LightEmUp");
    }

    public void UnlockBoss()
    {
        Social.ReportProgress(GPGSIds.achievement_the_end, 100f, null);
        Debug.Log("boss dead");
    }

}
