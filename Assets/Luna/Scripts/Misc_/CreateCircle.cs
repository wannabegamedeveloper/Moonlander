using System;
using UnityEngine;

public class CreateCircle : MonoBehaviour
{
    public GameObject enemyPrefab;

    [SerializeField] private int number;
    [SerializeField] private Transform center;
    [SerializeField] private float radius;
    
    private void Start()
    {
        CreateEnemiesAroundPoint(number, center.position, radius);
    }

    private void CreateEnemiesAroundPoint (int num, Vector3 point, float _radius){
     
        for (int i = 0; i < num; i++){
         
            float radians = 2 * Mathf.PI / num * i;
         
            float vertical = Mathf.Sin(radians);
            float horizontal = Mathf.Cos(radians); 
         
            Vector3 spawnDir = new Vector3 (horizontal, 0, vertical);
         
            Vector3 spawnPos = point + spawnDir * _radius;
         
            GameObject enemy = Instantiate (enemyPrefab, spawnPos, Quaternion.identity);
         
            enemy.transform.LookAt(point);
         
            enemy.transform.Translate (new Vector3 (0, enemy.transform.localScale.y / 2, 0));
        }
    }  
}
