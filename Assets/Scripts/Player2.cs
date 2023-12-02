using UnityEngine;

public class Player2 : LocalPlayer
{
    protected override string VerticalAxis => "Vertical2";

    protected override bool IsLeftPlayer => false;

    void Awake()
    {
        enabled = GameManager.gameMode == GameMode.LocalPvP;
    }

}
