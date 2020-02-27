namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        public int BaseAtk { get; protected set; }
        public int BaseDef { get; protected set; }          //Las unidades tiene Atk Def y sus multiplicadores
        public int BaseSpd { get; protected set; }

        public int MoveRange { get; protected set; }  //tmb atributos de Range
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }   //Multiplicadores, dependen de su UnitClass
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; protected set; }
        public float Defense { get; protected set; }               //Resultado de Base * % de Add
        public float Speed { get; protected set; }

        protected Position CurrentPosition;

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
           
            UnitClass = _unitClass;
            BaseAtk = _atk;                     //Constructor
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;
            if (_unitClass == EUnitClass.Mage || _unitClass == EUnitClass.Ranger)
                AtkRange = 3;
            else if (_unitClass == EUnitClass.Dragon)
                AtkRange = 5;
            else if (_unitClass == EUnitClass.Villager)
            {
                BaseAtk = 0;
                BaseDef = 0;
                BaseSpd = _spd;
            }

        }

        public virtual bool Interact(Unit otherUnit)
        {
            bool result = true;

            if (otherUnit.UnitClass == EUnitClass.Villager)
            {
                result = false;
                return result;
            }         
            if (UnitClass == EUnitClass.Villager && otherUnit.UnitClass != EUnitClass.Squire || otherUnit.UnitClass != EUnitClass.Soldier|| otherUnit.UnitClass != EUnitClass.Villager)
            {
                result = false;
            }

            if (UnitClass == EUnitClass.Mage)
                if (otherUnit.UnitClass == EUnitClass.Mage || otherUnit.UnitClass == EUnitClass.Ranger)
                    result = false;
            if (UnitClass == EUnitClass.Dragon)
                if (otherUnit.UnitClass == EUnitClass.Imp || otherUnit.UnitClass == EUnitClass.Ranger || otherUnit.UnitClass == EUnitClass.Orc)
                    result = false;

            return result;                             //Método de interactiar con otra unidad
                                                         //¿que puede hacer esta unidad con "otherUnit"?
        }

        public virtual bool Interact(Prop prop)
        {
            bool result = false;
            if (UnitClass == EUnitClass.Villager)
                result = true;
            return result;

        }

        public bool Move(Position targetPosition)
        {
            bool result = false;
         

            return result;
        } 

    }
}