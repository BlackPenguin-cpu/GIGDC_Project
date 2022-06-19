using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
public class ObjectPoolClass
{
    public GameObject parentObj = new GameObject();
    public Queue<GameObject> objQueue = new Queue<GameObject>();
}

public class ObjectPool : MonoBehaviour
{
    static public ObjectPool Instance;
    public Dictionary<string, ObjectPoolClass> ParentObj = new Dictionary<string, ObjectPoolClass>();
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
        if (ParentObj.ContainsKey(obj.name) == false)
        {
            GameObject newObj = new GameObject();
            newObj.transform.parent = gameObject.transform;
            newObj.name = obj.name + "_ParentObj";
            ParentObj[obj.name] = new ObjectPoolClass() { parentObj = newObj, objQueue = new Queue<GameObject>() };
            ParentObj[obj.name].parentObj = newObj;

            return Instantiate(obj, ParentObj[obj.name].parentObj.transform);
        }
        else
        {
            if (ParentObj[obj.name].objQueue.Count > 0)
            {
                GameObject returnObj = ParentObj[obj.name].objQueue.Dequeue();
                returnObj.SetActive(true);
                return returnObj;
            }
            else
            {
                GameObject returnObj = Instantiate(obj, ParentObj[obj.name].parentObj.transform);
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
        if (ParentObj.ContainsKey(textCloneRemove(obj.name)))
        {
            ParentObj[textCloneRemove(obj.name)].objQueue.Enqueue(obj);
            obj.gameObject.SetActive(false);
            obj.transform.position = Vector3.zero;
        }
        else
        {
            Debug.Log("������ƮǮ ���� �߻� (�� ��ü�� ������ƮǮ ��ü�� �ƴմϴ�)");
            Destroy(obj);
        }
    }
    string textCloneRemove(string objName)
    {
        StringBuilder builder = new StringBuilder(objName);
        builder.Replace("(Clone)", "");
        return builder.ToString();
    }
}