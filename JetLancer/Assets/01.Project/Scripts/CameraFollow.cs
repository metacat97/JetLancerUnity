using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public planeController playerController;


    // Update is called once per frame
    void Update()
    {
        // 카메라와 플레이어의 z 간격이 같아져서 문제가 생겼었습니다.
        //transform.position = playerController.transform.position;    
        transform.position = new Vector3(playerController.transform.position.x, playerController.transform.position.y, -10f);

    }
}
