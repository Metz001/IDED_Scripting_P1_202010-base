namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }        //Potencial, disponible únicamente para Humanos

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            Potential = _potential;         //El potencial debe de aumentar las habilidades de atk y def de los humanos
           Attack = _atk * _potential;
            Defense = _def * _potential;
            Speed = _spd * _potential;


        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            if (UnitClass == EUnitClass.Soldier && newClass == EUnitClass.Squire)
                return true;
            if (UnitClass == EUnitClass.Squire && newClass == EUnitClass.Soldier)
                return true;
            if (UnitClass == EUnitClass.Mage && newClass == EUnitClass.Ranger)
                return true;
            if (UnitClass == EUnitClass.Ranger && newClass == EUnitClass.Mage)
                return true;
            return false;           //método para cambiar libremente entre clases, Menos el Aldeano
        }
    }
}