using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Weapon,
    PowerUp,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public string objName;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;


}