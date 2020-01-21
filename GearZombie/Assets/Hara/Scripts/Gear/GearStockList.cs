using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class GearStockList : SingletonMonoBehaviour<GearStockList>
{
    [SerializeField] private GearItemView[] GearItemList = new GearItemView[4];
    private int randomSeed = 20;
    private int gearLine = 160;

    // sprite pool
    [SerializeField] private GameObject plusOneSprite = null;
    private List<SpriteRenderer> spritePool = new List<SpriteRenderer>();
    private GameObject parent;
    // animation
    private float alphaTime = 0.8f;

    private void Start()
    {
        parent = new GameObject("plusParent");

        // create pool
        for (int i = 0; i < 8; i++)
        {
            var obj = Instantiate(plusOneSprite, parent.transform);
            spritePool.Add(obj.GetComponent<SpriteRenderer>());
            obj.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetGearStockAdd();
        }
        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    GearGetAnimation(Vector3.zero);
        //}
    }

    // 在庫にplusする
    public void GetGearStockAdd()
    {
        int getGear = UnityEngine.Random.Range(0, randomSeed) * 10;
        if (getGear < gearLine - 1) return;

        //Debug.Log("GET!1");

        int id = UnityEngine.Random.Range(0, GearItemList.Length * 10);
        id = Mathf.FloorToInt(id / 10f);
        Debug.Log(id + "+" + GearItemList[id].Stock);
        GearItemList[id].Stock = GearItemList[id].Stock + 1;
        Debug.Log(GearItemList[id].Stock);
        GearGetAnimation(Vector3.zero, GearItemList[id].GearColor);
    }

    /// <summary>
    /// GearをゲットしたときのAnimation
    /// </summary>
    /// <param name="pos">表示Position</param>
    public void GearGetAnimation(Vector3 pos, Color col)
    {
        Debug.Log(col);
        SpriteRenderer sprite = spritePool.FirstOrDefault(X => !X.gameObject.activeSelf);
        sprite.color = new Color(col.r, col.g, col.b, 0);

        sprite.transform.position = pos;
        var diplace = pos.y * 20f / 10f;

        sprite.gameObject.SetActive(true);

        // DoTween
        Sequence seq = DOTween.Sequence();
        seq.Append(
            DOTween.To(
                () => sprite.color.a,
                num => sprite.color += new Color(0, 0, 0, num),
                1f,
                alphaTime * 2)
            )
           .Append(
            sprite.transform.DOMoveY(diplace, 0.5f)
            )
           .Join(
            DOTween.To(
                () => sprite.color.a,
                num => sprite.color -= new Color(0, 0, 0, num),
                0f,
                alphaTime * 2)
            ).OnComplete(() =>
            {
                sprite.gameObject.SetActive(false);
            });
    }
}
