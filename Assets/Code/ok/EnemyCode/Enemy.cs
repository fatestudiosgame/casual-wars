using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy 
{

  
        int enemy_piso;
        int enemy_vida;
        int enemy_class;
        int enemy_max_vida;


    public Enemy(int aa, int bb, int cc , int dd)
        {
            enemy_piso = aa;
            enemy_vida = bb;
            enemy_class = cc;
            enemy_max_vida = dd;
        }
        public void setPisoEnemy(int aaa) { enemy_piso = aaa; }
        public int getPisoEnemy() { return enemy_piso; }
        public void setVidaEnemy(int vvv)
        {
        enemy_vida = vvv;
        if (enemy_vida < 1) { enemy_vida = 0; }
        if (enemy_vida > enemy_max_vida) { enemy_vida = enemy_max_vida; }
                  }
        public int getVidaEnemy() { return enemy_vida; }

    public void setClassEnemy(int vvv) { enemy_class = vvv; }
    public int getClassEnemy() { return enemy_class; }

    public void setVidaMaxEnemy(int vvv) { enemy_max_vida = vvv; }
    public int getVidaMaxEnemy() { return enemy_max_vida; }


}
