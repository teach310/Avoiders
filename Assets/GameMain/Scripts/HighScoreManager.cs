using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class HighScoreManager : MonoBehaviour
{
    const string TABLE_NAME = "HighScore";
    const string USERNAME = "Username";
    const string HIGH_SCORE = "HighScore";

    public int myRank;
    public List<HighScore> highScoreList;
    public List<HighScore> myHighScoreList;

    public void SendHighScore(int score)
    {
        NCMBObject obj = new NCMBObject(TABLE_NAME);
        obj.Add(USERNAME, PlayerPrefs.GetString("name"));
        obj.Add(HIGH_SCORE, score);
        if (PlayerPrefs.HasKey("ObjectId"))
            obj.ObjectId = PlayerPrefs.GetString("ObjectId");
        obj.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                //エラー処理
                Debug.Log("score data failed");
            }
            else
            {
                //成功時の処理
                Debug.Log("score data sent successfully");
                PlayerPrefs.SetString("ObjectId", obj.ObjectId);
            }
        });
    }

    public void FetchMyRank(System.Action onSuccess)
    {
        // データスコアの「HighScore」から検索
        NCMBQuery<NCMBObject> rankQuery = new NCMBQuery<NCMBObject>(TABLE_NAME);
        rankQuery.WhereGreaterThan(HIGH_SCORE, PlayerPrefs.GetInt("score"));
        rankQuery.CountAsync((int count, NCMBException e) =>
        {
            if (e != null)
            {
                //件数取得失敗
            }
            else
            {
                //件数取得成功
                myRank = count + 1; // 自分よりスコアが上の人がn人いたら自分はn+1位
                FetchMyRankingData(() => onSuccess());
            }
        });
    }

    public void FetchTopRankingData(System.Action onSuccess)
    {
        // データストアの「HighScore」クラスから検索
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(TABLE_NAME);
        query.OrderByDescending(HIGH_SCORE);
        query.Limit = 100;
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                //検索失敗時の処理
            }
            else
            {
                //検索成功時の処理
                List<HighScore> list = new List<HighScore>();
                // 取得したレコードをHighScoreクラスとして保存
                foreach (NCMBObject obj in objList)
                {
                    int s = System.Convert.ToInt32(obj[HIGH_SCORE]);
                    string n = System.Convert.ToString(obj[USERNAME]);
                    list.Add(new HighScore(s, n));
                }
                highScoreList = list;
                onSuccess();
            }
        });
    }

    void FetchMyRankingData(System.Action onSuccess)
    {
        // スキップする数を決める（ただし自分が1位か2位のときは調整する）
        int numSkip = myRank - 10;
        if (numSkip < 0) numSkip = 0;

        // データストアの「HighScore」クラスから検索
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(TABLE_NAME);
        query.OrderByDescending(HIGH_SCORE);
        query.Skip = numSkip;
        query.Limit = 20;
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                //検索失敗時の処理
            }
            else
            {
                //検索成功時の処理
                List<HighScore> list = new List<HighScore>();
                // 取得したレコードをHighScoreクラスとして保存
                foreach (NCMBObject obj in objList)
                {
                    int s = System.Convert.ToInt32(obj[HIGH_SCORE]);
                    string n = System.Convert.ToString(obj[USERNAME]);
                    list.Add(new HighScore(s, n));
                }
                myHighScoreList = list;
                onSuccess();
            }
        });
    }
}
