using System;
using System.Collections.Generic;
using System.Text;

namespace TreasureHunter.Characters
{
    internal partial class Player
    {
        protected internal sealed class Inventory
        {

            #region ProtectedInterface

            private List<string> _weapons;
            private List<string> _armor;
            private List<string> _items;
            private List<string> _treasure;


            #endregion

            #region PublicInterface


            public List<string> GetListWeapons
            {
                get { return _weapons; }
            }

            public List<string> GetListArmor
            {
                get { return _armor; }
            }

            public List<string> GetListItems
            {
                get { return _items; }
            }

            public List<string> GetListTreasures
            {
                get { return _treasure; }
            }


            #endregion



        }

    }
}
