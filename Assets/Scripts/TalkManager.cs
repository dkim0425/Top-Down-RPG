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
        talkData.Add(1000, new string[] { "안녕?:0", 
                                          "이 곳에 처음 왔구나?:1" });
        talkData.Add(2000, new string[] { "처음보는 얼굴인데?:0", 
                                          "여기가 어디냐고? 무슨 헛소리야.:3", 
                                          "귀찮게 하지말고 저리가. 이 몸은 바쁘시단 말이다.:3" });

        talkData.Add(100, new string[] { "나무상자다. 안에 쓸만한건 없다." });
        talkData.Add(200, new string[] { "책상이다." });

        portraitData.Add(1000 + 0, portraitArr[0]); // idle
        portraitData.Add(1000 + 1, portraitArr[1]); // talk
        portraitData.Add(1000 + 2, portraitArr[2]); // smile
        portraitData.Add(1000 + 3, portraitArr[3]); // angry
        portraitData.Add(2000 + 0, portraitArr[4]); // idle
        portraitData.Add(2000 + 1, portraitArr[5]); // talk
        portraitData.Add(2000 + 2, portraitArr[6]); // smile
        portraitData.Add(2000 + 3, portraitArr[7]); // angry

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "어서 와.:0",
                                               "이곳은 테스트 마을이야.:2",
                                               "오른쪽에 있는 루도한테 가라는 퀘스트를 줄게~:1",
                                               "바빠보이지만 하나도 안바쁘니까 한번 가봐.:2"});
        talkData.Add(11 + 2000, new string[] { "뭐야? 바쁜거 안보여?:3",
                                               "루나가 시켜서 왔다고? 오늘 바쁘다니까 진짜..:3",
                                               "온김에 집 주변에 있는 돌이나 좀 갖다 줘.:1"});

        talkData.Add(20 + 1000, new string[] { "돌을 가져다 달라 했다고?:0",
                                               "처음 본 사람한테 할 소린가..:3",
                                               "내가 대신 사과할게 그럴 애가 아닌데 오늘은 정말 바쁜가봐..:1",
                                               "이번만 좀 도와줄래? 나도 부탁할게.:0"});
        talkData.Add(20 + 2000, new string[] { "가져다 줄거야 말거야? 안 가져다 줄거면 저리가!:3" });
        talkData.Add(20 + 5000, new string[] { "돌을 찾았다. 생각보다 가볍다. 이걸로 뭘 하려는걸까?" });

        talkData.Add(21 + 2000, new string[] { "진짜 가져왔어?:0",
                                               "음.. 그래 나는 루도야.:1",
                                               "까칠하게 굴어서 미안해. 실은 이 호수를 가꾸고 있었거든.:2",
                                               "너도 호수 가꾸는 걸 좀 도와줄래?:1"});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id)) // 해당 퀘스트 진행 순서 대사가 없을 때 퀘스트 맨 처음 대사를 가지고 온다.
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                // 퀘스트 맨 처음 대사마저 없을 때.
                // 기본 대사를 가지고 온다.
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
