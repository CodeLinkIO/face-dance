using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FaceExpression : MonoBehaviour
{
    public static FaceExpression instance;
    private FaceExpressionType _faceExpression;

    public enum FaceExpressionType
    {
        MouthOpen,
        MouthClosed,
        SmileEngaged,
        SmileDisengaged,
        Nothing,
        LeftEyeClose,
        RightEyeClose,
        LeftEyeOpen,
        RightEyeOpen
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        _faceExpression = FaceExpressionType.Nothing;
    }

    public FaceExpressionType getFaceExpression()
    {
        return _faceExpression;
    }

    public void setFaceExpression(FaceExpressionType faceExpression)
    {
        _faceExpression = faceExpression;
    }

    public void CaptureFaceExpression(string expressionName)
    {
        Enum.TryParse(expressionName, out FaceExpressionType faceExpressionType);
        GameManager.instance.ReceiveFaceExpression(faceExpressionType);
        //setFaceExpression(faceExpressionType);
    }
}
