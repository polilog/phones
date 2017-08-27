using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public interface IEmulateCall
    {
        string num { get; }

        void CloseForm();
        void SetController(EmulateCallController controller);
        void ShowErrorMessage(string message);
    }

    public class EmulateCallController
    {
        private IEmulateCall _view;
        private IMainMenu _menu;
        private Unit _unit;

        public EmulateCallController(IEmulateCall view, IMainMenu menu, Unit unit)
        {
            _view = view;
            _menu = menu;
            _unit = unit;
            _view.SetController(this);
        }

        public void EmulateCall()
        {
            int num;
            if (!Int32.TryParse(_view.num, out num))
            {
                _view.ShowErrorMessage("String could not be parsed!");
                return;
            }

            Random rand = new Random();

            if (_unit.GetAllPhones().Count < 2)
            {
                _view.CloseForm();
                return;
            }

            for (int i = 0; i < num; i++)
            {
                int first = rand.Next(_unit.GetAllPhones().Count);
                int second;
                do
                {
                    second = rand.Next(_unit.GetAllPhones().Count);
                } 
                while (first == second);

                
                Phone called = _unit.GetAllPhones()[first];
                Phone calling = _unit.GetAllPhones()[second];
                Call call = new Call(called, calling);

                called.registerCall(ref call);
                calling.registerCall(ref call);
            }
            _menu.ShowStatusInfo();
            _view.CloseForm();
        }
    }
}
