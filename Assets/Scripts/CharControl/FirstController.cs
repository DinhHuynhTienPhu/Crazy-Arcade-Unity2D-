using UnityEngine;
using System.Collections;

public class FirstController : MonoBehaviour
{

  public Rigidbody2D rb;
  public float speedMultipiler;
  public GameObject DaoActive;
  public GameObject MaridActive;
  public GameObject BazziActive;
  public GameObject CappiActive;

  // Use this for initialization
  void Awake()
  {
    if (FirstPlayerInfo.strCharName == "Dao")
      DaoActive.SetActive(!DaoActive.active);
    else if (FirstPlayerInfo.strCharName == "Marid")
      MaridActive.SetActive(!MaridActive.active);
    else if (FirstPlayerInfo.strCharName == "Bazzi")
      BazziActive.SetActive(!BazziActive.active);
    else if (FirstPlayerInfo.strCharName == "Cappi")
      CappiActive.SetActive(!CappiActive.active);
  }

  // Update is called once per frame
  void Update()
  {

    if (Input.GetKey(KeyCode.F))
    {
      //transform.Translate(Vector3.left * FirstPlayerInfo.fSpeed * Time.deltaTime);
      rb.velocity = new Vector2(-speedMultipiler * FirstPlayerInfo.fSpeed, 0);
    }

    else if (Input.GetKey(KeyCode.H))
    {
      //transform.Translate(Vector3.right * FirstPlayerInfo.fSpeed * Time.deltaTime);
      rb.velocity = new Vector2(speedMultipiler * FirstPlayerInfo.fSpeed, 0);
    }

    else if (Input.GetKey(KeyCode.T))
    {
      //transform.Translate(Vector3.up * FirstPlayerInfo.fSpeed * Time.deltaTime);
      rb.velocity = new Vector2(0, speedMultipiler * FirstPlayerInfo.fSpeed);
    }

    else if (Input.GetKey(KeyCode.G))
    {
      //transform.Translate(Vector3.down * FirstPlayerInfo.fSpeed * Time.deltaTime);
      rb.velocity = new Vector2(0, -speedMultipiler * FirstPlayerInfo.fSpeed);
    }

    if (Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.H) || Input.GetKeyUp(KeyCode.T) || Input.GetKeyUp(KeyCode.G))
    {
      rb.velocity = new Vector2(0, 0);
    }


  }

}
