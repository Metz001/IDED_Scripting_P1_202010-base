namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }        //Potencial, disponible únicamente para Humanos

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;                     //Constructor
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;

            if (_unitClass == EUnitClass.Dragon || _unitClass == EUnitClass.Orc || _unitClass == EUnitClass.Imp)
            {
                UnitClass = EUnitClass.Villager;
                BaseAtk = 0;
                BaseDef = 0;
            }
                                     // Verificación, que no sea un monstruo humano
            if (_unitClass == EUnitClass.Villager)
            {
                BaseAtk = 0;
                BaseDef = 0;
            }

            if (_unitClass == EUnitClass.Mage || _unitClass == EUnitClass.Ranger)
                AtkRange = 3;
            else
                AtkRange = 1;

            switch (UnitClass)
            {
                case (EUnitClass.Squire):
                    BaseAtkAdd = 0.2f;
                    BaseDefAdd = 0.1f;
                    BaseSpdAdd = 0f;
                    break;
                case (EUnitClass.Soldier):
                    BaseAtkAdd = 0.3f;
                    BaseDefAdd = 0.2f;
                    BaseSpdAdd = 1f;
                    break;
                case (EUnitClass.Ranger):
                    BaseAtkAdd = 0.1f;
                    BaseDefAdd = 0f;
                    BaseSpdAdd = 0.3f;
                    break;
                case (EUnitClass.Mage):
                    BaseAtkAdd = 0.3f;
                    BaseDefAdd = 0.1f;
                    BaseSpdAdd = -0.1f;
                    break;
            }

            Attack = (BaseAtkAdd * BaseAtk) + (BaseAtk*Potential)+BaseAtk;
            if (Attack > 255)
                Attack = 255;
            Defense = (BaseDefAdd * BaseDef) + (BaseDef * Potential) + BaseDef;  //El potencial debe de aumentar las habilidades de atk y def de los humanos
            if (Defense > 255)
                Defense = 255;
            Speed = (BaseSpdAdd * BaseSpd) + (BaseSpd*Potential)+ BaseSpd;
            if (Speed > 255)
                Speed = 255;



        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            if (UnitClass == EUnitClass.Soldier && newClass == EUnitClass.Squire)
            {
                UnitClass = EUnitClass.Squire;
                return true;
            }
               
            if (UnitClass == EUnitClass.Squire && newClass == EUnitClass.Soldier)
            {
                UnitClass = EUnitClass.Soldier;
                return true;
            }
                
            if (UnitClass == EUnitClass.Mage && newClass == EUnitClass.Ranger)
            {
                UnitClass = EUnitClass.Ranger;
                return true;
            }
           
            if (UnitClass == EUnitClass.Ranger && newClass == EUnitClass.Mage)
            {
                UnitClass = EUnitClass.Mage;
                return true;
            }
            
            return false;           //método para cambiar libremente entre clases, Menos el Aldeano
        }
    }
}