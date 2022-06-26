using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 오브젝트풀 전용 오브젝트를 위한 인터페이스이다
/// </summary>
public interface IObjectPoolingObj
{
    /// <summary>
    /// 이 함수는 오브젝트 풀로 처음 생성됬을때 발동된다
    /// </summary>
    void OnObjCreate();
}
