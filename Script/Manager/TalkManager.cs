using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    Dictionary<int, Sprite> nameData;

    public Sprite[] portraitArr;
    public Sprite[] nameArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        nameData = new Dictionary<int, Sprite>();
       
        GenerateData();
        
    }

    void GenerateData()
    {
        //대화 데이터
        talkData.Add(1000, new string[] {"아.. 뭐야 또 비오는 건가?:0:0","비는 안오는데? 뭐지?:0:0", "엇? 전서구? 누가 보낸거지?:0:0", "(아무것도 없는 편지지이다. 시큼한 냄새가 난다.):0:0", "엥? 비밀편지? 누군가가 또 나한테 비밀의뢰를 하려는 모양이군... 후훗:0:0", "누가 그런진 몰라도 한 번 풀어봐야겠는걸?:0:0", "(퀴즈를 풀고 편지지를 찾자):0:0" }); //레일리 독백
        talkData.Add(2000, new string[] { "음... 역시 양초를 대고 보니까 글씨가 나타났어!:0:0", "(편지를 보낸 사람은 공중에 떠있는 기계도시, 레헬른의 시장으로, 편지의 비밀을 풀고 이 글을 읽고 있다면 레헬른에 일어난 심각한 문제를 해결하기 위해 고용하겠다는 내용이 담겨져 있었다.):0:0","모처럼 오랜만에 의뢰가 들어왔는데 이걸 마다하는 것도 실례겠지? 바로 출발 해볼까?:0:0", "(왼쪽 포탈을 타고 선착장으로 이동하자):0:0" }); //퀴즈 풀었을때 대사
        talkData.Add(3000, new string[] { "(경비병에게 검문을 마친 레일리는 레헬른의 선착장에 발을 디뎠다.):0:0", "음? 선착장에 사람이 왜 이렇게 없지? 의뢰 내용 때문에 그런걸까?:0:0", "안녕하십니까? 레일리님 맞으신가요? 저희도시까지 와주셔서 감사합니다.:1:1","네 이번에 의뢰를 받고 온 레일리라고 합니다. 근데 시장님이 직접 나오신건가요?:0:0","아닙니다, 저는 시장님의 비서 그리즐리입니다.:1:1", "시장님께서 레일리님을 의회로 모시라는 명령을 받았습니다. 다만 마을로 가는 도개교에 문제가 생겨 잠시 기다려야 할 것 같습니다.:1:1", "...혹시 제가 문제를 해결해볼 수 있을까요?:0:0" }); //비서 - 레일리
        talkData.Add(4000, new string[] { "(도개교 열쇠를 구멍에 끼운 후 돌렸다.):0:0", "됐어요! 이제 빨리 의회로 가요!:0:0","역시 레일리님이시군요... 알겠습니다.:1:1", "(오른쪽 포탈을 타고 의회로 이동하자):0:0" }); //퀴즈 풀었을 때 대사
        talkData.Add(5000, new string[] { "(레일리는 비서와 함께 시장이 있는 의회에 다다른다.):0:0", "(레일리는 비서의 안내를 받아 의회 안으로 들어간다.):0:0","안녕하세요. 레일리 양 이렇게 와주셔서 정말 감사드립니다.:2:2","아 넵 시장님 이시죠?:0:0","네네 천공도시 레헬른의 시장 브라함입니다.:2:2","그래서 제가 해야 할 일이 무엇일까요?:0:0", "레헬른에는 총 5개의 중추기관이 존재하는데 현재 3개가 파괴되어 레헬른이 추락 위기에 처해 있습니다. 파괴원인과 해결방안을 알아봐 주실 수 있을까요?:2:2","흐음... 그렇군요. 이 도시가 추락하면 무고한 시민분 들이 피해를 입을 수도 있으니 협조하도록 하겠습니다.:0:0","근데 제가 이 도시를 잘 몰라서 그러는데 지도를 제공 받을 수 있을까요?:0:0","허허... 레일리님이 접근 하실 곳은 레헬른의 중추시설들이라 지도에 따로 표기는 하지 않고 있습니다. 또, 곳곳이 잠겨있기도 해서 중추시설을 관리하고 있는 에림을 도우미로 붙여드리면 될까요?:2:2", "아~ 네 감사합니다!:0:0", "안녕하세요 레일리님 레헬른의 엔지니어 에림이라고 합니다:3:3", "에림 안녕~ 만나서 반가워~ 시장님 그럼 에림이랑 가면 되나요?:0:0 ", "네, 에림과 함께 중추기관의 조사를 부탁드리겠습니다:2:2", "넵 알겠습니다. 에림 가자~:0:0","(포탈을 타고 시장실을 나가보자):0:0" });
        //talkData.Add(6000, new string[] { "이 문제, 작년에 레헬른 엔지니어 시험에서 저만 맞춰서 제가 엔지니어가 될 수 있었던 문제인데...! 대단하시군요!:3:3", "어? 이문제 제가 몇 년 전에 신문에 투고했던 문제를 살짝 비꼰 문제인데...:0:0", "정말입니까? 대단하신분이시네요!:3:3", "에림, 레일리는 탐정이기도 하지만 자신의 마을에선 엔지니어도 겸업하는 엔지니어랍니다?:2:2", "하핫... 진작에 말씀해주시지...:3:3", "그래도 간만에 제가 만든 문제를 다시 풀어보니 감회가 새로웠습니다 감사합니다 에림:0:0", "그럼, 에림과 함께 중추기관의 조사를 부탁드리겠습니다:2:2", "넵 알겠습니다.:0:0", "자~ 그럼 이제 가볼까요?:3:3","(포탈을 타고 시장실을 나가보자):0:0" }); //에림 - 레일리 - 시장 대화
        talkData.Add(7000, new string[] {"화창하고도 평화로운 어느날 아침","레일리는 무언가가 창문을 툭툭 치는 소리가 거슬려 기지개를 펴고 일어난다.","(창문 쪽에 있는 새에게 말을 걸어보자)"}); //첫 씬 페이드인/페이드아웃 대사
        talkData.Add(8000, new string[] { "여긴 E-07 구역이에요 겉보기엔 마을 같은데, 중추기관이 근처에 있어서 저 같은 엔지니어만 들어올 수 있는 구역이죠:3:3", "그럼 저기 바로 앞이 중추기관 입구인거야?:0:0", "아니요, 가끔 이곳에 방문하는 외부인들이 있어서 하실을 거쳐서 중추기관에 들어 갈 수 있도록 설계 되었습니다. 그럼 가볼까요?:3:3" }); // 에림 - 레일리 대화
        talkData.Add(9000, new string[] { "마차가 막고있어서 더는 앞으로 못지나 갈 것 같은데요?:0:0", "음... 그러게 무슨일이지? 여쭤봐야겠는데?:3:3", "안녕하세요~ 저희가 이 길을 지나가야 하는데 마차가 길을 막고 있네요? 무슨 일 있으신가요? 도와드리겠습니다.:0:0", "아, 나는 카르마인데, 자네는 우리 도련님께서 뵙고자 하는 자가 아닌가보군? 어허… 어디 도련님 근처를 오려 하는 것인가! 썩 물러가지 못할까!!:4:4", "아~ 실례했어요! (이런! 이 마차를 지나가야해! 어라라? 이 마차를 잠깐 보니 이상하네?):0:0" ,"(퀴즈를 풀고, 마차를 고쳐보자!):0:0"});
        talkData.Add(6000, new string[] {"어? 저쪽은 중추기관쪽이에요! 빨리 가봐요!:3:3","가봐야겠는데?:0:0","(맵의 오른쪽 끝으로 이동하자):0:0"}); //에림 - 레일리 대화

        //초상화 데이터
        portraitData.Add(1000 + 0,portraitArr[0]); //레일리 초상화 데이터

        portraitData.Add(2000 + 0, portraitArr[0]); //레일리 초상화 데이터

        portraitData.Add(3000 + 0, portraitArr[0]); //레일리 초상화 데이터
        portraitData.Add(3000 + 1, portraitArr[1]); //비서 초상화 데이터

        portraitData.Add(4000 + 0, portraitArr[0]); //레일리 초상화 데이터
        portraitData.Add(4000 + 1, portraitArr[1]); //비서 초상화 데이터

        portraitData.Add(5000 + 0, portraitArr[0]); //레일리 초상화 데이터
        portraitData.Add(5000 + 2, portraitArr[2]); //사장 초상화 데이터
        portraitData.Add(5000 + 3, portraitArr[3]); //에림 초상화 데이터


        portraitData.Add(8000 + 0, portraitArr[0]); //레일리 초상화 데이터
        portraitData.Add(8000 + 3, portraitArr[3]); //에림 초상화 데이터

        portraitData.Add(9000 + 0, portraitArr[0]); //레일리 초상화 데이터
        portraitData.Add(9000 + 3, portraitArr[3]); //에림 초상화 데이터
        portraitData.Add(9000 + 4, portraitArr[4]); //카르마 초상화 데이터

        portraitData.Add(6000 + 0, portraitArr[0]); //레일리 초상화 데이터
        portraitData.Add(6000 + 3, portraitArr[3]); //에림 초상화 데이터

        //이름 데이터
        nameData.Add(1000 + 0 + 0, nameArr[0]); //레일리 이름 데이터

        nameData.Add(2000 + 0 + 0, nameArr[0]); //레일리 이름 데이터

        nameData.Add(3000 + 0 + 0, nameArr[0]); //레일리 이름 데이터
        nameData.Add(3000 + 0 + 1, nameArr[1]); //비서 이름 데이터

        nameData.Add(4000 + 0 + 0, nameArr[0]); //레일리 이름 데이터
        nameData.Add(4000 + 0 + 1, nameArr[1]); //비서 이름 데이터

        nameData.Add(5000 + 0 + 0, nameArr[0]); //레일리 이름 데이터
        nameData.Add(5000 + 0 + 2, nameArr[2]); //사장 이름 데이터
        nameData.Add(5000 + 0 + 3, nameArr[3]); //에림 이름 데이터

        nameData.Add(6000 + 0 + 0, nameArr[0]); //레일리 이름 데이터
        nameData.Add(6000 + 0 + 3, nameArr[3]); //에림 이름 데이터

        nameData.Add(8000 + 0 + 0, nameArr[0]); //레일리 이름 데이터
        nameData.Add(8000 + 0 + 3, nameArr[3]); //에림 이름 데이터

        nameData.Add(9000 + 0 + 0, nameArr[0]); //레일리 이름 데이터
        nameData.Add(9000 + 0 + 3, nameArr[3]); //에림 이름 데이터
        nameData.Add(9000 + 0 + 4, nameArr[4]); //카르마 이름 데이터

    }

    public string GetTalk(int id,int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

    public Sprite GetName(int id, int nameIndex)
    {
        return nameData[id + nameIndex];
    }
}
