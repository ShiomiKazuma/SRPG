using System;
using Alchemy.Inspector;
using UnityEngine;
using Object = UnityEngine.Object;

public class MapGenerator : MonoBehaviour
{
    [LabelText("マスの間隔")]
    [SerializeField] private float _interval = 2f;
    [LabelText("普通の地面")]
    [SerializeField] private GameObject _normalGroundPrefab;
    [LabelText("水のフィールド")]
    [SerializeField] private GameObject _waterFieldPrefab;
    [LabelText("マップの縦")]
    [SerializeField] private int _height = 15;
    [LabelText("マップの幅")]
    [SerializeField] private int _width = 15;
    private GameObject _mapParent;

    private void Awake()
    {
        _mapParent = new GameObject("Map");
    }

    private void Start()
    {
        MapGenerate();
    }

    /// <summary>
    /// マップ生成メソッド
    /// </summary>
    public void MapGenerate()
    {
        int count = 0;
        Vector3 offset = new Vector3(-_width / 2, 0, -_height / 2) * _interval;
        for(int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                Vector3 pos = new Vector3(i, 0, j) * _interval + offset;
                GameObject prefab;
                if (count % 2 == 0)
                    prefab = _normalGroundPrefab;
                else
                    prefab = _waterFieldPrefab;
                
                Instantiate(prefab, pos, prefab.transform.rotation, _mapParent.transform);
                count++;
            }
        }
    }
}
