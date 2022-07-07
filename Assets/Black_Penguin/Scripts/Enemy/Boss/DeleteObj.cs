using UnityEngine;

public class DeleteObj : MonoBehaviour, IObjectPoolingObj
{
    private ParticleSystem ps;
    private ParticleSystem ps2;

    public void OnObjCreate()
    {
    }

    public void Start()
    {
        ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        ps2 = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (this.gameObject.transform.localPosition.y < 0)
        {
            var main = ps.main;
            var main2 = ps2.main;
            main.gravityModifierMultiplier = -1f;
            main2.gravityModifierMultiplier = -1f;
        }
    }

    void DeleteThis()
    {
        ObjectPool.Instance.DeleteObj(gameObject);
    }

}
