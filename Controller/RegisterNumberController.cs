using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public interface IRegisterNumber
    {
        string number { get; }

        void ShowErrorMessage(string message);
        void CloseForm();
        void SetController(RegisterNumberController controller);
    }

    public class RegisterNumberController
    {
        private IRegisterNumber _view;
        private Unit _unit;
        private Unit _company;

        public RegisterNumberController(IRegisterNumber view, Unit unit, Unit company)
        {
            _view = view;
            _unit = unit;
            _company = company;
            _view.SetController(this);
        }

        public void RegisterNumber()
        {
            if (!CheckData())
                return;
            Phone newNumber = new Phone(_view.number, _unit);
            _unit.registerPhoneNumber(ref newNumber);
            _view.CloseForm();
        }

        private bool CheckData()
        {
            if (_view.number == "")
            {
                _view.ShowErrorMessage("Field Number cannot be empty!");
                return false;
            }
            List<Phone> list = _company.GetAllPhones();
            foreach (Phone phone in list)
            {
                if (phone.Number == _view.number)
                {
                    _view.ShowErrorMessage("This phone number currently exists!");
                    return false;
                }
            }
            return true;
        }
    }
}
