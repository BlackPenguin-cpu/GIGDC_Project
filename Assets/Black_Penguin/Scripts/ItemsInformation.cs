using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//해당 스크립트는 사용되지 않은 스크립트이지만
//스크립트가 이쁘게 짜였기에 남겨놓는다

abstract class cursedKnife : ItemInformation
{
    public float cooldown;
    public float curCooldown;
    public cursedKnife(string name, string description)
        : base(name, description)
    {
        name = "저주받은 단검";
        description = $"{cooldown}마다 가장 가까운 적이 공격을 받는다.";
    }
    public override abstract void ItemAction();
}

public abstract class ItemInformation
{
    protected ItemInformation(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
    public abstract void ItemAction();
    public string name;
    public string description;
}