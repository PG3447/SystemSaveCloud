using UnityEngine;

public class Wall : MonoBehaviour
{
    private struct Colors
    {
        public Color a, b;
        public Colors(GameObject gameObject, GameObject gameObject2) {
            a = gameObject.GetComponent<Renderer>().material.color;
            b = gameObject2.GetComponent<Renderer>().material.color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Sphere") {
            CheckColor(collision.gameObject);
        }
    }

    private void CheckColor(GameObject Sphere) {
        Colors component =  new Colors(this.gameObject, Sphere);
        if (component.a == component.b) {
            ManagerWallsAndColors.instance.ChangeColor();
        }
    }

}
