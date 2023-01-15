using UnityEngine;
using UnityEngine.UI;

public class FlyPlane :MonoBehaviour
{
    [SerializeField] private float _massOfPlane;
    [SerializeField] private float _totalWeightOfOil;
    [SerializeField] private float _totalWeightOfRemote;
    [SerializeField] private float _totalWorkFactor;
    [SerializeField] private float _healthOfPlane;
    [SerializeField] private float EngineWorkFactor;
    public Slider OilOfPlaer;
   private void MoveOfPlane()
    {
        EngineWorkFactor = (_totalWeightOfOil + _totalWeightOfRemote) / _massOfPlane;
    }
    private void ControledWeightOfOil(float weightOfOil)
    {
        _totalWeightOfOil = _totalWeightOfOil + weightOfOil;
        MoveOfPlane();
    }
    private void ControledWeightOfRemote(float weightOfRemote)
    {
        _totalWeightOfRemote = _totalWeightOfRemote + weightOfRemote;
        MoveOfPlane();
    }
    private void ManageredMassOfPlane()
    {
       // _massOfPlane = _totalWeightOfOil + _totalWeightOfRemote;
    }
    private void ManageredOil()
    {
        _totalWeightOfOil = _totalWeightOfOil-EngineWorkFactor* _totalWorkFactor;
        OilOfPlaer.value = _totalWeightOfOil;

        if (_totalWeightOfOil <= 0)
        {
            Debug.Log("Oil is over");
        }
    }
    private void RemoteManadger()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;
        if (collideWith.tag != "BoxOfEvent")
        {
            ControledWeightOfOil(100);
        }

    }
    public void DoItOfPlane()
    {
        ManageredOil();
    }

}
