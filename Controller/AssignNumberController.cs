using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public interface IAssignNumber
    {
        Employee employee { get; }
        Phone phone { get; }

        void ShowErrorMessage(string message);
        void CloseForm();
        void SetController(AssignNumberController controller);
        void ShowEmployeeList(List<Employee> employeeList);
        void ShowNumberList(List<Phone> phoneList);
    }

    public class AssignNumberController
    {
        private IAssignNumber _view;
        private Unit _unit;

        public AssignNumberController(IAssignNumber view, Unit unit)
        {
            _view = view;
            _unit = unit;
            _view.SetController(this);
            _view.ShowEmployeeList(_unit.getEmployeeList());
            _view.ShowNumberList(_unit.getPhoneList());
        }

        public void AssignNumber()
        {
            if (_view.employee == null)
            {
                _view.ShowErrorMessage("Select employee!");
                return;
            }

            if (_view.phone == null)
            {
                _view.ShowErrorMessage("Select phone number!");
                return;
            }

            if (_view.phone.Owner != null)
                _view.phone.Owner.Phone = null;
            _view.phone.Owner = _view.employee;

            if (_view.employee.Phone != null)
                _view.employee.Phone.Owner = null;
            _view.employee.Phone = _view.phone;

            _view.CloseForm();
        }
    }
}
