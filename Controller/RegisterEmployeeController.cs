using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public interface IRegisterEmployee
    {
        string name { get; }
        string surname { get; }
        string position { get; }
        bool? sex { get; }
        DateTime birthDate { get; }
        
        void ShowErrorMessage(string message);
        bool ShowWarningMessage(string message);
        void CloseForm();
        void SetController(RegisterEmployeeController controller);
    }

    public class RegisterEmployeeController
    {
        private IRegisterEmployee _view;
        private Unit _unit;

        public RegisterEmployeeController(IRegisterEmployee view, Unit unit)
        {
            _view = view;
            _unit = unit;
            _view.SetController(this);
        }

        public void RegisterEmployee()
        {
            if (_view.name == "")
            {
                _view.ShowErrorMessage("Field Name cannot be empty!");
                return;
            }

            if (_view.surname == "")
            {
                _view.ShowErrorMessage("Field Surame cannot be empty!");
                return;
            }

            if (_view.position == "")
            {
                _view.ShowErrorMessage("Field Position cannot be empty!");
                return;
            }

            if (_view.birthDate.Date.Year < 1900 || _view.birthDate.Date.Year > 1998)
            {
                if (!_view.ShowWarningMessage("Birthdate may be incorrect. Do you want to create employee?"))
                    return;
            }

            if (_view.sex == null)
            {
                _view.ShowErrorMessage("Choose Sex!");
                return;
            }

            Employee newEmployee = new Employee(_view.name, _view.surname, _view.position, _view.sex, _view.birthDate, _unit);
            _unit.registerEmployee(ref newEmployee);
            _view.CloseForm();
        }
    }
}
