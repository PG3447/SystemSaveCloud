using UnityEngine;

public class RotationSphere : MonoBehaviour, IManagerSave
{
    private Rigidbody rigidbodyone;
    private int direction;
    private Vector3 ForceRotation;


    public string GuidId;
    [SerializeField][HideInInspector] public string id;

    //Id Generator Guid.NewGuid().ToString()
    private void Awake()
    {
        id = GuidId;
        GuidId = default(string);
        direction = 1;
        rigidbodyone = this.GetComponent<Rigidbody>();
        ForceRotation = Vector3.zero;
    }
    private void FixedUpdate()
    {
        direction = ManagerWallsAndColors.instance.ReadDirection();
        switch (direction) {
            case 0:
                ForceRotation = transform.right * 500f; //gora
                break;
            case 1:
                ForceRotation = transform.right * -500f; //dol
                break;
            case 2:
                ForceRotation = transform.forward * 500f; //lewo
                break;
            case 3:
                ForceRotation = transform.forward * -500f; ;//prawo
                break;
            default:
                ForceRotation = Vector3.zero;
                break;
        }
        rigidbodyone.GetComponent<Rigidbody>().AddRelativeTorque(ForceRotation);
    }

    public void DataSave(ref GameData gameData)
    {
        gameData.MultipleVectorsToDictionary(gameData.SpheresPositions, id, this.transform.position);
        gameData.MultipleVectorsToDictionary(gameData.SpheresForces, id, this.GetComponent<Rigidbody>().velocity);
    }

    public void DataLoad(GameData gameData)
    {
        foreach (string key in gameData.SpheresPositions.Keys) {
            if (key == id) {
                this.transform.position = gameData.MultipleDictionaryToVector(gameData.SpheresPositions, id);
                this.GetComponent<Rigidbody>().velocity = gameData.MultipleDictionaryToVector(gameData.SpheresForces, id);
            }
        }

    }
}
