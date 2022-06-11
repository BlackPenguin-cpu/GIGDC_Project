using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player : MonoBehaviour
{
    PlayerController mPlayerController;

    // Start is called before the first frame update
    // ù ��° ������ ������Ʈ ���� Start�� ȣ��˴ϴ�.
    private void Start()
    {
        mPlayerController = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    // ������Ʈ�� ������ �� �� �� ȣ��˴ϴ�.
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