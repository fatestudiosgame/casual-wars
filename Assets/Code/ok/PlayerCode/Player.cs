using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{

    int player_piso;
    int player_vida;
    int player_class;
    int player_max_vida;

    public Player(int piso_, int vida_, int clase_, int vida_max_)
    {
        player_piso = piso_;
        player_vida = vida_;
        player_class = clase_;
        player_max_vida = vida_max_;
    }

    public void setPisoPlayer(int aaa)
    {
        player_piso = aaa;
        if (player_piso > 3) { player_piso = 3; }
        else if (player_piso < 1) { player_piso = 1; }
    }

    public int getPisoPlayer() { return player_piso; }



    public void setVidaPlayer(int vvv) { 
        player_vida = vvv; 
        if (player_vida < 1) { player_vida = 0; }
        if (player_vida > player_max_vida) { player_vida = player_max_vida; }
    }
    public int getVidaPlayer() { return player_vida; }

    public void setClassPlayer(int vvv) { player_class = vvv; }
    public int getClassPlayer() { return player_class; }


    public int getVidaMaxPlayer() { return player_max_vida; }


}
