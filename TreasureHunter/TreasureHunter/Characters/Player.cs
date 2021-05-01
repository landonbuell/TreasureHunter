using System;
using System.Collections.Generic;
using System.Text;

namespace TreasureHunter.Characters
{
    internal partial class Player : Character
    {
        #region FeildsAndProperties

        protected string _name;
        protected string _class;

        protected int _health;
        protected int _magic;
        protected int _stamina;
        


        protected Inventory _inventory;

        protected

        internal Player(string name) : base()
        {
            _name = name;
            _class = null;

            _health = 100;
            _stamina = 100;
            _stamina = 100;

            _inventory = new Inventory();
        }

        protected 

        #endregion


        #region PublicInterface




        #endregion

        #region PrivateInterface




        #endregion

    }
}
