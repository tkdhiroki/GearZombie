using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMgr : MonoBehaviour
{
    [SerializeField]
    int bgmnum;
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        SoundMgr.BgmPlay(bgmnum);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
            SceneLoadManager.LoadScene("test");
    }
    public void resetButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        SoundMgr.BgmPlay(bgmnum);
    }
    public void nextButton()
    {
        bgmnum++;
        check=SoundMgr.BgmPlay(bgmnum);
        if(!check)
        {
            bgmnum = -1;
            nextButton();
        }
    }
}
