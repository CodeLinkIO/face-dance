using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public FaceExpression.FaceExpressionType currentTargetFaceExpression = FaceExpression.FaceExpressionType.Nothing;
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static GameManager instance;
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public Text scoreText;
    public Text multiText;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThreshold;
    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;
    private float nbBeat = 0;
    public FaceExpression.FaceExpressionType[] targetFaceExpressionType;
    public int currentTargetFaceExpressionIndex;
    public float startTime;
    public float currentBeatTime = 0;
    public float bpm = 105;
    public float[] beatTimeStamp;
    public GameObject[] notes;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentMultiplier = 1;
        currentTargetFaceExpressionIndex = 0;
        beatTimeStamp = new float[] { 3.6f, 4.7f, 5.8f, 6.9f, 8.0f, 9.1f, 10.2f, 11.3f, 12.4f, 13.5f, 14.6f, 15.7f };
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
                startTime = Time.realtimeSinceStartup;
                currentBeatTime = 0;
            }
        }
        else 
        {
            //if (Input.anyKeyDown)
            //{
            //    Debug.Log(Time.realtimeSinceStartup - startTime);
            //    notes[currentTargetFaceExpressionIndex].SetActive(false);
            //    float tempTime = Mathf.Abs(Time.realtimeSinceStartup - startTime - beatTimeStamp[currentTargetFaceExpressionIndex]);
            //    GameObject effect;
            //    GameObject clone;
            //    if (tempTime < 0.3f)
            //    {
            //        effect = perfectEffect;
            //    }
            //    else if (tempTime < 0.6f)
            //    {
            //        effect = goodEffect;
            //    }
            //    else if (tempTime < 1f)
            //    {
            //        effect = hitEffect;
            //    }
            //    else
            //    {
            //        effect = missEffect;
            //    }
            //    clone = (GameObject)Instantiate(effect, notes[currentTargetFaceExpressionIndex].transform.position, notes[currentTargetFaceExpressionIndex].transform.rotation);
            //    Destroy(clone, 1f);
            //    currentTargetFaceExpressionIndex++;
            //}
               
        }
    }

    public void ReceiveFaceExpression(FaceExpression.FaceExpressionType receiveFaceExpression)
    {
        if (receiveFaceExpression == targetFaceExpressionType[currentTargetFaceExpressionIndex])
        {
            notes[currentTargetFaceExpressionIndex].SetActive(false);
            float tempTime = Mathf.Abs(Time.realtimeSinceStartup - startTime - beatTimeStamp[currentTargetFaceExpressionIndex]);
            GameObject effect;
            GameObject clone;
            if (tempTime < 0.1f)
            {
                effect = perfectEffect;
            }
            else if (tempTime < 0.3f)
            {
                effect = goodEffect;
            }
            else if (tempTime < 0.6f)
            {
                effect = hitEffect;
            }
            else
            {
                effect = missEffect;
            }
            clone = (GameObject)Instantiate(effect, notes[currentTargetFaceExpressionIndex].transform.position, notes[currentTargetFaceExpressionIndex].transform.rotation);
            Destroy(clone, 1f);
        }
        if ((targetFaceExpressionType[currentTargetFaceExpressionIndex] == FaceExpression.FaceExpressionType.SmileEngaged &&  receiveFaceExpression == FaceExpression.FaceExpressionType.SmileDisengaged)
            || (targetFaceExpressionType[currentTargetFaceExpressionIndex] == FaceExpression.FaceExpressionType.MouthOpen && receiveFaceExpression == FaceExpression.FaceExpressionType.MouthClosed)
            || (targetFaceExpressionType[currentTargetFaceExpressionIndex] == FaceExpression.FaceExpressionType.LeftEyeClose && receiveFaceExpression == FaceExpression.FaceExpressionType.LeftEyeOpen)
            || (targetFaceExpressionType[currentTargetFaceExpressionIndex] == FaceExpression.FaceExpressionType.RightEyeClose && receiveFaceExpression == FaceExpression.FaceExpressionType.RightEyeOpen))
        {
            currentTargetFaceExpressionIndex++;
        }
    }

    public int GetCurrentNoteIndex()
    {
        return currentTargetFaceExpressionIndex;
    }

    public void NoteHit()
    {
        if (currentMultiplier -1 < multiplierThreshold.Length)
        {
            multiplierTracker++;
            //if (multiplierThreshold[currentMultiplier - 1] < multiplierTracker)
            //{
            //    multiplierTracker = 0;
            //    currentMultiplier++;
            //}
        }
        //currentScore += scorePerNote * currentMultiplier;
        //scoreText.text = "Score: " + currentScore;
       
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit(); 
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
