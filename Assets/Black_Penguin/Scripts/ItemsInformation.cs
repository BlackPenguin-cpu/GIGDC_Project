using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ش� ��ũ��Ʈ�� ������ ���� ��ũ��Ʈ������
//��ũ��Ʈ�� �̻ڰ� ¥���⿡ ���ܳ��´�

abstract class cursedKnife : ItemInformation
{
    public float cooldown;
    public float curCooldown;
    public cursedKnife(string name, string description)
        : base(name, description)
    {
        name = "���ֹ��� �ܰ�";
        description = $"{cooldown}���� ���� ����� ���� ������ �޴´�.";
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