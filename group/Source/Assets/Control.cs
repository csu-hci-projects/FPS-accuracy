using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Windows;
using UnityEditor;

public class Control : MonoBehaviour
{
    private string participantsName;
    public InputField iField;
    public Text km_exp;
    public Text control_exp;

    public Camera survey_cam;
    private Camera player_cam;
    public GameObject Pre_Survey;

    public GameObject player_prefab;
    private GameObject player;

    public GameObject bullet_prefab;
    private float accuracy;
    private bool isOn;

    public GameObject tog;

    // Start is called before the first frame update
    void Start()
    {
        survey_cam.enabled = true;
        Pre_Survey.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInputChange()
    {
        participantsName = iField.text;
    }

    public IEnumerator Seq()
    {
        yield return StartCoroutine(submitPressed());
        yield return StartCoroutine(endPractice());
    }

    public IEnumerator submitPressed()
    {
        Pre_Survey.SetActive(false);
        survey_cam.enabled = false;

        GameObject spawn = GameObject.Find("SpawnPractice");
        player = GameObject.Instantiate(player_prefab, spawn.transform.position, spawn.transform.rotation);
        player_cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        player_cam.enabled = true;
        player.SetActive(true);

        Toggle togg = tog.GetComponent<Toggle>();
        isOn = togg.isOn;

        yield return null;
    }

    public void onEnd()
    {
        string finish;
        if (isOn)
            finish = " con";
        else
            finish = " km";
        Directory.CreateDirectory(@"C:\Users\Adam\CS464 - HCI\Assets\Data\" + participantsName + finish);
        System.IO.File.WriteAllText(@"C:\Users\Adam\CS464 - HCI\Assets\Data\" + participantsName + finish + ".txt", km_exp.text + "\n" + control_exp.text
                                   + "\n" + accuracy);

        Application.Quit();
    }

    public IEnumerator endPractice()
    {
        yield return new WaitForSeconds(60);

        player.SetActive(false);

        GameObject spawn = GameObject.Find("SpawnTest");
        player = GameObject.Instantiate(player_prefab, spawn.transform.position, spawn.transform.rotation);
        player_cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        player_cam.enabled = true;

        GameObject test_area = GameObject.Find("Testing_Range");
        test_area.GetComponent<SpawnTargets>().enabled = true;

        bullet_prefab.GetComponent<Bullet>().resetCounts();

        yield return null;
    }

    public void setAccuracy(float v)
    {
        accuracy = v;
        print("ACCURACY: " + accuracy);
    }
}
