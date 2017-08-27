using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public interface ICallLog
    {
        void CloseForm();
        void SetController(CallLogController controller);
        void ShowInfo(string phone, string unit, string employee);
        void ShowList(params string[] list);
    }

    public class CallLogController
    {
        private ICallLog _view;
        private Phone _phone;

        public CallLogController(ICallLog view, Phone phone)
        {
            _view = view; 
            _phone = phone;

            string employee;
            if (_phone.Owner != null)
                employee = _phone.Owner.ToString();
            else
                employee = "-";
            _view.ShowInfo(_phone.ToString(), _phone.Unit.TypeToString() + " " + _phone.Unit.ToString(), employee);

            decimal total = 0;

            foreach (Call call in _phone.showCallLog())
            {
                string[] row = new string[6];
                row[0] = call.CallStart.ToString();
                row[1] = call.Length.ToString();
                row[2] = call.CalledParty.ToString();
                row[3] = call.CallingParty.ToString();

                if (_phone == call.CalledParty)
                {
                    row[4] = "0";
                    row[5] = "0";
                }
                else
                {
                    if (call.CalledParty.Tariff == call.CallingParty.Tariff)
                        row[4] = call.CallingParty.Tariff.InternalCost.ToString();
                    else
                        row[4] = call.CallingParty.Tariff.ExternalCost.ToString();
                    row[5] = call.Cost.ToString();
                    total += call.Cost;
                }

                _view.ShowList(row);
            }

            string[] last = new string[6];
            last[0] = "Total";
            last[1] = "";
            last[2] = "";
            last[3] = "";
            last[4] = "";
            last[5] = total.ToString();
            _view.ShowList(last);

            _view.SetController(this);
        }
    }
}
