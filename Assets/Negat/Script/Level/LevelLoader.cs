using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelLoader : MonoBehaviour
{
    public int screenHeight = 11;
    public int screenWidth = 5;
    public Texture2D levelMap;
    public ColorToPrefab[] colorToPrefabs;

    public List<GameObject> movingEnemyA = new List<GameObject>();
    public List<GameObject> movingEnemyB = new List<GameObject>();

    public List<GameObject> LaserA = new List<GameObject>();
    public List<GameObject> LaserB = new List<GameObject>();
    //public List<GameObject> Platforms = new List<GameObject>();

    GameObject go;

    private void Awake()
    {
        levelMap = LevelManager.GetTexture2D(LevelLoaderManager.Instance.level);
    }
    void Start()
    {
        LoadMap();
    }

    void LoadMap()
    {
        Color32[] allPixels = levelMap.GetPixels32();
        int width = levelMap.width;
        int height = levelMap.height;

        int offsetY = height - screenHeight;
        int offsetX = width - screenWidth;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                SpawnPrefab(allPixels[(y * width) + x], x - offsetX, y - offsetY);
            }
        }

        SetEnemyBtoA();
        SetLaserBtoA();
    }



    void SpawnPrefab(Color32 _color, int x, int y)
    {
        y = y - 10;
        if (_color.a <= 0)
        {
            return;
        }

        foreach (ColorToPrefab ctp in colorToPrefabs)
        {
            if (ctp.color.Equals(_color))
            {
                if (ctp.prefab)
                {
                    var type = ctp.prefab.GetComponent<Type>();
                    if (!type) return;
                    switch (type.goType)
                    {
                        case Type.GoType.Goal:
                            Goal(ctp, x, y);
                            break;
                        case Type.GoType.Laser:
                            SpawnLaserAtoB(ctp, x, y);
                            break;
                        case Type.GoType.FireBall:
                            SpawnFireBall(ctp, x, y);
                            break;
                        case Type.GoType.MovingEnemy:
                            SpawnEnemyAtoB(ctp, x, y);
                            break;
                        case Type.GoType.Platform:
                            SpawnPlatform(ctp, x, y);
                            break;
                        case Type.GoType.CameraTrigger:
                            CameraTrigger(ctp, x, y);
                            break;
                        case Type.GoType.Star:
                            SpawnStar(ctp, x, y);
                            break;


                    }
                    if (ctp.prefab.tag == "Goal")
                        Goal(ctp, x, y);

                }
            }

        }


    }
    void SpawnStar(ColorToPrefab ctp, int x, int y)
    {
        go = Instantiate(ctp.prefab, new Vector3(x, y, 0), Quaternion.identity);
        go.transform.localScale = new Vector3(.5f, .5f, .5f);
        go.transform.parent = this.transform;
        return;
    }
    void Goal(ColorToPrefab ctp, int x, int y)
    {
        Debug.Log("GOAL");
        go = Instantiate(ctp.prefab, new Vector3(0, y, 0), Quaternion.identity);
        go.transform.parent = this.transform;
    }
    void CameraTrigger(ColorToPrefab ctp, int x, int y)
    {
        go = Instantiate(ctp.prefab, new Vector3(0, y, 0), Quaternion.identity);
        go.transform.parent = this.transform;
    }
    void SpawnPlatform(ColorToPrefab ctp, int x, int y)
    {
        go = Instantiate(ctp.prefab, new Vector3(x, y, 0), Quaternion.identity);
        go.transform.parent = this.transform;
        //Platforms.Add(go);
    }

    //Todo To fix 
    /*    void SetPlatforms()
        {
            foreach (GameObject goA in Platforms)
            {
                foreach (GameObject goB in Platforms)
                {
                    if (goA.transform.position.y == goB.transform.position.y)
                    {
                        if (goA.transform.localScale.x >= goB.transform.position.x - goB.transform.localScale.x)
                        {
                            goA.transform.localScale = new Vector3(goA.transform.localScale.x + 1, 1, 1);
                            goA.transform.position = new Vector3((goA.transform.position.x + goB.transform.position.x) / 2, goA.transform.position.y, goA.transform.position.z);
                            Destroy(goB);
                        }
                    }
                }
            }
        }
    */
    void SpawnEnemyAtoB(ColorToPrefab ctp, int x, int y)
    {
        if (ctp.prefab.tag == "EnemyA")
        {
            go = Instantiate(ctp.prefab, new Vector3(x, y, -1), Quaternion.identity);
            go.transform.GetChild(0).position = go.transform.position;
            go.transform.parent = this.transform;
            movingEnemyA.Add(go);
            return;
        }
        if (ctp.prefab.tag == "EnemyB")
        {
            go = Instantiate(ctp.prefab, new Vector3(x, y, -1), Quaternion.identity);
            go.transform.parent = this.transform;
            movingEnemyB.Add(go);
            return;
        }
    }


    void SpawnLaserAtoB(ColorToPrefab ctp, int x, int y)
    {
        int newX = x;
        if (x == 4)
        {
            newX = x + 1;
        }
        if (x == -4)
        {
            newX = x - 1;
        }
        if (ctp.prefab.tag == "LaserA")
        {
            go = Instantiate(ctp.prefab, new Vector3(newX, y, 0), Quaternion.identity);
            go.transform.parent = this.transform;
            LaserA.Add(go);
            return;
        }
        if (ctp.prefab.tag == "LaserB")
        {
            go = Instantiate(ctp.prefab, new Vector3(newX, y, 0), Quaternion.identity);
            go.transform.parent = this.transform;
            LaserB.Add(go);
            return;
        }
    }


    void SpawnFireBall(ColorToPrefab ctp, int x, int y)
    {
        go = Instantiate(ctp.prefab, new Vector3(x, y, 0), Quaternion.identity);
        go.transform.localScale = new Vector3(.5f, .5f, .5f);
        go.transform.parent = this.transform;
        return;
    }


    void SetEnemyBtoA()
    {
        int i = 0;
        foreach (GameObject go in movingEnemyA)
        {
            go.transform.GetChild(1).position = movingEnemyB[movingEnemyB.Count - i - 1].transform.position;
            Destroy(movingEnemyB[movingEnemyB.Count - i - 1]);
            i++;
        }

        movingEnemyB = null;
        movingEnemyA = null;
    }

    void SetLaserBtoA()
    {
        foreach (GameObject goA in LaserA)
        {
            foreach (GameObject goB in LaserB)
            {
                if (goA.transform.position.y == goB.transform.position.y)
                {
                    goA.transform.GetChild(0).GetComponent<LasersController>().endPoint = goB.transform;
                }

            }
        }

        LaserA = null;
        LaserB = null;
    }

}










[System.Serializable]
public class ColorToPrefab
{
    public Color32 color;
    public GameObject prefab;
}
