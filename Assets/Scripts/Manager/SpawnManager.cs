using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : BaseManager<SpawnManager>
{
    public float spawnRadius = 1f;

    private MonsterTable _table;
    private Player _player;

    private void Awake()
    {
        _table = Resources.Load<MonsterTable>("MonsterTable"); // 인스턴스 X -> 불러오는것이지 메모리가 증가하지는 않습니다.
        _player = FindObjectOfType<Player>();
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        int curIndex = 0;
        MonsterSpawnData curSpawnData = _table.spawnDataList[curIndex];

        float spawnTime = curSpawnData.spawnDelayTime;
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            int sumRate = 0;

            for(int i = 0 ; i < curSpawnData.spawnInfoArray.Length ; i++)
            {
                sumRate += curSpawnData.spawnInfoArray[i].spawnRate;
            }

            for (int i = 0; i < curSpawnData.spawnInfoArray.Length; i++)
            {
                float ratio = curSpawnData.spawnInfoArray[i].spawnRate / (float)sumRate;
                 
                if(Random.Range(0,1f) <= ratio)
                {
                    yield return Spawn(curSpawnData.spawnInfoArray[i]);
                    break;
                }
            }
        }
    }


    public IEnumerator Spawn(MonsterSpawnInfo info)
    {
        foreach(MonsterData data in _table.dataList)
        {
            if(data.name == info.name)
            {
                Vector3 resultVec = Quaternion.Euler(0, 0, Random.Range(0, 360)) * Vector3.up;

                for (int i = 0; i < info.spawnCount; i++)
                { 
                    GameObject obj = Instantiate(_table.monsterPrefab);
                    Monster script = obj.GetComponent<Monster>();
                    script.SetData(data);
                    obj.transform.position = _player.transform.position + resultVec * spawnRadius;

                    yield return new WaitForSeconds(0.01f);
                }

                break;
            }
        }
    }
}
