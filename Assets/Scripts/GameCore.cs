using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCore : MonoBehaviour
{
    [SerializeField] private GameObject pistolModel;
    [SerializeField] private Transform forcePoint;
    [SerializeField] private GameObject pistolContainer;
    
    [SerializeField] private Transform pistolSpawner;
    [SerializeField] private AudioSource laserSound;
    [SerializeField] private Animation shotAnimation;
    private Animator anim;

    [SerializeField] private TMP_Text pointsTextMesh;

    [SerializeField] private LineRenderer laserRenderer;

    [SerializeField] private float rotateForce;
    [SerializeField] private float shotForce;

    private int points;

    public void GunShot()
    {
        pistolContainer.GetComponent<Rigidbody>().AddForceAtPosition(-pistolModel.transform.forward * shotForce,
            forcePoint.position);
        pistolModel.GetComponent<Rigidbody>().AddForceAtPosition(-pistolModel.transform.forward * rotateForce,
            forcePoint.position);

        Ray ray = new Ray(forcePoint.position, forcePoint.forward);
        
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            laserEffects(hit.point);
        }
        else
        {
            laserEffects(forcePoint.position + forcePoint.forward * 100);
            return;
        }


        Ihittable IHit = hit.collider.gameObject.GetComponent<Ihittable>();
        if (IHit == null)
            return;
        
        addPoints(IHit.OnHit());
    }

    IEnumerator LaserDraw()
    {
        laserRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        laserRenderer.enabled = false;
    }

    private void laserEffects(Vector3 point)
    {
        shotAnimation.Play();
        
        laserSound.Play();

        laserRenderer.SetPosition(0, forcePoint.position);
        laserRenderer.SetPosition(1, point);
        StartCoroutine(LaserDraw());
    }

    private void addPoints(int points)
    {
        this.points += points;
        
        pointsTextMesh.text = this.points + " points";
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DefeatZone"))
        {
            PlayerPrefs.SetInt("Record", Math.Max(points, PlayerPrefs.GetInt("Record")));
            PlayerPrefs.Save();
            SceneManager.LoadScene(0);
        }
    }
}
