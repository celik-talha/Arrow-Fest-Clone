using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArrowScript : MonoBehaviour
{
    public Rigidbody arrowRb;
    public int playerSpeed;
    Vector3 move = Vector3.zero;

    public int arrowCount = 1;
    public int collectedArrows = 0;

    public TextMeshProUGUI arrowText;
    public Vector3 textPos;
    public Vector3 textScale;

    public GameObject tempArrow;

    public GameObject mainArrow;

    public GameObject cloneArrow;
    public GameObject goPanel;
    public Text clcArrowText;

    public GameObject finishPanel;
    public Text finishArrow;

    public float zRadius = 1f;
    public float yRadius = 1f;
    public float center;

    public float pi = 3.1415f;

    public PlaneScript plnScript;

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) 
        {
            if (transform.localPosition.x >= -3.5f)
            {
                move = new Vector3(-1, 0, 0);
                arrowRb.MovePosition(transform.position + move * Time.deltaTime * playerSpeed);
            }
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            if (transform.localPosition.x <= 3.5)
            {
                move = new Vector3(1, 0, 0);
                arrowRb.MovePosition(transform.position + move * Time.deltaTime * playerSpeed);
            }
        }
        center = Mathf.Abs(transform.localPosition.x);
        if (center>2f)
        {
            zRadius = 1f / center;
        }
        else
        {
            zRadius = 0.5f;
        }
        stackArrow();
    }

    private void OnTriggerEnter(Collider thing)
    {
        if (thing.tag == "Gate")
        {
            int process = System.Convert.ToInt32(thing.name.Substring(0, 1));
            int number = System.Convert.ToInt32(thing.name.Substring(1, 2));

            if (process == 1)
            {
                collectedArrows += number;
                arrowCount = arrowCount + number;
            }
            else if (process == 2)
            {
                arrowCount = arrowCount - number;
            }
            else if (process == 3)
            {
                collectedArrows += arrowCount * (number - 1);
                arrowCount = arrowCount * number;
            }
            else if (process == 4)
            {
                arrowCount = arrowCount / number;
            }
            else if (process == 5)
            {
                finishGame();
            }
            else
            {
                Debug.Log("INVALID GATE ID");
            }
            thing.gameObject.SetActive(false);
            setStats();
        }

        else if (thing.tag == "Obstacle")
        {
            arrowCount--;
            arrowCount--;

            Renderer obsRenderer = thing.GetComponent<Renderer>();
            Color obsColor = obsRenderer.material.color;
            obsColor.a = 0.2f;
            obsRenderer.material.color = obsColor;        
        }

        if (arrowCount<1)
        {
            endGame();
        }
        stackArrow();
        setStats();
    }

    private void setStats()
    {
        arrowText.text = System.Convert.ToString(arrowCount);
    }

    private void endGame()
    {
        plnScript.isLive = false;
        arrowCount = 0;
        arrowText.gameObject.SetActive(false);
        goPanel.gameObject.SetActive(true);
        clcArrowText.text = System.Convert.ToString(collectedArrows);
    }

    private void stackArrow()
    {
        foreach (Transform child in cloneArrow.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 1; i <= arrowCount; i++)
        {
            GameObject newArrow;
            newArrow = Instantiate(tempArrow,cloneArrow.transform);
            if (i >= 2 && i <= 9)
            {
                float deg = (4 - i) * 45;
                float rad = deg / 180 * pi;
                newArrow.transform.localPosition = new Vector3(0, Mathf.Sin(rad) * yRadius, Mathf.Cos(rad) * zRadius);
            }
            else if (i == 1)
            {
                newArrow.transform.localPosition = new Vector3(0, 0, 0);
            }
            else if (i >= 10 && i <= 21)
            {
                float deg = (13 - i) * 30;
                float rad = deg / 180 * pi;
                newArrow.transform.localPosition = new Vector3(0, Mathf.Sin(rad) *1.5f*yRadius, Mathf.Cos(rad) *1.5f*zRadius);
            }
            else if (i >= 22 && i <= 37)
            {
                float deg = (26 - i) * 22.5f;
                float rad = deg / 180 * pi;
                newArrow.transform.localPosition = new Vector3(0, Mathf.Sin(rad) * 2 * yRadius, Mathf.Cos(rad) * 2 * zRadius);
            }
            else if (i >= 38)
            {
                float deg = (45 - i) * 18f;
                float rad = deg / 180 * pi;
                newArrow.transform.localPosition = new Vector3(0, Mathf.Sin(rad) * 2.5f * yRadius, Mathf.Cos(rad) * 2.5f * zRadius);
            }
        }
    }
    private void finishGame()
    {
        finishPanel.gameObject.SetActive(true);
        arrowText.gameObject.SetActive(false);
        plnScript.isLive = false;
        finishArrow.text = System.Convert.ToString(arrowCount);
    }
}