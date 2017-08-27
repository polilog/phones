using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public interface IRegisterUnit
    {
        string name { get; }

        void ShowErrorMessage(string message);
        void CloseForm();
        void SetController(RegisterUnitController controller);
    }

    public class RegisterUnitController
    {
        private IRegisterUnit _view;
        private Unit _unit;
        private Unit _company;

        public RegisterUnitController(IRegisterUnit view, Unit unit, Unit company)
        {
            _view = view;
            _unit = unit;
            _company = company;
            _view.SetController(this);
        }

        public void RegisterUnit()
        {
            if (!CheckData())
                return;
            Unit newUnit = new Unit(_view.name, _unit.Type + 1);
            _unit.registerUnit(ref newUnit);
            _view.CloseForm();
        }

        private bool CheckData()
        {
            if (_view.name == "")
            {
                _view.ShowErrorMessage("Field Name cannot be empty!");
                return false;
            }
            List<Unit> list = _company.GetAllUnits();
            foreach (Unit unit in list)
            {
                if (unit.Name == _view.name)
                {
                    _view.ShowErrorMessage("This unit currently exists!");
                    return false;
                }
            }
            return true;
        }
    }
}
