using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DalLib;

namespace TheLongOrbit
{
    public class CommandManager : Singleton<CommandManager>
    {

        protected CommandManager () { }

        public delegate void CommandHandler<T>(T args);

        public event CommandHandler<Selector> OnSelection;
        public event CommandHandler<NavBeacon> OnMove;
                   

    }
}
