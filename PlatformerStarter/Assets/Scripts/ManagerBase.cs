using UnityEngine;
using LP.Core;
using Zenject;

public class ManagerBase : MonoBehaviour
{
    private IGame game;

    [Inject]
    public void Setup(IGame game)
    {
        this.game = game;
    }

    void Update()
    {
        game.FunctionInputs();
    }
}
