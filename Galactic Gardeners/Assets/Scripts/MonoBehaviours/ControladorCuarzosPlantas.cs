using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCuarzosPlantas : MonoBehaviour
{
    public static ControladorCuarzosPlantas Instance;
    public GameObject plantaPrefab;
    public GameObject cuarzoSpawner;

    private Vector2[] posicionesPlantas = new Vector2[]
    {
        new Vector2(-0.498f, 0.441f),
        new Vector2(-0.238f, 0.449f),
        new Vector2(-0.506f, -0.23f),
        new Vector2(-0.249f, -0.223f),
        new Vector2(-0.496f, -0.939f),
        new Vector2(-0.22f, -0.938f)
    };

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InstanciarPlantas();
    }

    private void InstanciarPlantas()
    {
        foreach (var posicion in posicionesPlantas)
        {
            Instantiate(plantaPrefab, new Vector3(posicion.x, posicion.y, 0), Quaternion.identity);
        }
    }

    public void DetenerAparicionCuarzos()
    {
        cuarzoSpawner.SetActive(false);
    }
}
