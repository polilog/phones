using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public interface IMainMenu
    {
        string type { get; }
        Unit currentUnit { get; }
        
        void SetController(MainMenuController controller);
        void ClearLists();
        void ShowList(List<Unit> list);
        void ShowTitle(string title);
        void ShowErrorMessage(string message);
        void ForbidCreate();
        void ShowStatusInfo();
    }

    public class MainMenuController
    {
        private IMainMenu _view;
        private Unit _company;
        private Unit _unit;

        public MainMenuController(IMainMenu view, Unit unit)
        {
            _view = view;
            _unit = unit;
            _company = unit;
            _view.SetController(this);
            _view.ShowTitle("company" + " " + _unit.ToString());
        }

        public void OpenRegisterUnit(IRegisterUnit regUnit)
        {
            RegisterUnitController regUnitController = new RegisterUnitController(regUnit, _unit, _company);
        }

        public void OpenRegisterEmployee(IRegisterEmployee regEmployee)
        {
            RegisterEmployeeController regEmployeeController = new RegisterEmployeeController(regEmployee, _unit);
        }

        public void OpenRegisterNumber(IRegisterNumber regNumber)
        {
            RegisterNumberController regNumberController = new RegisterNumberController(regNumber, _unit, _company);
        }

        public void OpenAssignHead(IAssignHead assignHead)
        {
            AssignHeadController assignHeadController = new AssignHeadController(assignHead, _unit);
        }

        public void OpenAssignNumber(IAssignNumber assignNumber)
        {
            AssignNumberController assignNumberController = new AssignNumberController(assignNumber, _unit);
        }

        public void OpenShowLists(IShowLists showLists, bool type)
        {
            ShowListsController showListsController = new ShowListsController(showLists, _company, type);
        }

        public void OpenEmulateCall(IEmulateCall emulateCall, IMainMenu menu)
        {
            EmulateCallController assignNumberController = new EmulateCallController(emulateCall, menu, _company);
        }

        public void AddList()
        {
            List<Unit> list = _company.getUnitList();
            _view.ShowList(list);
        }

        public void ChooseUnit()
        {
            if (_view.type != "company")
            {
                if (_view.currentUnit == null)
                {
                    _view.ShowErrorMessage("Choose unit from the list!");
                    return;
                }
                _unit = _view.currentUnit;
            }
            else
                _unit = _company;
            if (_unit.Type == 3)
                _view.ForbidCreate();
            string title = _view.type + " " + _unit.ToString();
            _view.ShowTitle(title);
        }

    }
}
