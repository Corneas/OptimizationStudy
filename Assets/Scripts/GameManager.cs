using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private PlayerMove player;
    public PlayerMove Player => player ??= FindObjectOfType<PlayerMove>();

    private Launcher launcher;
    public Launcher Launcher => launcher ??= FindObjectOfType<Launcher>();
}
