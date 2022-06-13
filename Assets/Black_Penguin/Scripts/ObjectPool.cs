using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPoolClass
{
    public GameObject parentObj;
    public Queue<GameObject> objQueue = new Queue<GameObject>();
}

public class ObjectPool : MonoBehaviour
{
    static public ObjectPool Instance;
    public Dictionary<GameObject, ObjectPoolClass> ParentObj;
    public GameObject[] objects;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public GameObject CreateObj(GameObject obj)
    {
        if (ParentObj[obj].parentObj == null)
        {
            GameObject newObj = new GameObject();
            newObj.transform.parent = gameObject.transform;
            ParentObj[obj].parentObj = newObj;

            Instantiate(obj, ParentObj[obj].parentObj.transform);
        }
        else
        {
            if (ParentObj[obj].objQueue.Count > 0)
            {
                GameObject returnObj = ParentObj[obj].objQueue.Dequeue();
                returnObj.SetActive(true);
                return returnObj;
            }
            else
            {
                GameObject returnObj = Instantiate(obj, ParentObj[obj].parentObj.transform);
                return returnObj;
            }
        }
        return null;
    }
    public GameObject CreateObj(GameObject obj, Vector3 pos, Quaternion quaternion)
    {
        GameObject returnObj = CreateObj(obj);
        returnObj.transform.position = pos;
        returnObj.transform.rotation = quaternion;

        return returnObj;
    }
    public void DeleteObj(GameObject obj)
    {
        if (ParentObj[obj].parentObj != null)
        {
            ParentObj[obj].objQueue.Enqueue(obj);
            obj.gameObject.SetActive(false);
            obj.transform.position = Vector3.zero;
        }
        else
        {
            Debug.Assert(false);
            Debug.Log("오브젝트풀 오류 발생 (본 객체는 오브젝트풀 객체가 아닙니다)");
        }
    }
}