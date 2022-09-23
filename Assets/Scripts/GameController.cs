using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

  public static GameController instance;

  public float paddingLeft, paddingTop;
  public float distanceBetweenTiles => BombMgr.TileSize / 2;
  public float row, col;
  public float characterOffsetX, characterOffsetY;
  public static Vector3 ConvertToPositionInGrid(Vector3 oldPos)
  {

    for (int i = 0; i < instance.row; i++)
    {
      for (int j = 0; j < instance.col; j++)
      {
        float x = instance.paddingLeft + j * instance.distanceBetweenTiles;
        float y = instance.paddingTop - i * instance.distanceBetweenTiles;
        float nextx = x + instance.distanceBetweenTiles;
        float nexty = y - instance.distanceBetweenTiles;
        if (oldPos.x >= x && oldPos.x < nextx && oldPos.y <= y && oldPos.y > nexty)
        {
          return new Vector3(x, y, 0);
        }
      }

    }
    return Vector3.zero;
  }
  public void CreateBoom(Vector3 pos)
  {
    GameObject bombObj = (GameObject)GameObject.Instantiate(Resources.Load("Bomb"));
    Bomb bomb = bombObj.GetComponent<Bomb>();
    if (bomb == null)
      return;
    bomb.CreateBomb(pos,
        this.gameObject.transform.rotation,
        FirstPlayerInfo.iBubbleLengthCount);
  }
  [ContextMenu("CreateBoom")]
  public void TestCreateBooms()
  {
    for (int i = 0; i < instance.row; i++)
    {
      for (int j = 0; j < instance.col; j++)
      {
        float x = instance.paddingLeft + j * instance.distanceBetweenTiles;
        float y = instance.paddingTop - i * instance.distanceBetweenTiles;
        instance.CreateBoom(new Vector3(x, y, 0));
      }

    }
  }


  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
