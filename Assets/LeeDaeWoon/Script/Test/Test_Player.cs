using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player : MonoBehaviour
{
    PlayerController mPlayerController;

    // Start is called before the first frame update
    // 첫 번째 프레임 업데이트 전에 Start가 호출됩니다.
    private void Start()
    {
        mPlayerController = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    // 업데이트는 프레임 당 한 번 호출됩니다.
    private void Update()
    {
        PCInput();
    }

    private void FixedUpdate()
    {

    }

    private void PCInput()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = (Vector3.up * v) + (Vector3.right * h);
        mPlayerController.MoveVector3 = moveVector;
    }

}