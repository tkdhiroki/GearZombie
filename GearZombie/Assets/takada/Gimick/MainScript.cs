using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainScript : SingletonMonoBehaviour<MainScript>
{
    public bool isOpen = true;

    // Gimmick の　UI
    [SerializeField] private Text txt = null;
    [SerializeField] private ZombieCreate zombie = null;
    
    void Start()
    {
        var col = txt.color;
        col.a = 0;
        txt.color = col;

        txt.DOFade(1.0f, 2f).SetEase(Ease.InExpo)
                     .OnComplete(() => txt.DOFade(0, 1f).OnComplete(() =>
                     {
                         zombie.FieldZombieInit();
                         txt.gameObject.SetActive(false);
                       }
                     ));
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneLoadManager.LoadScene("Title");
        }
    }

}
