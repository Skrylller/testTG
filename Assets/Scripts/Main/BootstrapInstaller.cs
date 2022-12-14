using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Инициализирует игру.
/// </summary>
public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private Transform _locationObj;
    [SerializeField] private FigureModel _figureModel;
    [SerializeField] private Center _center;

    [SerializeField] private List<Transform> _figureSpawnPoints;
    [SerializeField] private List<Figure> _figures;

    public override void InstallBindings()
    {
        Container.Bind<DataContainer>().FromInstance(new DataContainer()).AsSingle();
        Container.Bind<FigureModel>().FromInstance(_figureModel).AsSingle();
        Container.Bind<ICenter>().FromInstance(_center).AsSingle();
    }

    public override void Start()
    {
        InstantFigures();
    }

    private void InstantFigures()
    {
        for (int f = 0, p = 0; f < _figures.Count; f++)
        {
            Figure figure = Container
                .InstantiatePrefabForComponent<Figure>(_figures[f], _figureSpawnPoints[p].position, Quaternion.identity, _locationObj);

            p = p + 1 < _figureSpawnPoints.Count ? p + 1 : 0;
        }
    }
}
