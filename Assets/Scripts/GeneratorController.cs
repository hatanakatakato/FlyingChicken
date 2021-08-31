using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    //外部からprefab取得
    public GameObject bombPrefab;
    public GameObject friedChickenPrefab;
    public GameObject woodPrefab;
    //外部からコンポーネント取得
    public Transform playerTransform;

    //アイテム生成開始位置Y
    [SerializeField] float nextItemAppearPosY = 8f;
    //次の柵生成位置
    private int nextWoodAppearPodsY = 20;
    //次の爆弾の列は難か簡単かを区別するために作る
    private bool nextIsHard = false;
    //空白列でフライドチキンが出る確率(1/friedChickenProb)
    [SerializeField] int friedChickenProb = 30;



    void Start()
    {
    }

    void Update()
    {

        //爆弾またはフライドチキンを生成
        if (this.nextItemAppearPosY - playerTransform.position.y < 20f)
        {

            //次のアイテム生成位置とチキンとの距離が20より大きくなるまで
            while (this.nextItemAppearPosY - playerTransform.position.y < 20f)
            {
                //爆弾もしくはフライドチキンを生成する
                GenerateItemPrefab();
            }

        }

        //woodPrefabを生成
        if(this.nextWoodAppearPodsY - playerTransform.position.y < 20f)
        {
            //画面の両端に作成
            GameObject instance1 = Instantiate(this.woodPrefab);
            GameObject instance2 = Instantiate(this.woodPrefab);
            instance1.transform.position = new Vector2(-4, this.nextWoodAppearPodsY);
            instance2.transform.position = new Vector2(4, this.nextWoodAppearPodsY);
            nextWoodAppearPodsY += 10;
        }


    }

    //フライドチキン,難しい爆弾列,簡単な爆弾列を生成するメソッド
    void GenerateItemPrefab()
    {
        //偶数列なら空白列orフライドチキン
        //奇数列なら爆弾列(簡単と難しいを交互に出す)
        if (this.nextItemAppearPosY % 2 == 0)
        {
            //ランダムでフライドチキンを出す
            int num = Random.Range(1, this.friedChickenProb + 1);
            if(num == 1)
            {
                //座標をランダムに決める
                int instancePosX = Random.Range(-3, 4);
                GameObject instance = Instantiate(this.friedChickenPrefab);
                instance.transform.position = new Vector2(instancePosX, this.nextItemAppearPosY);
            }
        }
        else
        {
            if (this.nextIsHard)
            {
                //難しい列の爆弾を作る
                GenerateHardBombRow();
                this.nextIsHard = false;
            }
            else
            {
                //爆弾をひとつ作る
                int instancePosX = Random.Range(-3, 4);
                GameObject instance = Instantiate(this.bombPrefab);
                instance.transform.position = new Vector2(Random.Range(-3, 4), this.nextItemAppearPosY);
                this.nextIsHard = true;
            }

        }

        //次のアイテム出現位置を決定
        this.nextItemAppearPosY += 1f;
    }


    //難しい爆弾列を作るメソッド
    void GenerateHardBombRow()
    {
        //爆弾のx座標をランダムに決める(後で配列の前から入れていく感じ)
        int[] posX = new int[] {-3, -2, -1, 0, 1, 2, 3 };
        for (int i = 0; i < posX.Length; i++)
        {
            int temp = posX[i];
            int randomIndex = Random.Range(0, posX.Length);
            posX[i] = posX[randomIndex];
            posX[randomIndex] = temp;
        }

        //爆弾の数を決める２個か3個か,チキンのyが500になったら100%3個生成する。
        int bombNumber;
        float percent = playerTransform.position.y / 5;
        int num = Random.Range(1, 100);
        if(num < percent)
        {
            bombNumber = 3;
        }
        else
        {
            bombNumber = 2;
        }

        //生成する
        for(int i = 0; i < bombNumber; i++)
        {
            int instancePosX = Random.Range(-4, 5);
            GameObject instance = Instantiate(this.bombPrefab);
            instance.transform.position = new Vector2(posX[i], this.nextItemAppearPosY);
        }
    }


}
