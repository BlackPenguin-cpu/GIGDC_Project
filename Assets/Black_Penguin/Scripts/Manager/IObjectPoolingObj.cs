using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ƮǮ ���� ������Ʈ�� ���� �������̽��̴�
/// </summary>
public interface IObjectPoolingObj
{
    /// <summary>
    /// �� �Լ��� ������Ʈ Ǯ�� ó�� ���������� �ߵ��ȴ�
    /// </summary>
    void OnObjCreate();
}
