using UnityEngine;

public class EnemyPool : MonoBehaviour 
{
	public int enemyNumb;
	public GameObject[] templateEnemy;

	void Start ()
	{
        for (int i = 0; i < enemyNumb; ++i)
			Instantiate(templateEnemy[Random.Range(0, 3)]);
    }
}
