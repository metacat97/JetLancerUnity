using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text gasText;  // 컴포넌트에 가져올 텍스트 오브젝트 칸 만들기
    public planeController playerController;  //가스 가지고 있는 플레이어 컨트롤러에서 가져오기

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gasText.text = string.Format("{0} / 100", playerController.gas.ToString("F0")); 
    }
}
