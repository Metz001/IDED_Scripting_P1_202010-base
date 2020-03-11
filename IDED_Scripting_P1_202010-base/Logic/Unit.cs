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
        public EUnitClass UnitClass { get; protected set; }

        public int[] Cposition { get; protected set; } = new int[2];
        

      

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {           
            UnitClass = _unitClass;
            BaseAtk = _atk;                     //Constructor
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;
            if (MoveRange > 10)
                MoveRange = 10;
           
            if (_unitClass == EUnitClass.Dragon)
                AtkRange = 5;
            else
                AtkRange = 1;
           
            switch (UnitClass)
            {
                case (EUnitClass.Imp):
                    BaseAtkAdd = 0.1f;
                    BaseDefAdd = 0f;
                    BaseSpdAdd = 0f;
                    break;
                case (EUnitClass.Orc):
                    BaseAtkAdd = 0.4f;
                    BaseDefAdd = 0.2f;
                    BaseSpdAdd = -0.2f;
                    break;
                case (EUnitClass.Dragon):
                    BaseAtkAdd = 0.5f;
                    BaseDefAdd = 0.3f;
                    BaseSpdAdd = 0.2f;
                    break;
            }
            Attack = BaseAtkAdd * BaseAtk + BaseAtk;
            if (Attack > 255)
                Attack = 255;
            Defense= BaseDefAdd * BaseDef+ BaseDef;
            if (Defense > 255)
                Defense = 255;
            Speed = BaseSpdAdd * BaseSpd+ BaseSpd;
            if (Speed > 255)
                Speed = 255;

        }
     

        public virtual bool Interact(Unit otherUnit)
        {
            bool result = true;

            if (otherUnit.UnitClass == EUnitClass.Villager)
            {
                result = false;
                return result;
            }         
            if (UnitClass == EUnitClass.Villager && otherUnit.UnitClass != EUnitClass.Squire || otherUnit.UnitClass != EUnitClass.Soldier|| 
                otherUnit.UnitClass != EUnitClass.Villager)
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
            else
                result = false;
            return result;

        }
        
        public bool Move(int[] targetPosition)
        {
            bool result = false;

         
         

            return result;
        } 
        

    }
}