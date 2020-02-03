using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class FireGimmick : MonoBehaviour
{
    [SerializeField] private TrapListControl trapListControl = null;

    private readonly float remainFireTime = 3.5f;
    
    private Vector3 attackPosition = Vector3.zero;
    private Vector3 position = Vector3.zero;
    private bool isClick = false;
    public bool IsClick {get { return isClick; } set { isClick = value; }}
    //---------------
    private List<GameObject> damagesZombies = new List<GameObject>();
    private bool fireFlag = false;
    private float time = 0;
    [SerializeField, Header("炎の画像たち")] private List<SpriteRenderer> fireSprites  = new List<SpriteRenderer>();
    //----------------------
   // [SerializeField, Header("ギミック発動の説明UI")] private GameObject detailUI = null;

    private void Start() {
        ColliderSwitch(false);
    }
    private Vector3 MousePointUpdate()
    {
        position = Input.mousePosition;
        position.z = 10f;
        attackPosition = Camera.main.ScreenToWorldPoint(position);
        attackPosition.x = Mathf.Clamp(attackPosition.x, -5f, 8f);
        attackPosition.y = 0f;
        return attackPosition;   
    }
    private void Update() {
        if(!isClick) return;

        this.transform.position = MousePointUpdate();
        // 右クリックでreset
        if(Input.GetMouseButtonDown(1)) 
        {
            isClick = false; //MainScript.instance.IsOPenFlagChange(true);
            ColliderSwitch(false);
        }
        // クリックで発動
        if(Input.GetMouseButtonDown(0))
        {
            FireDamage();
        }
    }

    public void ColliderSwitch(bool flag)
    {
        this.GetComponent<Collider2D>().enabled = flag;
        this.gameObject.SetActive(flag);
         //detailUI.SetActive(flag);
    }

    private void FireDamage()
    {
        Debug.Log("Fire");
        FireFadeIn();
        damagesZombies.ForEach( x => x.GetComponent<ZombieScript>().Damaged(10));
        fireFlag = true; time = 0;
        
        StartCoroutine(FireTerrain());

        isClick = false; //MainScript.instance.IsOPenFlagChange(true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(fireFlag)
        {
            other.gameObject.GetComponent<ZombieScript>().Damaged(2);
            return;
        }
        if(!damagesZombies.Contains(other.gameObject)) damagesZombies.Add(other.gameObject);
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(damagesZombies.Contains(other.gameObject)) damagesZombies.Remove(other.gameObject);
    }
    private IEnumerator FireTerrain()
    {
        while(time < remainFireTime)
        {
            time += Time.deltaTime;
            yield return null;
        }
        fireFlag = false;
        FireFadeOut();
    }

    private void FireFadeIn()
    {
        fireSprites.ForEach( x => x.DOFade(1.0f, 0.5f));
    }
    private void FireFadeOut()
    {
        fireSprites.ForEach(x => x.DOFade(0f, 0.5f).OnComplete(() => ColliderSwitch(false)));
        trapListControl.UseTrap();
        //ColliderSwitch(false);
    }
}
