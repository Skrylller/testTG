using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Инициализирует игру.
/// </summary>
public class GameBoot : MonoBehaviour
{
    private DataContainer dataContainer;

    [SerializeField] private FigureModel _figureModel;
    [SerializeField] private Figure _figure1;
    [SerializeField] private Figure _figure2;
    [SerializeField] private Center _center;
    [SerializeField] private MainUI _mainUI;

    private void Awake()
    {
        Boot();
    }

    private void Boot()
    {
        dataContainer = new DataContainer();

        dataContainer.Reset();

        _figure1.Constr(_figureModel, _center, dataContainer);
        _figure2.Constr(_figureModel, _center, dataContainer);
        _mainUI.Constr(dataContainer);
    }
}
