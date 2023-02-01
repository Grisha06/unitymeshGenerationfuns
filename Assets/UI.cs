using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider slider;
    public Slider slider2;
    public Slider slider3;
    public Button button;
    public MeshGenerator mg;
    public PlayerMovement pm;
    public CameraFollow cf;
    private void Start()
    {
        button.onClick.AddListener(() => { pm.transform.position = new Vector3(50, 100, 50); });
        slider.onValueChanged.AddListener((float value) => { mg.noiseValue = value; });
        slider2.onValueChanged.AddListener((float value) => { mg.noiseOffset = value; });
        slider3.onValueChanged.AddListener((float value) => { cf.offset.y = value; });
    }
}
