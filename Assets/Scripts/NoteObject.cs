using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    public FaceExpression.FaceExpressionType facialExpressionTarget;
    public int noteIndex;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.instance.GetCurrentNoteIndex() == noteIndex)
        //{
        //    InstatiateEffect(hitEffect);
        //}
        //if (FaceExpression.instance.getFaceExpression() == facialExpressionTarget)
        //{
        //    if (canBePressed)
        //    {
        //        gameObject.SetActive(false);
        //        if (Mathf.Abs(transform.position.y) > 30)
        //        {
        //            GameManager.instance.NormalHit();
        //            InstatiateEffect(hitEffect);
        //            //Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);

        //        }
        //        else if (Mathf.Abs(transform.position.y) > 15f)
        //        {
        //            GameManager.instance.GoodHit();
        //            InstatiateEffect(goodEffect);
        //            //Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
        //        }
        //        else
        //        {
        //            InstatiateEffect(perfectEffect);
        //            GameManager.instance.PerfectHit();
        //        }
        //        canBePressed = false;
        //    }
        //}
    }

    public void InstatiateEffect()
    {
        //Print the time of when the function is first called.
        GameObject clone =  (GameObject)Instantiate(hitEffect, transform.position, perfectEffect.transform.rotation);

        Destroy(clone, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.tag == "Activator")
        //{
        //    canBePressed = true;
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        FaceExpression.instance.setFaceExpression(FaceExpression.FaceExpressionType.Nothing);
        canBePressed = false;
        gameObject.SetActive(false);

        //if (other.tag == "Activator")
        //{
        //    Debug.Log("3333333" + canBePressed);
        //    if (canBePressed == false)
        //    {
        //        GameManager.instance.NoteMissed();
        //        Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        //    }
        //    else
        //    {
        //        canBePressed = false;
        //    }
        //}
    }
}
