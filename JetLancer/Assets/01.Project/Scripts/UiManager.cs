using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text gasText;  // ������Ʈ�� ������ �ؽ�Ʈ ������Ʈ ĭ �����
    public planeController playerController;  //���� ������ �ִ� �÷��̾� ��Ʈ�ѷ����� ��������

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
