using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public interface IShowLists
    {
        int currentPhone { get; }

        void CloseForm();
        void SetController(ShowListsController controller);
        void SetupDataGridView(bool type);
        void ShowList(params string[] list);
    }

    public class ShowListsController
    {
        private IShowLists _view;
        private Unit _unit;
        private List<Phone> _listPhones;
        private bool _type;

        public ShowListsController(IShowLists view, Unit unit, bool type)
        {
            _view = view;
            _unit = unit;
            _view.SetController(this);
            _type = type;
            if (!type)
                _listPhones = _unit.GetAllPhones();
            _view.SetupDataGridView(type);
            ShowData(type);
        }

        public void ShowData(bool type)
        {
            if (type)
            {
                foreach (Employee employee in _unit.GetAllEmployees())
                {
                    string[] list = new string[7];
                    list[0] = employee.Name;
                    list[1] = employee.Surname;
                    list[2] = employee.Position;

                    if (employee.Sex == true)
                        list[3] = "M";
                    else
                        list[3] = "F";
                    list[4] = employee.BirthDate.ToString("dd.MM.yyyy");
                    list[5] = employee.Unit.TypeToString() + " " + employee.Unit.ToString();

                    if (employee.Phone != null)
                        list[6] = employee.Phone.ToString();
                    else
                        list[6] = "-";

                    _view.ShowList(list);
                }
            }
            else
            {
                foreach (Phone phone in _listPhones)
                {
                    string[] list = new string[3];
                    list[0] = phone.ToString();
                    list[1] = phone.Unit.TypeToString() + " " + phone.Unit.ToString();
                    if (phone.Owner != null)
                        list[2] = phone.Owner.ToString();
                    else
                        list[2] = "-";

                    _view.ShowList(list);
                }
            }
        }

        public void OpenCallLog(ICallLog callLog)
        {
            Phone phone = _listPhones[_view.currentPhone];
            CallLogController callLogController = new CallLogController(callLog, phone);
        }

        public bool CheckPhone()
        {
            if (!_type && _view.currentPhone != -1)
                return true;
            else
                return false;
        }
    }
}
