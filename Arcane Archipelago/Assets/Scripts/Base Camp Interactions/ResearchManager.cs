using UnityEngine;

public class ResearchManager : MonoBehaviour
{
    [HideInInspector]
    public string shortCharName;
    int researchIndex;
    ResearchDatabase charResearch;
    static bool researchActive;

    //Time is in seconds
    static float timeStamp = 0;
    static float timeLeft;
    public static float GetTimeLeft()
    {
        if (timeLeft > 0)
        {
            timeLeft -= (Time.time - timeStamp);
            timeStamp = Time.time;

            //if (IsInvoking ("FinishResearch"))
            //{
            //   CancelInvoke ("FinishResearch");
            //}
            //Invoke ("FinishResearch", timeLeft);

            return timeLeft;
        }
        else
        {
            return 0;
        }
    }

    void Start()
    {
        timeLeft = SaveManager.currentData.researchTimeLeft;
        Invoke("FinishResearch", timeLeft);
    }

    void StartResearch()
    {
        if (SaveManager.currentData.researchCompleted.ContainsKey(shortCharName))
        {
            researchIndex = SaveManager.currentData.researchCompleted[shortCharName];
        }
        else
        {
            SaveManager.currentData.researchCompleted.Add(shortCharName, 0);
            researchIndex = 0;
        }

        charResearch = (ResearchDatabase)Resources.Load("Research/" + shortCharName + " Research");
        //timeLeft = charResearch.researchList [researchIndex].totalTimeS;
        Invoke("FinishResearch", timeLeft);
    }

    void FinishResearch()
    {
        SaveManager.currentData.researchCompleted[shortCharName] += 1;
    }
}
