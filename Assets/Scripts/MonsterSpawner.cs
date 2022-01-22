using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    private GameObject spawnedMonster;
    // Start is called before the first frame update
    [SerializeField]
    private Transform leftPos, rightPos;
    private int randomIndex;
    private int randomSide;
    void Start()
    {
        StartCoroutine(SpwanMonster());
    }

    // Update is called once per frame
    IEnumerator SpwanMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            if (randomSide == 0)
            {
                // spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.transform.position = new Vector3(leftPos.position.x, leftPos.position.y, 0);
                spawnedMonster.GetComponent<Monsters>().speed = Random.Range(4, 10);
            }
            else
            {
                // spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.transform.position = new Vector3(rightPos.position.x, rightPos.position.y, 0);
                spawnedMonster.GetComponent<Monsters>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
