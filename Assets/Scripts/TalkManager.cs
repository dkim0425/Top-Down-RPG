using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?:0", 
                                          "�� ���� ó�� �Ա���?:1" });
        talkData.Add(2000, new string[] { "ó������ ���ε�?:0", 
                                          "���Ⱑ ���İ�? ���� ��Ҹ���.:3", 
                                          "������ �������� ������. �� ���� �ٻڽô� ���̴�.:3" });

        talkData.Add(100, new string[] { "�������ڴ�. �ȿ� �����Ѱ� ����." });
        talkData.Add(200, new string[] { "å���̴�." });

        portraitData.Add(1000 + 0, portraitArr[0]); // idle
        portraitData.Add(1000 + 1, portraitArr[1]); // talk
        portraitData.Add(1000 + 2, portraitArr[2]); // smile
        portraitData.Add(1000 + 3, portraitArr[3]); // angry
        portraitData.Add(2000 + 0, portraitArr[4]); // idle
        portraitData.Add(2000 + 1, portraitArr[5]); // talk
        portraitData.Add(2000 + 2, portraitArr[6]); // smile
        portraitData.Add(2000 + 3, portraitArr[7]); // angry

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "� ��.:0",
                                               "�̰��� �׽�Ʈ �����̾�.:2",
                                               "�����ʿ� �ִ� �絵���� ����� ����Ʈ�� �ٰ�~:1",
                                               "�ٺ��������� �ϳ��� �ȹٻڴϱ� �ѹ� ����.:2"});
        talkData.Add(11 + 2000, new string[] { "����? �ٻ۰� �Ⱥ���?:3",
                                               "�糪�� ���Ѽ� �Դٰ�? ���� �ٻڴٴϱ� ��¥..:3",
                                               "�±迡 �� �ֺ��� �ִ� ���̳� �� ���� ��.:1"});

        talkData.Add(20 + 1000, new string[] { "���� ������ �޶� �ߴٰ�?:0",
                                               "ó�� �� ������� �� �Ҹ���..:3",
                                               "���� ��� ����Ұ� �׷� �ְ� �ƴѵ� ������ ���� �ٻ۰���..:1",
                                               "�̹��� �� �����ٷ�? ���� ��Ź�Ұ�.:0"});
        talkData.Add(20 + 2000, new string[] { "������ �ٰž� ���ž�? �� ������ �ٰŸ� ������!:3" });
        talkData.Add(20 + 5000, new string[] { "���� ã�Ҵ�. �������� ������. �̰ɷ� �� �Ϸ��°ɱ�?" });

        talkData.Add(21 + 2000, new string[] { "��¥ �����Ծ�?:0",
                                               "��.. �׷� ���� �絵��.:1",
                                               "��ĥ�ϰ� ��� �̾���. ���� �� ȣ���� ���ٰ� �־��ŵ�.:2",
                                               "�ʵ� ȣ�� ���ٴ� �� �� �����ٷ�?:1"});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id)) // �ش� ����Ʈ ���� ���� ��簡 ���� �� ����Ʈ �� ó�� ��縦 ������ �´�.
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                // ����Ʈ �� ó�� ��縶�� ���� ��.
                // �⺻ ��縦 ������ �´�.
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];

    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
