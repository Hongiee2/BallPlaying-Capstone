using extOSC;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BallDrag : MonoBehaviour
{
    public int xPos, yPos;
    Vector3 temp = new Vector3();
    string sceneName;
    #region Public Vars

    public string Address = "/test/00";

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
        Debug.Log(num);
        Debug.Log(message.Values[1].IntValue);

        xPos = message.Values[0].IntValue;
        yPos = message.Values[1].IntValue;
        //메세지가 2개의 값으로 전달되어 오는데 값으로 쪼개는 과정이
    }

    /*
    IEnumerator OnMouseDown(int xPos, int yPos)//공을 마우스로 드래그하면 공이 마우스와 같이 이동
    {
        Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z));

        while (xPos!=0&&y)
        {
            Vector3 curScreenSpace = new Vector3(xPos, yPos, scrSpace.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            transform.position = curPosition;
            yield return null;
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Single_Button"))// [main]에서, [Single Button] 클릭
        {
            Debug.Log("11111");
            sceneName = "1_SingleHelp_Scene";
            Invoke("SceneMove", 1.0f);
        }
        else if (collision.CompareTag("Multi_Button"))// [main]에서, [Multi Button] 클릭
        {
            Debug.Log("22222");
            sceneName = "1_MultiHelp_Scene";
            Invoke("SceneMove", 1.0f);
        }
        else if (collision.CompareTag("Single_Game")) // [Single Help]에서 클릭
        {
            //Debug.Log("33333");
            sceneName = "2_SingleMode_Game";
            Invoke("SceneMove", 5.0f);
        }
        else if (collision.CompareTag("Multi_Game")) // [Multi Help]에서 클릭
        {
            Debug.Log("44444");
            sceneName = "2_MultiMode_Game";
            Invoke("SceneMove", 5.0f);
        }
    }
    void SceneMove()
    {
        //Debug.Log("bd_Scene Move");
        //SceneManager.LoadScene("\"" + sceneName + "\""); // [Single Game] 이동
        //SceneManager.LoadScene(sceneName); // [Single Game] 이동

        SceneManager.LoadScene(sceneName); // [Single Game] 이동-
    }
    void Update()
    {
        if (xPos != 0 && yPos != 0)
        {

            //Debug.Log("bd_a key");
            temp = new Vector3(xPos, yPos);
            transform.position = temp;

            /*
            temp = Input.mousePosition;
            transform.position = temp;
            OnMouseDown((int)Input.mousePosition.x, (int)Input.mousePosition.y);
            */
        }
    }
    #endregion
}