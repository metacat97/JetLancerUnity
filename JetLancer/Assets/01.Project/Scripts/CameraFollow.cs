using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public planeController playerController;


    // Update is called once per frame
    void Update()
    {
        // ī�޶�� �÷��̾��� z ������ �������� ������ ��������ϴ�.
        //transform.position = playerController.transform.position;    
        transform.position = new Vector3(playerController.transform.position.x, playerController.transform.position.y, -10f);

    }
}
