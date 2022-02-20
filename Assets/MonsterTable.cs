using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MonsterTable", menuName = "Table/MonsterTable")]
public class MonsterTable : ScriptableObject
{
    public GameObject monsterPrefab;

    public List<MonsterSpawnData> spawnDataList;
    public List<MonsterData> dataList;
}


[System.Serializable]
public class MonsterSpawnData
{
    public int id;
    public float spawnDelayTime;
    public MonsterSpawnInfo[] spawnInfoArray;
}

[System.Serializable]
public class MonsterSpawnInfo
{
    public string name;
    public int spawnRate;
    public int spawnCount = 1;
}


[System.Serializable]
public class MonsterData
{
    public string name;
    public float hp;
    public float speed;
    public Sprite image;
}