using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text TalkText;
    public GameObject scanObject;
    public bool isAction;

    public void Action(GameObject scanObj)
    {
        if(isAction)
        { //Exit Action
            isAction = false;
        }
        else
        { //Enter Action
            isAction = true;
            scanObject = scanObj;
            TalkText.text = "�̰��� �̸���" + scanObj.name + "�̶�� �Ѵ�.";
        }

        talkPanel.SetActive(isAction);
    }
}
