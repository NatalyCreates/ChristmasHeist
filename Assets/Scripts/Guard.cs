using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    public int guardID;

    //Vector3 movDirection1;
    //Vector3 movDirection2;
    //Vector3 movDirection3;

    Vector3[] guardPath1;
    Vector3[] guardPath2;
    Vector3[] guardPath3;


    private void Awake() {
        // init pos

        //movDirection1 = new Vector3(0, 0, -1);
        //movDirection2 = new Vector3(1, 0, 0);

        guardPath1 = new Vector3[2];
        guardPath1[0] = new Vector3(-31.5f, 2f, 30.3f);
        guardPath1[1] = new Vector3(-31.5f, 2f, -10f);
        //guardPath1[2] = new Vector3(-31.5f, 2f, 30.3f);

        guardPath2 = new Vector3[2];
        guardPath2[0] = new Vector3(-35f, 2f, -33f);
        guardPath2[1] = new Vector3(-5f, 2f, -33f);
        //guardPath1[2] = new Vector3(-31.5f, 2f, 30.3f);

        guardPath3 = new Vector3[6];
        guardPath3[0] = new Vector3(18f, 2f, 5f);
        guardPath3[1] = new Vector3(35f, 2f, 5f);
        guardPath3[2] = new Vector3(35f, 2f, 35f);
        guardPath3[3] = new Vector3(18f, 2f, 35f);
        guardPath3[4] = new Vector3(35f, 2f, 35f);
        guardPath3[5] = new Vector3(35f, 2f, 5f);

        GameManager.OnGameStarted += OnGameStart;
    }

    void OnDestroy() {
        GameManager.OnGameStarted -= OnGameStart;
    }

    void OnGameStart() {
        StartCoroutine(GuardMovement(guardID));
    }
	
	void Update() {
        // move along predetermined path
        // randomize time that they wait in one spot at the edge of their path


    }

    IEnumerator GuardMovement(int guardID)
    {

            if (guardID == 1)
            {
                float step;
            
                for (int k = 1;  k < 200; k++) { 
                    foreach (Vector3 destPoint in guardPath1)
                    {
                        Debug.Log(destPoint.ToString());
                        while (Vector3.Distance(destPoint, transform.position) > 0.2)
                        {
                            step = GameDesign.Instance.guardSpeed * Time.deltaTime;
                            //Debug.Log(step.ToString());
                            transform.position = Vector3.MoveTowards(transform.position, destPoint, step);
                            yield return new WaitForSecondsRealtime(Time.deltaTime);
                    }
                        yield return new WaitForSecondsRealtime(Random.Range(0.5f, 3.0f));
                    }
                }
            }

        if (guardID == 2)
        {
            float step;

            for (int k = 1; k < 200; k++)
            {
                foreach (Vector3 destPoint in guardPath2)
                {
                    Debug.Log(destPoint.ToString());
                    while (Vector3.Distance(destPoint, transform.position) > 0.2)
                    {
                        step = GameDesign.Instance.guardSpeed * Time.deltaTime;
                        //Debug.Log(step.ToString());
                        transform.position = Vector3.MoveTowards(transform.position, destPoint, step);
                        yield return new WaitForSecondsRealtime(Time.deltaTime);
                    }
                    yield return new WaitForSecondsRealtime(Random.Range(0.5f, 1.5f));
                }
            }
        }

        if (guardID == 3)
        {
            float step;

            for (int k = 1; k < 200; k++)
            {
                foreach (Vector3 destPoint in guardPath3)
                {
                    Debug.Log(destPoint.ToString());
                    while (Vector3.Distance(destPoint, transform.position) > 0.2)
                    {
                        step = GameDesign.Instance.guardSpeed * Time.deltaTime;
                        //Debug.Log(step.ToString());
                        transform.position = Vector3.MoveTowards(transform.position, destPoint, step);
                        yield return new WaitForSecondsRealtime(Time.deltaTime);
                    }
                    yield return new WaitForSecondsRealtime(Random.Range(1f, 1.5f));
                }
            }
        }
        //Invoke("GuardMovement(guardID)",0);

        /*
                            if ((transform.position.z < -10) || (transform.position.z > 30.5))
                    {
                        movDirection1 = -movDirection1;
                    }
                    transform.Translate(movDirection1 * GameDesign.Instance.guardSpeed * Time.deltaTime, Space.World);

                }

                if (guardID == 2)
                {
                    if ((transform.position.x < -35) || (transform.position.x > -5))
                    {
                        movDirection2 = -movDirection2;
                    }
                    transform.Translate(movDirection2 * GameDesign.Instance.guardSpeed * Time.deltaTime, Space.World);
                }

                if (guardID == 3)
                {

                }

        */

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Noise")
        {
            //Lose game

            Debug.Log("Noise hit guard");
            GameManager.Instance.Busted();
            StopAllCoroutines();

            //Destroy(gameObject);
        }
        else
        {
            //Debug.Log("Trigger Enter Collectible - wasn't Tree");
            //Collectible dissapears
            //Add 1 to number of coll
        }

    }

}
