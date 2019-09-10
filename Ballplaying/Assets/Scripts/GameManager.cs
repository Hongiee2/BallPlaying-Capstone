using extOSC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int xPos, yPos;

    Vector3 temp = new Vector3();

    #region Public Vars

    public string Address = "/MultiMode/02";

    [Header("OSC Settings")]
    public OSCReceiver Receiver;

    #endregion

    #region Unity Methods

    protected virtual void Start()
    {
        Receiver.Bind(Address, ReceivedMessage);
    }


    private void ReceivedMessage(OSCMessage message)
    {
        Debug.LogFormat("Received: {0}", message);
        int num = message.Values[0].IntValue;
        //Debug.Log(num);
        //Debug.Log(message.Values[1].IntValue);

        xPos = message.Values[0].IntValue;
        yPos = message.Values[1].IntValue;
        //메세지가 2개의 값으로 전달되어 오는데 값으로 쪼개는 과정이
    }

    public GameObject ParticleFXExplosion;

    public int red_score = 0;
    public int blue_score = 0;
    public int yellow_score = 0;

    public Text Red_scoreText;
    public Text Blue_scoreText;
    public Text Yellow_scoreText;
    int result_score;

    public GameObject getscore;

    void Awake()
    {
    }

    /*
    void Start()
    {
        //getscore = Instantiate(single_s) as GameObject;
        //getscore = gameObject.GetComponent<Score>().s_s;
        //getscore = GetComponent<Score>;
    }
    */

    void Update()
    {
        if (xPos != 0 && yPos != 0)
        {
            Explosion();
        }
    }

    void Explosion()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3 (xPos, yPos));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(xPos + "," + yPos);
            if (hit.transform.gameObject.tag == "Yellow_target")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(ParticleFXExplosion, hit.transform.position, transform.rotation);
                sound.instance.PlaySound();
                Yellow_AddScore(10);

                /*if (Input.GetMouseButtonDown(0)) // 좌클릭 시
                {
                    print("pos x = " + Input.mousePosition.x + "    /// pos y =" + Input.mousePosition.y);
                    print("===score=== " + score);
                }*/
            }
            if (hit.transform.gameObject.tag == "Red_target")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(ParticleFXExplosion, hit.transform.position, transform.rotation);
                sound.instance.PlaySound();
                Red_AddScore(10);
            }
            if (hit.transform.gameObject.tag == "Blue_target")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(ParticleFXExplosion, hit.transform.position, transform.rotation);
                sound.instance.PlaySound();
                Blue_AddScore(10);
            }
        }
    }

    public void Red_AddScore(int Red_hitScore)
    {
        red_score += Red_hitScore;
        //getscore.mu_s1 = red_score;
        getscore.GetComponent<Score>().mu_s1 = red_score;
        Red_scoreText.text = "" + red_score;
        //result_score = red_score;
    }

    public void Blue_AddScore(int Blue_hitScore)
    {
        blue_score += Blue_hitScore;
        //getscore.mu_s2 = blue_score;
        getscore.GetComponent<Score>().mu_s2 = blue_score;
        Blue_scoreText.text = "" + blue_score;
        //result_score = blue_score;
    }

    public void Yellow_AddScore(int Yellow_hitScore)
    {
        yellow_score += Yellow_hitScore;
        //single_s.s_s = yellow_score;
        getscore.GetComponent<Score>().s_s = yellow_score;
        Yellow_scoreText.text = "" + yellow_score;
        //result_score = yellow_score;
    }
    #endregion
}