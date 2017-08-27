using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public interface IAssignHead
    {
        Employee employee { get; }

        void ShowErrorMessage(string message);
        void CloseForm();
        void SetController(AssignHeadController controller);
        void ShowList(List<Employee> employeeList);
    }

    public class AssignHeadController
    {
        private IAssignHead _view;
        private Unit _unit;

        public AssignHeadController(IAssignHead view, Unit unit)
        {
            _view = view;
            _unit = unit;
            _view.SetController(this);
            _view.ShowList(_unit.getEmployeeList());
        }

        public void AssignHead()
        {
            if (_view.employee == null)
            {
                _view.ShowErrorMessage("Select employee to be assigned!");
                return;
            }
            else
            {
                _unit.Head = _view.employee;
                _view.CloseForm();
            }
        }

    }
}
